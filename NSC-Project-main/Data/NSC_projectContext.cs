using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSC_project.Models;

namespace NSC_project.Data
{
    public class NSC_projectContext : DbContext
    {
        public NSC_projectContext(DbContextOptions<NSC_projectContext> options)
            : base(options)
        {
        }

        public DbSet<NSC_project.Models.Movie> Movie { get; set; } = default!;
        public DbSet<NSC_project.Models.User> User { get; set; } = default!;

        public DbSet<NSC_project.Models.Theater> Theater { get; set; } = default!;
        public DbSet<NSC_project.Models.TheaterAddress> TheaterAddress { get; set; } = default!;

        public DbSet<NSC_project.Models.Auditorium> Auditorium { get; set; } = default!;

        public DbSet<NSC_project.Models.Screening> Screening { get; set; } = default!;

        public DbSet<NSC_project.Models.Seat> Seat { get; set; } = default!;

        public DbSet<NSC_project.Models.Reservetion> Reservetion { get; set; } = default!;

        public DbSet<NSC_project.Models.ReservedSeat> ReservedSeat { get; set; } = default!;


     /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NSC_project.Data;Trusted_Connection=True;MultipleActiveResultSets=true");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.ToTable("Auditorium");

                entity.HasIndex(e => e.TheaterId, "NSC_Auditorium_TheaterId");

                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Seats_no).HasMaxLength(500);
                entity.Property(e => e.Seats).HasMaxLength(100);

                entity.HasOne(d => d.Theater).WithMany(p => p.Auditoriums).HasForeignKey(d => d.TheaterId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Director).HasMaxLength(100);
                entity.Property(e => e.Opening_date).HasMaxLength(50);
                entity.Property(e => e.Genre).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<ReservedSeat>(entity =>
            {
                entity.HasIndex(e => e.ScreeningId, "NSC_ReservedSeat_ScreeningId");

                entity.HasIndex(e => e.SeatId, "NSC_ReservedSeat_SeatId");

                entity.HasIndex(e => e.ReservetionId, "NSC_ReservedSeat_ReservetionId");

                entity.HasOne(d => d.Screening).WithMany(p => p.ReservedSeats).HasForeignKey(d => d.ScreeningId);

                entity.HasOne(d => d.Seat).WithMany(p => p.ReservedSeats).HasForeignKey(d => d.SeatId);

                entity.HasOne(d => d.Reservetion).WithMany(p => p.ReservedSeats).HasForeignKey(d => d.ReservetionId);


            });

            modelBuilder.Entity<Reservetion>(entity =>
            {
                entity.ToTable("Reservetion");
                entity.HasIndex(e => e.UserId, "NSC_Reservetion_UserId");
                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.User).WithMany(p => p.Reservetions).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.ToTable("Screening");

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.HasIndex(e => e.AuditoriumId, "NSC_Screening_AuditoriumId");

                entity.HasIndex(e => e.MovieId, "NSC_ReservedSeat_MovieId");

                entity.HasOne(d => d.Auditorium).WithMany(p => p.Screenings).HasForeignKey(d => d.AuditoriumId);

                entity.HasOne(d => d.Movie).WithMany(p => p.Screenings).HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");
                entity.Property(e => e.Number).HasMaxLength(50);
            });
            modelBuilder.Entity<Theater>(entity =>
            {
                entity.ToTable("Theater");
                entity.Property(e => e.TheaterAddressId).HasColumnName("TheaterAddressId");
                entity.Property(e => e.Location).HasMaxLength(50);
            });
            modelBuilder.Entity<TheaterAddress>(entity =>
            {
                entity.ToTable("TheaterAddress");
                entity.Property(e => e.Address).HasMaxLength(50);

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });
           *//* OnModelCreatingPartial(modelBuilder);*//*
        }*/
   /*     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
