﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WorkflowEngine.DataAccess.DbContexts;

namespace WorkflowEngine.DataAccess.DbContexts.Migrations
{
    [DbContext(typeof(EfCoreOracleWorkflowEngineDbContext))]
    partial class EfCoreOracleWorkflowEngineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid?>("ActionTypeId")
                        .HasColumnName("ACTION_TYPE_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("CodeName")
                        .HasColumnName("CODE_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid?>("ProcessId")
                        .HasColumnName("PROCESS_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("ProcessId");

                    b.ToTable("ACTION");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.ActionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("ACTION_TYPE");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.EmailNotificationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("BccAddresses")
                        .HasColumnName("BCC_ADDRESSES")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CcAddresses")
                        .HasColumnName("CC_ADDRESSES")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid>("ContentId")
                        .HasColumnName("CONTENT_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Subject")
                        .HasColumnName("SUBJECT")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ToAddresses")
                        .HasColumnName("TO_ADDRESSES")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("ContentId")
                        .IsUnique();

                    b.ToTable("EMAIL_NOTIFICATION_TEMPLATE");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.NotificationContentTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Content")
                        .HasColumnName("CONTENT")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("NOTIFICATION_CONTENT_TEMPLATE");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Path", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("ActionId")
                        .HasColumnName("ACTION_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("FromStateId")
                        .HasColumnName("FROM_STATE_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("ToStateId")
                        .HasColumnName("TO_STATE_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("FromStateId");

                    b.HasIndex("ToStateId");

                    b.ToTable("PATH");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.PathUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("PathId")
                        .HasColumnName("PATH_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("UserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.HasIndex("UserId");

                    b.ToTable("PATH_USER");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("PROCESS");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.ProcessAdmin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("AdminId")
                        .HasColumnName("ADMIN_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("ProcessId")
                        .HasColumnName("PROCESS_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ProcessId");

                    b.ToTable("PROCESS_ADMIN");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Progress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Message")
                        .HasColumnName("MESSAGE")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid?>("PathId")
                        .HasColumnName("PATH_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("ProgressDate")
                        .HasColumnName("PROGRESS_DATE")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<Guid?>("ProgressedById")
                        .HasColumnName("PROGRESSED_BY_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("RequestId")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.HasIndex("ProgressedById");

                    b.HasIndex("RequestId");

                    b.ToTable("PROGRESS");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid?>("CurrentStateId")
                        .HasColumnName("CURRENT_STATE_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid?>("ProcessId")
                        .HasColumnName("PROCESS_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnName("REQUEST_DATE")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<Guid>("RequestedById")
                        .HasColumnName("REQUESTED_BY_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Title")
                        .HasColumnName("TITLE")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStateId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("RequestedById");

                    b.ToTable("REQUEST");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.RequestData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("RequestId")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("REQUEST_DATA");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.SmsNotificationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("ContentId")
                        .HasColumnName("CONTENT_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("GsmNumbers")
                        .HasColumnName("GSM_NUMBERS")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Header")
                        .HasColumnName("HEADER")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IS_ACTIVE")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("Id");

                    b.HasIndex("ContentId")
                        .IsUnique();

                    b.ToTable("SMS_NOTIFICATION_TEMPLATE");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("CodeName")
                        .HasColumnName("CODE_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PartialViewName")
                        .HasColumnName("PARTIAL_VIEW_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<Guid?>("ProcessId")
                        .HasColumnName("PROCESS_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid?>("StateTypeId")
                        .HasColumnName("STATE_TYPE_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.HasIndex("StateTypeId");

                    b.ToTable("STATE");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.StateType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("STATE_TYPE");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.StateUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("StateId")
                        .HasColumnName("STATE_ID")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("UserId")
                        .HasColumnName("USER_ID")
                        .HasColumnType("RAW(16)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("STATE_USER");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("FirstName")
                        .HasColumnName("FIRST_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LastName")
                        .HasColumnName("LAST_NAME")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Action", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.ActionType", "ActionType")
                        .WithMany("Actions")
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WorkflowEngine.Core.Entities.Process", "Process")
                        .WithMany("Actions")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.EmailNotificationTemplate", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.NotificationContentTemplate", "Content")
                        .WithOne("EmailNotificationTemplate")
                        .HasForeignKey("WorkflowEngine.Core.Entities.EmailNotificationTemplate", "ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Path", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.Action", "Action")
                        .WithMany("Paths")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkflowEngine.Core.Entities.State", "FromState")
                        .WithMany("FromPaths")
                        .HasForeignKey("FromStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkflowEngine.Core.Entities.State", "ToState")
                        .WithMany("ToPaths")
                        .HasForeignKey("ToStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.PathUser", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.Path", "Path")
                        .WithMany("PathUsers")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkflowEngine.Core.Entities.User", "User")
                        .WithMany("PathUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.ProcessAdmin", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.User", "Admin")
                        .WithMany("ProcessAdmins")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkflowEngine.Core.Entities.Process", "Process")
                        .WithMany("ProcessAdmins")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Progress", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.Path", "Path")
                        .WithMany("Progress")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WorkflowEngine.Core.Entities.User", "ProgressedBy")
                        .WithMany("Progress")
                        .HasForeignKey("ProgressedById")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WorkflowEngine.Core.Entities.Request", "Request")
                        .WithMany("Progress")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.Request", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.State", "CurrentState")
                        .WithMany("Requests")
                        .HasForeignKey("CurrentStateId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WorkflowEngine.Core.Entities.Process", "Process")
                        .WithMany("Requests")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WorkflowEngine.Core.Entities.User", "RequestedBy")
                        .WithMany("Requests")
                        .HasForeignKey("RequestedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.RequestData", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.Request", "Request")
                        .WithOne("Data")
                        .HasForeignKey("WorkflowEngine.Core.Entities.RequestData", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.SmsNotificationTemplate", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.NotificationContentTemplate", "Content")
                        .WithOne("SmsNotificationTemplate")
                        .HasForeignKey("WorkflowEngine.Core.Entities.SmsNotificationTemplate", "ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.State", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.Process", "Process")
                        .WithMany("States")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WorkflowEngine.Core.Entities.StateType", "StateType")
                        .WithMany("States")
                        .HasForeignKey("StateTypeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WorkflowEngine.Core.Entities.StateUser", b =>
                {
                    b.HasOne("WorkflowEngine.Core.Entities.State", "State")
                        .WithMany("StateUsers")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkflowEngine.Core.Entities.User", "User")
                        .WithMany("StateUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
