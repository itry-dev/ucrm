using System;
using System.Threading.Tasks;

namespace CrmApiLogic.Interfaces
{
    public interface IRepositoryWrapper
    {
        IProjectRepository ProjectRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IWorkedHoursRepository WorkedHoursRepository { get; }
        //Task Save();
    }
}
