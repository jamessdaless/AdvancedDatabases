namespace FixturesDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FixturesDB : DbContext
    {
        public FixturesDB()
            : base("name=FixturesDB")
        {
        }

        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Fixture> Fixtures { get; set; }
        public virtual DbSet<Injury> Injuries { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<PlayerFixture> PlayerFixtures { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Referee> Referees { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition>()
                .Property(e => e.CompetitionName)
                .IsUnicode(false);

            modelBuilder.Entity<Competition>()
                .HasMany(e => e.Fixtures)
                .WithRequired(e => e.Competition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fixture>()
                .HasMany(e => e.PlayerFixtures)
                .WithRequired(e => e.Fixture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Injury>()
                .Property(e => e.InjuryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Injury>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Injury)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.ManagerName)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Manager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nationality>()
                .Property(e => e.Nationality1)
                .IsUnicode(false);

            modelBuilder.Entity<Nationality>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Nationality)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.PlayerName)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.PlayerSquadNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerFixtures)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PositionName)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Referee>()
                .Property(e => e.RefereeName)
                .IsUnicode(false);

            modelBuilder.Entity<Referee>()
                .HasMany(e => e.Fixtures)
                .WithRequired(e => e.Referee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stadium>()
                .Property(e => e.StadiumName)
                .IsUnicode(false);

            modelBuilder.Entity<Stadium>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Stadium)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.TeamName)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}
