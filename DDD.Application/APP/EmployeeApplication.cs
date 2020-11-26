using DDD.Application.APP.Interface;
using DDD.Application.ViewModel;
using DDD.Domain.Employee;
using DDD.Domain.Interface.EmployeeRepository;
using System.Collections.Generic;

namespace DDD.Application.APP
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeApplication(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<EmployeeListViewModel> Get()
        {
            var employees = _employeeRepository.Get();

            var listEmployees = new List<EmployeeListViewModel>();

            foreach (var item in employees)
            {
                listEmployees.Add(new EmployeeListViewModel()
                {
                    Name = item.Name,
                    LastName = item.LastName,
                    Position = item.Position
                });
            }

            return listEmployees;
        }

        public void Post(EmployeeCreateViewModel employee)
        {
            var employees = new Employees(employee.Name, employee.LastName, employee.Position);

            _employeeRepository.Post(employees);
        }
    }
}
