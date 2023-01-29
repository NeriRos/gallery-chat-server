using System;
using System.Reflection;
using GalleryChatServer.Services;
using Microsoft.AspNetCore.SignalR;

namespace GalleryChatServer
{
    public class ChatHub : Hub
    {

        private readonly ChatService ChatService;

        public ChatHub(ChatService chatService)
        {
            ChatService = chatService;
        }

        public string GetConnectionId() => Context.ConnectionId;

        public async Task AddToChat(string groupName) => await Groups.AddToGroupAsync(this.GetConnectionId(), groupName);

        public async Task RemoveFromChat(string? groupName)
        {
            string chatId = this.ChatService.RemoveFromChat(this.GetConnectionId());
            groupName = groupName ?? $"chat-{chatId}";

            await Groups.RemoveFromGroupAsync(this.GetConnectionId(), groupName);
        }

        public async Task NewMessage(User sender, string id, string message)
        {
            Message messageObject = new Message(id, sender, message);

            this.ChatService.AddMessage(id, messageObject);

            await Clients.All.SendAsync($"new_message-{id}", messageObject);
        }

        public async Task Init(string id)
        {
            this.ChatService.CreateChat(id);
            await this.AddToChat($"chat-{id}");
            //All.SendAsync($"init-{id}", this.ChatService.GetChat(id););
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            this.RemoveFromChat(null);

            return base.OnDisconnectedAsync(exception);
        }
    }
}

