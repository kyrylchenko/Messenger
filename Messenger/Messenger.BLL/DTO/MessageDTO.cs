using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Messenger.BLL.DTO
{
    public enum MessageType
    { 
        Text,
        Video,
        VideoWithText,
        PhotoWithText,
        Audio,
    }

    public class MessageDTO
    {
        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }

        public int SenderId { get; set; }

        public int ChatId { get; set; }

        public DateTime SendTime { get; set; }

        public string Text { get; set; }

        public int? FileId { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsSent { get; set; }

        public bool? IsDelivered { get; set; }

        public bool? IsRed { get; set; }

    }
}
