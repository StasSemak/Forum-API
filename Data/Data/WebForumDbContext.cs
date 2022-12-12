using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class WebForumDbContext : IdentityDbContext<User>
    {
        public WebForumDbContext(DbContextOptions options) : base(options) { }
        public WebForumDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Question>().HasMany(x => x.Replies)
                                      .WithOne(x => x.Question)
                                      .HasForeignKey(x => x.QuestionId);
            builder.Entity<User>().HasMany(x => x.Questions)
                                  .WithOne(x => x.User)
                                  .HasForeignKey(x => x.UserId);
            builder.Entity<User>().HasMany(x => x.Replies)
                                  .WithOne(x => x.User)
                                  .HasForeignKey(x => x.UserId);
            builder.Entity<Topic>().HasMany(x => x.Questions)
                                   .WithOne(x => x.Topic)
                                   .HasForeignKey(x => x.TopicId);

            builder.Entity<User>().Property(x => x.Id)
                                  .ValueGeneratedOnAdd();

            builder.Entity<Topic>().HasData(MockData.GetTopics());
        }

        public DbSet<Reply> Replies { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}