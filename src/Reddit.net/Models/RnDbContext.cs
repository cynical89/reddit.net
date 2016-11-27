using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Reddit.net.Models
{
    public class RnDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<SubnetModel> Subnets { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<VoteModel> Votes { get; set; }
        public RnDbContext(DbContextOptions<RnDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=CYNICAL-PC\SQLEXPRESS;Database=redditnet;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
        }
        public RnDbContext()
        {

        }
    }
}
