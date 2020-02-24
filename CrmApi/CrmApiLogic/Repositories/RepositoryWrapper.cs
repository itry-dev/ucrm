using System.Threading.Tasks;
using CrmApiLogic.Interfaces;

namespace CrmApiLogic.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _dbContext;
        private IProjectRepository _projectRepository;
        private ICustomerRepository _customerRepository;
        private IWorkedHoursRepository _workedHoursRepository;


        public RepositoryWrapper(DataContext dataContext)
        {
            _dbContext = dataContext;
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

        /*
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
        */
    }
}
