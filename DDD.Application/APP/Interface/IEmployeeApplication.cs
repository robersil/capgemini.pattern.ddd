using DDD.Application.ViewModel;
using System.Collections.Generic;

namespace DDD.Application.APP.Interface
{
    public interface IEmployeeApplication
    {
        List<EmployeeListViewModel> Get();
        void Post(EmployeeCreateViewModel employee);
    }
}
