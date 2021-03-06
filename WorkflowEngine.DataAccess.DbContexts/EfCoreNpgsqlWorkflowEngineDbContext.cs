﻿using Haskap.LayeredArchitecture.DataAccess.DbContexts.NpgsqlDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.DataAccess.DbContexts.Configurations;

namespace WorkflowEngine.DataAccess.DbContexts
{
    public class EfCoreNpgsqlWorkflowEngineDbContext : BaseEfCoreNpgsqlDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Core.Entities.Action> Action { get; set; }
        public DbSet<Path> Path { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<PathUser> PathUser { get; set; }
        public DbSet<StateUser> StateUser { get; set; }
        public DbSet<ProcessAdmin> ProcessAdmin { get; set; }
        public DbSet<NotificationContentTemplate> NotificationContentTemplate { get; set; }
        public DbSet<SmsNotificationTemplate> SmsNotificationTemplate { get; set; }
        public DbSet<EmailNotificationTemplate> EmailNotificationTemplate { get; set; }

        public EfCoreNpgsqlWorkflowEngineDbContext(DbContextOptions<EfCoreNpgsqlWorkflowEngineDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StateConfiguration());
            builder.ApplyConfiguration(new ActionConfiguration());
            builder.ApplyConfiguration(new ProcessConfiguration());
            builder.ApplyConfiguration(new PathConfiguration());
            builder.ApplyConfiguration(new ProgressConfiguration());
            builder.ApplyConfiguration(new RequestConfiguration());
            builder.ApplyConfiguration(new PathUserConfiguration());
            builder.ApplyConfiguration(new StateUserConfiguration());
            builder.ApplyConfiguration(new ProcessAdminConfiguration());
            builder.ApplyConfiguration(new NotificationContentTemplateConfiguration());
            builder.ApplyConfiguration(new SmsNotificationTemplateConfiguration());
            builder.ApplyConfiguration(new EmailNotificationTemplateConfiguration());
        }
    }
}
