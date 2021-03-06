// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WarcraftApi.Context;

namespace WarcraftApi.Migrations
{
    [DbContext(typeof(DBcontext))]
    [Migration("20210830202100_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WarcraftApi.Entities.IncomeTick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("TickIntervall")
                        .HasColumnType("integer");

                    b.Property<DateTime>("lastIncomeTick")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("IncomeTick");
                });

            modelBuilder.Entity("WarcraftApi.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Cash")
                        .HasColumnType("integer");

                    b.Property<int>("Income")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<int>("SoldierIncome")
                        .HasColumnType("integer");

                    b.Property<int>("Soldiers")
                        .HasColumnType("integer");

                    b.Property<int>("ownedTerritories")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("WarcraftApi.Entities.Scout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DoneScouting")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("OwnedById")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnedById");

                    b.ToTable("Scout");
                });

            modelBuilder.Entity("WarcraftApi.Entities.SpyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ActionPlayerId")
                        .HasColumnType("integer");

                    b.Property<int?>("TargetedPlayerId")
                        .HasColumnType("integer");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ActionPlayerId");

                    b.HasIndex("TargetedPlayerId");

                    b.HasIndex("TerritoryId");

                    b.ToTable("SpyReport");
                });

            modelBuilder.Entity("WarcraftApi.Entities.Tile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Defence")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("VillageLvl")
                        .HasColumnType("integer");

                    b.Property<int>("WallLvl")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Tile");
                });

            modelBuilder.Entity("WarcraftApi.Entities.Scout", b =>
                {
                    b.HasOne("WarcraftApi.Entities.Player", "OwnedBy")
                        .WithMany()
                        .HasForeignKey("OwnedById");

                    b.Navigation("OwnedBy");
                });

            modelBuilder.Entity("WarcraftApi.Entities.SpyReport", b =>
                {
                    b.HasOne("WarcraftApi.Entities.Player", "ActionPlayer")
                        .WithMany()
                        .HasForeignKey("ActionPlayerId");

                    b.HasOne("WarcraftApi.Entities.Player", "TargetedPlayer")
                        .WithMany()
                        .HasForeignKey("TargetedPlayerId");

                    b.HasOne("WarcraftApi.Entities.Tile", "Territory")
                        .WithMany()
                        .HasForeignKey("TerritoryId");

                    b.Navigation("ActionPlayer");

                    b.Navigation("TargetedPlayer");

                    b.Navigation("Territory");
                });

            modelBuilder.Entity("WarcraftApi.Entities.Tile", b =>
                {
                    b.HasOne("WarcraftApi.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
