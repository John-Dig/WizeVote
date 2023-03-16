﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vote.Models;

#nullable disable

namespace Vote.Migrations
{
    [DbContext(typeof(VoteContext))]
    [Migration("20230316174828_withJoinEntities")]
    partial class withJoinEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Vote.Models.Choice", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<int>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("ChoiceId");

                    b.HasIndex("TopicId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("Vote.Models.ChoiceUser", b =>
                {
                    b.Property<int>("ChoiceUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChoiceUserId");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("UserId");

                    b.ToTable("ChoiceUsers");
                });

            modelBuilder.Entity("Vote.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Vote.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vote.Models.Choice", b =>
                {
                    b.HasOne("Vote.Models.Topic", null)
                        .WithMany("Choices")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vote.Models.ChoiceUser", b =>
                {
                    b.HasOne("Vote.Models.Choice", "Choice")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vote.Models.User", "User")
                        .WithMany("JoinEntities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Choice");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vote.Models.Choice", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("Vote.Models.Topic", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("Vote.Models.User", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
