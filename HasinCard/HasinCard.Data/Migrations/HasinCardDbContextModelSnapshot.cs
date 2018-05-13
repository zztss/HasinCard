﻿// <auto-generated />
using HasinCard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HasinCard.Data.Migrations
{
    [DbContext(typeof(HasinCardDbContext))]
    partial class HasinCardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("HasinCard.Core.Domain.SysUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("QQ")
                        .HasMaxLength(15);

                    b.Property<string>("TelNo")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("SysUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
