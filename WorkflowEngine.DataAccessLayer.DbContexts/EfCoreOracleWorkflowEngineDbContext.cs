using Haskap.LayeredArchitecture.DataAccessLayer.DbContexts.OraclelDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.DataAccessLayer.DbContexts.Configurations;

namespace WorkflowEngine.DataAccessLayer.DbContexts
{
    public class EfCoreOracleWorkflowEngineDbContext : BaseEfCoreOracleDbContext
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

        public EfCoreOracleWorkflowEngineDbContext(DbContextOptions<EfCoreOracleWorkflowEngineDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProcessConfiguration());
            builder.ApplyConfiguration(new PathConfiguration());
            builder.ApplyConfiguration(new ProgressConfiguration());
            builder.ApplyConfiguration(new RequestConfiguration());
            builder.ApplyConfiguration(new PathUserConfiguration());
            builder.ApplyConfiguration(new StateUserConfiguration());
            builder.ApplyConfiguration(new ProcessAdminConfiguration());
        }
    }
}
