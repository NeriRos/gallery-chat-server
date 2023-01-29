using System;
namespace GalleryChatServer.Services
{
    public class ChatService
    {
        private IDictionary<string, Chat> chats = new Dictionary<string, Chat>();

        public void CreateChat(string id)
        {
            if (!this.chats.ContainsKey(id))
            {
                this.chats.Add(id, new Chat(id));
            }
        }

        public Chat GetChat(string id)
        {
            this.CreateChat(id);

            return this.chats[id];
        }

        public void AddMessage(string id, Message message)
        {
            this.CreateChat(id);

            this.chats[id].AddMessage(message);
        }
    }
}

