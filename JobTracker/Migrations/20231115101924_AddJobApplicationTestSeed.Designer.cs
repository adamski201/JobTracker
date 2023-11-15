﻿// <auto-generated />
using System;
using JobTracker.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobTracker.Migrations
{
    [DbContext(typeof(JobTrackerContext))]
    [Migration("20231115101924_AddJobApplicationTestSeed")]
    partial class AddJobApplicationTestSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("JobTracker.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Industry")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test Description",
                            Industry = "Test Industry",
                            Name = "Test Company"
                        });
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobApplicationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("JobApplicationId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            JobTitle = "Test Job"
                        });
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InitialApplicationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InitialDateAdvertised")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("JobApplications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deadline = new DateTime(2023, 11, 20, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3800),
                            InitialApplicationDate = new DateTime(2023, 11, 15, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3797),
                            InitialDateAdvertised = new DateTime(2023, 11, 10, 10, 19, 23, 783, DateTimeKind.Local).AddTicks(3755),
                            JobId = 1,
                            Status = 1
                        });
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.Company", b =>
                {
                    b.OwnsOne("JobTracker.Domain.Entities.Location", "Location", b1 =>
                        {
                            b1.Property<int>("CompanyId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .HasColumnType("TEXT");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Company");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");

                            b1.HasData(
                                new
                                {
                                    CompanyId = 1,
                                    City = "Test City",
                                    Country = "UK"
                                });
                        });

                    b.Navigation("Location");
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.Interview", b =>
                {
                    b.HasOne("JobTracker.Domain.Entities.JobApplication", "JobApplication")
                        .WithMany("Interviews")
                        .HasForeignKey("JobApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobApplication");
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.Job", b =>
                {
                    b.HasOne("JobTracker.Domain.Entities.Company", "Company")
                        .WithMany("Job")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("JobTracker.Domain.Entities.Location", "Location", b1 =>
                        {
                            b1.Property<int>("JobId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .HasColumnType("TEXT");

                            b1.HasKey("JobId");

                            b1.ToTable("Jobs");

                            b1.WithOwner()
                                .HasForeignKey("JobId");

                            b1.HasData(
                                new
                                {
                                    JobId = 1,
                                    City = "Test City",
                                    Country = "UK"
                                });
                        });

                    b.OwnsOne("JobTracker.Domain.Entities.Salary", "Salary", b1 =>
                        {
                            b1.Property<int>("JobId")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Currency")
                                .HasColumnType("INTEGER");

                            b1.HasKey("JobId");

                            b1.ToTable("Jobs");

                            b1.WithOwner()
                                .HasForeignKey("JobId");

                            b1.HasData(
                                new
                                {
                                    JobId = 1,
                                    Amount = 20.0m,
                                    Currency = 0
                                });
                        });

                    b.Navigation("Company");

                    b.Navigation("Location");

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.JobApplication", b =>
                {
                    b.HasOne("JobTracker.Domain.Entities.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.Company", b =>
                {
                    b.Navigation("Job");
                });

            modelBuilder.Entity("JobTracker.Domain.Entities.JobApplication", b =>
                {
                    b.Navigation("Interviews");
                });
#pragma warning restore 612, 618
        }
    }
}
