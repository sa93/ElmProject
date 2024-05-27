using Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System;

namespace Infrastructure.Models
{
    public partial class DbDataContext : DbContext
    {
        public DbDataContext()
        {
        }

        public DbDataContext(DbContextOptions<DbDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<SchemaVersion> SchemaVersions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ElmTestDb;integrated security=true;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasIndex(e => e.LastModified, "IX_Book_LastModified");
            });

            modelBuilder.Entity<SchemaVersion>(entity =>
            {
                entity.Property(e => e.Applied).HasColumnType("datetime");

                entity.Property(e => e.ScriptName).HasMaxLength(255);
            });

            modelBuilder.Entity<Book>().Property(e => e.BookInfo).HasConversion(bookInfo =>
                                                      JsonConvert.SerializeObject(bookInfo, new JsonSerializerSettings
                                                      {
                                                          NullValueHandling = NullValueHandling.Ignore
                                                      }),
                                                      bookInfo => bookInfo != null ?
                                                      JsonConvert.DeserializeObject<BookInfoDto>(bookInfo) : new BookInfoDto());

           
            modelBuilder.HasDbFunction(typeof(DbDataContext).GetMethod(nameof(JsonValue))!).HasName("JSON_VALUE").IsBuiltIn();

            OnModelCreatingPartial(modelBuilder);
        }

        public string JsonValue(string column, [NotParameterized] string path) => throw new NotSupportedException();

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
