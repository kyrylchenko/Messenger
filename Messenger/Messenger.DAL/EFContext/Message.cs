namespace Messenger.DAL.EFContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int MessageId { get; set; }

        [Required]
        [StringLength(30)]
        public string MessageType { get; set; }

        public int SenderId { get; set; }

        public int ChatId { get; set; }

        public DateTime SendTime { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public int? FileId { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsSent { get; set; }

        public bool? IsDelivered { get; set; }

        public bool? IsRed { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual File File { get; set; }

        public virtual User User { get; set; }
    }
}
