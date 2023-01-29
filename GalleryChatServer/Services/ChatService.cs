using System;
using Microsoft.AspNetCore.SignalR;

namespace GalleryChatServer.Services
{
    public class ChatService
    {
        private IDictionary<string, Chat> Chats = new Dictionary<string, Chat>();
        private IDictionary<string, List<string>> ChatConnections = new Dictionary<string, List<string>>();

        public Chat CreateChat(string chatId)
        {
            Chat? chat = this.GetChat(chatId);

            if (chat == null)
            {
                this.Chats.Add(chatId, new Chat(chatId));
                this.ChatConnections.Add(chatId, new List<string>());
                chat = this.Chats[chatId];
            }

            return chat;
        }

        public void AddToChat(string chatId, string connectionId)
        {
            if (this.Chats.ContainsKey(chatId))
            {
                this.ChatConnections[chatId].Add(connectionId);
            }
        }

        public string? GetConnectionChat(string connectionId)
        {
            foreach (KeyValuePair<string, List<string>> item in this.ChatConnections)
            {
                if (item.Value.Contains(connectionId))
                {
                    return item.Key;
                }
            }

            return null;
        }

        public string? RemoveFromChat(string connectionId, string? chatId = null)
        {
            if (chatId == null)
                chatId = this.GetConnectionChat(connectionId);

            if (chatId != null && this.ChatConnections.ContainsKey(chatId))
                this.ChatConnections[chatId].Remove(connectionId);

            return chatId;
        }

        public Chat? GetChat(string chatId)
        {
            return Chats.TryGetValue(chatId, out Chat? value) ? value : null;
        }

        public void AddMessage(string chatId, Message message)
        {
            this.Chats[chatId]?.AddMessage(message);
        }
    }
}

