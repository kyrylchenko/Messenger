namespace Messenger.DAL.EFContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserFriend")]
    public partial class UserFriend
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FriendId { get; set; }

        public bool? IsConfirmedFrend { get; set; }

        public bool? IsBlocked { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
