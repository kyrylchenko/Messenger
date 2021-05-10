namespace Messenger.DAL.EFContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChatUser")]
    public partial class ChatUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChatId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IsCreator { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsAdmin { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual User User { get; set; }
    }
}
