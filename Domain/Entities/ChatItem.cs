using System;

namespace Domain.Entities {

    public class ChatItem : BaseEntity {
        public string Title { get; set; }
        public string LastMessage { get; set; }
        public DateTime TimeLastMessage { get; set; }
        public string PathImage { get; set; }
        public int CountMessagesNotRead { get; set; }
    }
}