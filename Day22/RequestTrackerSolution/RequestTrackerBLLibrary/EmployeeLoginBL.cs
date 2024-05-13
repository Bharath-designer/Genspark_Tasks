using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRequestRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<Employee> Login(int id, string password)
        {
           
           var emp = await _repository.Get(id);
            if (emp != null)
            {
                if (emp.Password == password)
                    return emp;
            }
            return null;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }
    }
}
