using Haskap.LayeredArchitecture.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.Core.Repositories;
using WorkflowEngine.Core.UnitOfWork;
using WorkflowEngine.DataAccessLayer.DbContexts;
using WorkflowEngine.DataAccessLayer.Repositories;

namespace WorkflowEngine.DataAccessLayer.UnitOfWorks
{
    public class WorkflowEngineUnitOfWork : BaseUnitOfWork<EfCoreOracleWorkflowEngineDbContext>, IWorkflowEngineUnitOfWork
    {
        private IBaseRepository<User> userRepository;
        public IBaseRepository<User> UserRepository 
        { 
            get
            {
                return this.userRepository ?? (this.userRepository = new BaseRepository<User>(this.dbContext));
            }
        }

        private IBaseRepository<WorkflowEngine.Core.Entities.Action> actionRepository;
        public IBaseRepository<Core.Entities.Action> ActionRepository 
        {
            get
            {
                return this.actionRepository ?? (this.actionRepository = new BaseRepository<Core.Entities.Action>(this.dbContext));
            }
        }

        private IBaseRepository<Path> pathRepository;
        public IBaseRepository<Path> PathRepository 
        {
            get
            {
                return this.pathRepository ?? (this.pathRepository = new BaseRepository<Path>(this.dbContext));
            }
        }

        private IBaseRepository<PathUser> pathUserRepository;
        public IBaseRepository<PathUser> PathUserRepository 
        {
            get
            {
                return this.pathUserRepository ?? (this.pathUserRepository = new BaseRepository<PathUser>(this.dbContext));
            }
        }

        private IBaseRepository<Process> processRepository;
        public IBaseRepository<Process> ProcessRepository 
        {
            get
            {
                return this.processRepository ?? (this.processRepository = new BaseRepository<Process>(this.dbContext));
            }
        }

        private IBaseRepository<ProcessAdmin> processAdminRepository;
        public IBaseRepository<ProcessAdmin> ProcessAdminRepository 
        {
            get
            {
                return this.processAdminRepository ?? (this.processAdminRepository = new BaseRepository<ProcessAdmin>(this.dbContext));
            }
        }

        private IBaseRepository<Progress> progressRepository;
        public IBaseRepository<Progress> ProgressRepository 
        {
            get
            {
                return this.progressRepository ?? (this.progressRepository = new BaseRepository<Progress>(this.dbContext));
            }
        }

        private IBaseRepository<Request> requestRepository;
        public IBaseRepository<Request> RequestRepository 
        {
            get
            {
                return this.requestRepository ?? (this.requestRepository = new BaseRepository<Request>(this.dbContext));
            }
        }

        private IBaseRepository<State> stateRepository;
        public IBaseRepository<State> StateRepository 
        {
            get
            {
                return this.stateRepository ?? (this.stateRepository = new BaseRepository<State>(this.dbContext));
            }
        }

        private IBaseRepository<StateUser> stateUserRepository;
        public IBaseRepository<StateUser> StateUserRepository 
        {
            get
            {
                return this.stateUserRepository ?? (this.stateUserRepository = new BaseRepository<StateUser>(this.dbContext));
            }
        }

        public WorkflowEngineUnitOfWork(EfCoreOracleWorkflowEngineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
