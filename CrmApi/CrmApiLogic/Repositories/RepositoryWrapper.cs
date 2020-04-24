using System.Threading.Tasks;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models;
using Microsoft.AspNetCore.Identity;

namespace CrmApiLogic.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _dbContext;
        private IProjectRepository _projectRepository;
        private ICustomerRepository _customerRepository;
        private IWorkedHoursRepository _workedHoursRepository;
        private IUserRepository _userRepository;

        private readonly UserManager<ApplicationUser> _userMng;

        public RepositoryWrapper(DataContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dataContext;
            _userMng = userManager;
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new ProjectsRepository(_dbContext);
                }

                return _projectRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_dbContext);
                }

                return _customerRepository;
            }
        }

        public IWorkedHoursRepository WorkedHoursRepository
        {
            get
            {
                if (_workedHoursRepository == null)
                {
                    _workedHoursRepository = new WorkedHoursRepository(_dbContext);
                }

                return _workedHoursRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext, _userMng);
                }

                return _userRepository;
            }
        }

    }
}
