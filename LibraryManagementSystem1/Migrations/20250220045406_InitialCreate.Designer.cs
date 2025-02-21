﻿// <auto-generated />
using System;
using LibraryManagementSystem1.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem1.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20250220045406_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibrayManagementSystem1.model.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsEbook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.BookRecord", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<string>("BookStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BorrowedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LibrarianId")
                        .HasColumnType("int");

                    b.Property<int>("MappingId")
                        .HasColumnType("int");

                    b.Property<int>("MemberBookMappingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("LibrarianId");

                    b.HasIndex("MemberBookMappingId");

                    b.ToTable("BookRecords");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.Ebook", b =>
                {
                    b.Property<int>("EbookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EbookId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("FileFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.HasKey("EbookId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Ebooks");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.LibrarianInfo", b =>
                {
                    b.Property<int>("LibrarianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibrarianId"));

                    b.Property<string>("LibrarianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibrarianId");

                    b.ToTable("Librarians");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.MemberBook", b =>
                {
                    b.Property<int>("MappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MappingId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("MappingId");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberBooks");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.BookRecord", b =>
                {
                    b.HasOne("LibrayManagementSystem1.model.LibrarianInfo", "Librarian")
                        .WithMany("BookRecords")
                        .HasForeignKey("LibrarianId");

                    b.HasOne("LibrayManagementSystem1.model.MemberBook", "MemberBook")
                        .WithMany()
                        .HasForeignKey("MemberBookMappingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Librarian");

                    b.Navigation("MemberBook");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.Ebook", b =>
                {
                    b.HasOne("LibrayManagementSystem1.model.Book", "Book")
                        .WithOne("Ebook")
                        .HasForeignKey("LibrayManagementSystem1.model.Ebook", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.MemberBook", b =>
                {
                    b.HasOne("LibrayManagementSystem1.model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibrayManagementSystem1.model.Member", "Member")
                        .WithMany("MemberBooks")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.Book", b =>
                {
                    b.Navigation("Ebook")
                        .IsRequired();
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.LibrarianInfo", b =>
                {
                    b.Navigation("BookRecords");
                });

            modelBuilder.Entity("LibrayManagementSystem1.model.Member", b =>
                {
                    b.Navigation("MemberBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
