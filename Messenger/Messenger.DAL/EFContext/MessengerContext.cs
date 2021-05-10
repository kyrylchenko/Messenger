using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Messenger.DAL.EFContext
{
    public partial class MessengerContext : DbContext
    {
        public MessengerContext()
            : base("name=MessengerContext")
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFriend> UserFriends { get; set; }
        public virtual DbSet<ChatUser> ChatUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(e => e.ChatUsers)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chat>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Chat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<File>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.File)
                .HasForeignKey(e => e.Photo);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ChatUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserFriends)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserFriends1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
