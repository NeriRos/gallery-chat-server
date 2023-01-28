using System;
using System.Reflection;
using Microsoft.AspNetCore.SignalR;

namespace GalleryChatServer
{
    public class ChatHub : Hub
    {
        private IDictionary<string, Chat> chats = new Dictionary<string, Chat>();

        public async Task NewMessage(User sender, string id, string message)
        {
            Message messageObject = new Message(id, sender, message);
            Chat chat;

            if (this.chats.ContainsKey(id))
            {
                chat = this.chats[id];
            }
            else
            {
                chat = new Chat(id);
                this.chats.Add(id, chat);
            }

            chat.AddMessage(messageObject);

            await Clients.All.SendAsync($"new_message-{id}", messageObject);
        }
    }
}

