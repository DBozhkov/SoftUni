namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(entity =>
            {
                entity.HasOne(s => s.Album)
                    .WithMany(al => al.Songs)
                    .HasForeignKey(s => s.AlbumId);

                entity.HasOne(s => s.Writer)
                    .WithMany(wr => wr.Songs)
                    .HasForeignKey(s => s.WriterId);
            });

            builder.Entity<Album>(entity =>
            {
                entity.HasOne(al => al.Producer)
                    .WithMany(pr => pr.Albums)
                    .HasForeignKey(al => al.ProducerId);
            });

            builder.Entity<Writer>(ent =>
            {
                ent.Property(p => p.Name)
                    .IsRequired(true)
                    .HasMaxLength(20);                            
            });

            builder.Entity<SongPerformer>(entity =>
            {
                entity
                .HasKey(x => new { x.SongId, x.PerformerId });

                entity.HasOne(sp => sp.Performer)
                    .WithMany(pe => pe.PerformerSongs)
                    .HasForeignKey(sp => sp.PerformerId);

                entity.HasOne(sp => sp.Song)
                    .WithMany(so => so.SongPerformers)
                    .HasForeignKey(sp => sp.SongId);
            });
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }
    }
}
