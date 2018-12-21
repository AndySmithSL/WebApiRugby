using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiRugby.Models
{
    public partial class RugbyContext : DbContext
    {
        public RugbyContext()
        {
        }

        public RugbyContext(DbContextOptions<RugbyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Competition> Competition { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchLineUp> MatchLineUp { get; set; }
        public virtual DbSet<MatchOfficial> MatchOfficial { get; set; }
        public virtual DbSet<MatchPoints> MatchPoints { get; set; }
        public virtual DbSet<MatchPosition> MatchPosition { get; set; }
        public virtual DbSet<MatchTeam> MatchTeam { get; set; }
        public virtual DbSet<Official> Official { get; set; }
        public virtual DbSet<PenaltyTry> PenaltyTry { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PointType> PointType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SchoolType> SchoolType { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<SeasonPoints> SeasonPoints { get; set; }
        public virtual DbSet<Stadium> Stadium { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamCountry> TeamCountry { get; set; }
        public virtual DbSet<TeamPlayer> TeamPlayer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Rugby;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegionId).HasDefaultValueSql("((3))");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_City");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Coach_Country");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coach_Team");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.FlagUrl).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(300);

                entity.Property(e => e.HighestPointName).HasMaxLength(300);

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Resolution).HasMaxLength(20);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.CompetitionId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SeasonId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Competition");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Season");

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.StadiumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Stadium");
            });

            modelBuilder.Entity<MatchLineUp>(entity =>
            {
                entity.HasOne(d => d.MatchPosition)
                    .WithMany(p => p.MatchLineUp)
                    .HasForeignKey(d => d.MatchPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchLineUp_MatchPosition");

                entity.HasOne(d => d.MatchTeam)
                    .WithMany(p => p.MatchLineUp)
                    .HasForeignKey(d => d.MatchTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchLineUp_MatchTeam");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.MatchLineUp)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_MatchLineUp_Player");
            });

            modelBuilder.Entity<MatchOfficial>(entity =>
            {
                entity.Property(e => e.Tvofficial).HasColumnName("TVOfficial");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchOfficial)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchOfficial_Match");

                entity.HasOne(d => d.RefereeNavigation)
                    .WithMany(p => p.MatchOfficialRefereeNavigation)
                    .HasForeignKey(d => d.Referee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchOfficial_Official");

                entity.HasOne(d => d.TouchJudge1Navigation)
                    .WithMany(p => p.MatchOfficialTouchJudge1Navigation)
                    .HasForeignKey(d => d.TouchJudge1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchOfficial_Official1");

                entity.HasOne(d => d.TouchJudge2Navigation)
                    .WithMany(p => p.MatchOfficialTouchJudge2Navigation)
                    .HasForeignKey(d => d.TouchJudge2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchOfficial_Official2");

                entity.HasOne(d => d.TvofficialNavigation)
                    .WithMany(p => p.MatchOfficialTvofficialNavigation)
                    .HasForeignKey(d => d.Tvofficial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchOfficial_Official3");
            });

            modelBuilder.Entity<MatchPoints>(entity =>
            {
                entity.HasKey(e => e.MatchPointId);

                entity.HasOne(d => d.MatchLineUp)
                    .WithMany(p => p.MatchPoints)
                    .HasForeignKey(d => d.MatchLineUpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchPoints_MatchLineUp");

                entity.HasOne(d => d.PointType)
                    .WithMany(p => p.MatchPoints)
                    .HasForeignKey(d => d.PointTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchPoints_PointType");
            });

            modelBuilder.Entity<MatchPosition>(entity =>
            {
                entity.Property(e => e.IsBack)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsForward)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSubstitute)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Number).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.MatchPosition)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchPosition_Position");
            });

            modelBuilder.Entity<MatchTeam>(entity =>
            {
                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchTeam)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchTeam_Match");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.MatchTeam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchTeam_Team");
            });

            modelBuilder.Entity<Official>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(10);
            });

            modelBuilder.Entity<PenaltyTry>(entity =>
            {
                entity.HasOne(d => d.MatchTeam)
                    .WithMany(p => p.PenaltyTry)
                    .HasForeignKey(d => d.MatchTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PenaltyTry_MatchTeam");

                entity.HasOne(d => d.PointType)
                    .WithMany(p => p.PenaltyTry)
                    .HasForeignKey(d => d.PointTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PenaltyTry_PointType");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.CityId).HasDefaultValueSql("((167))");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfDeath).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('x')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PositionId).HasDefaultValueSql("((1))");

                entity.Property(e => e.SchoolId).HasDefaultValueSql("((3))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Player_City");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Position");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_Player_Player");
            });

            modelBuilder.Entity<PointType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_Country");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_City1");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_SchoolType");
            });

            modelBuilder.Entity<SchoolType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SeasonPoints>(entity =>
            {
                entity.HasKey(e => e.SeasonPointId);

                entity.HasOne(d => d.PointType)
                    .WithMany(p => p.SeasonPoints)
                    .HasForeignKey(d => d.PointTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonPoints_PointType");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.SeasonPoints)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonPoints_Season");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Stadium)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stadium_City");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.BadgeUrl).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NickName).HasMaxLength(20);

                entity.Property(e => e.SmallName)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<TeamCountry>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TeamCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamCountry_Country");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamCountry)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamCountry_Team");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TeamPlayer)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamPlayer_Player");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamPlayer)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamPlayer_Team");
            });
        }
    }
}
