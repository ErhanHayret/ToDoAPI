using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ToDoContext : DbContext
    {
        #region Constructors
        public ToDoContext()
        {

        }
        public ToDoContext(DbContextOptions<ToDoContext> option) : base(option)
        {

        }
        #endregion

        #region Properties
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ToDoModel> ToDos { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoModel>().HasKey(k => k.Id);
            builder.Entity<UserModel>().HasKey(k => k.Id);

            builder.Entity<ToDoModel>()
                .HasOne(e => e.User)
                .WithMany(e => e.ToDos)
                .HasForeignKey(k => k.UserId)
                .IsRequired(false);
            builder.Entity<ToDoModel>()
                .HasOne(e => e.CreatorUser)
                .WithMany(e => e.CreatedToDos)
                .HasForeignKey(e => e.CreatorId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
                builder.UseSqlServer(Environment.GetEnvironmentVariable("MSSQL_URI"));
        }
        #endregion
    }
}
