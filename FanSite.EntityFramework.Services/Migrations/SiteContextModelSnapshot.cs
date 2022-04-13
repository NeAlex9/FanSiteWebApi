﻿// <auto-generated />
using System;
using FanSiteService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FanSite.EntityFramework.Services.Migrations
{
    [DbContext(typeof(SiteContext))]
    partial class SiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FanSite.EntityFramework.Services.Entities.MediaDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("md_id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("md_description")
                        .HasColumnOrder(4);

                    b.Property<bool>("IsUpcoming")
                        .HasColumnType("bit")
                        .HasColumnName("md_is_upcoming")
                        .HasColumnOrder(6);

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("md_publication_date")
                        .HasColumnOrder(3);

                    b.Property<double>("Rating")
                        .HasColumnType("float")
                        .HasColumnName("md_rating")
                        .HasColumnOrder(5);

                    b.Property<byte>("SeriesId")
                        .HasColumnType("tinyint")
                        .HasColumnName("md_series_id")
                        .HasColumnOrder(8);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("md_title")
                        .HasColumnOrder(2);

                    b.Property<byte>("TypeId")
                        .HasColumnType("tinyint")
                        .HasColumnName("md_type")
                        .HasColumnOrder(7);

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SeriesId" }, "IX_series_id");

                    b.HasIndex(new[] { "TypeId" }, "IX_type_id");

                    b.ToTable("media");
                });

            modelBuilder.Entity("FanSite.EntityFramework.Services.Entities.MediaTypeDto", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("mt_id")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("mt_name")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("media_type");
                });

            modelBuilder.Entity("FanSiteService.Entities.CommentDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cm_id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MediaId")
                        .HasColumnType("int")
                        .HasColumnName("cm_media_id")
                        .HasColumnOrder(4);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("cm_user_id")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("cm_publication_date")
                        .HasColumnOrder(3);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("cm_text")
                        .HasColumnOrder(2);

                    b.HasKey("Id", "MediaId", "UserId");

                    b.HasIndex(new[] { "Id" }, "IX_id");

                    b.HasIndex(new[] { "MediaId" }, "IX_media_id");

                    b.HasIndex(new[] { "UserId" }, "IX_user_id");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("FanSiteService.Entities.MediaSeriesDto", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("ms_id")
                        .HasColumnOrder(1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("ms_title")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("media_series");
                });

            modelBuilder.Entity("FanSiteService.Entities.RoleDto", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("rl_id")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("rl_name")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("FanSiteService.Entities.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("us_id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("us_email")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("us_name")
                        .HasColumnOrder(2);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("us_password")
                        .HasColumnOrder(3);

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint")
                        .HasColumnName("us_role")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_email");

                    b.HasIndex(new[] { "RoleId" }, "IX_role_id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("FanSite.EntityFramework.Services.Entities.MediaDto", b =>
                {
                    b.HasOne("FanSiteService.Entities.MediaSeriesDto", "Series")
                        .WithMany("MediaCollection")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanSite.EntityFramework.Services.Entities.MediaTypeDto", "Type")
                        .WithMany("Media")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("FanSiteService.Entities.CommentDto", b =>
                {
                    b.HasOne("FanSite.EntityFramework.Services.Entities.MediaDto", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanSiteService.Entities.UserDto", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanSiteService.Entities.UserDto", b =>
                {
                    b.HasOne("FanSiteService.Entities.RoleDto", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FanSite.EntityFramework.Services.Entities.MediaTypeDto", b =>
                {
                    b.Navigation("Media");
                });

            modelBuilder.Entity("FanSiteService.Entities.MediaSeriesDto", b =>
                {
                    b.Navigation("MediaCollection");
                });

            modelBuilder.Entity("FanSiteService.Entities.RoleDto", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}