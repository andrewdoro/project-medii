﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace auction_house.Migrations
{
    [DbContext(typeof(AuctionHouseContext))]
    [Migration("20240114184804_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("AuctionHouse.Models.AuctionEvent", b =>
                {
                    b.Property<int>("AuctionEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AuctionEventId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionEvent");
                });

            modelBuilder.Entity("AuctionHouse.Models.Bid", b =>
                {
                    b.Property<int>("BidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BidTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BidId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("AuctionHouse.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuctionEventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemId");

                    b.HasIndex("AuctionEventId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("AuctionHouse.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AuctionHouse.Models.AuctionEvent", b =>
                {
                    b.HasOne("AuctionHouse.Models.User", "User")
                        .WithMany("AuctionEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuctionHouse.Models.Bid", b =>
                {
                    b.HasOne("AuctionHouse.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionHouse.Models.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuctionHouse.Models.Item", b =>
                {
                    b.HasOne("AuctionHouse.Models.AuctionEvent", "AuctionEvent")
                        .WithMany("Items")
                        .HasForeignKey("AuctionEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionEvent");
                });

            modelBuilder.Entity("AuctionHouse.Models.AuctionEvent", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("AuctionHouse.Models.User", b =>
                {
                    b.Navigation("AuctionEvents");

                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
