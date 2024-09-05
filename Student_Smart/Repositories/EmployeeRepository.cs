using Database;
using Database.Model;
using Repositories.BaseRepository;

namespace Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {

    }
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(WebApiContext context) : base(context)
        {

        }
    }
}
