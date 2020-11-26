using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Employee;

namespace DDD.Domain.Interface.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employees> Get();
        void Post(Employees employees);
    }
}