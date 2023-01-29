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
        public static string GetGroupId(string chatId) => $"chat-{chatId}";

        public async Task Init(string id)
        {
            Chat chat = this.ChatService.CreateChat(id);
            await this.AddToChat(chat.Id.ToString(), GetGroupId(id));

            await Clients.Client(this.GetConnectionId()).SendAsync("init", this.ChatService.GetChat(id));
        }

        public async Task NewMessage(User sender, string id, string message)
        {
            Message messageObject = new Message(id, sender, message);

            this.ChatService.AddMessage(id, messageObject);

            await Clients.Group(GetGroupId(id)).SendAsync("newMessage", messageObject);
        }

        public async Task AddToChat(string chatId, string groupName)
        {
            this.ChatService.AddToChat(chatId, this.GetConnectionId());
            await Groups.AddToGroupAsync(this.GetConnectionId(), groupName);
        }

        public async Task RemoveFromChat(string? groupName = null)
        {
            if (groupName == null)
            {
                string? chatId = this.ChatService.RemoveFromChat(this.GetConnectionId());

                if (chatId == null)
                {
                    return;
                }

                groupName = GetGroupId(chatId);
            }

            await Groups.RemoveFromGroupAsync(this.GetConnectionId(), groupName);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Task task = this.RemoveFromChat();

            return base.OnDisconnectedAsync(exception);
        }
    }
}

