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

        public async Task NewMessage(User sender, string id, string message)
        {
            Message messageObject = new Message(id, sender, message);

            this.ChatService.AddMessage(id, messageObject);

            await Clients.All.SendAsync($"new_message-{id}", messageObject);
        }
    }
}

