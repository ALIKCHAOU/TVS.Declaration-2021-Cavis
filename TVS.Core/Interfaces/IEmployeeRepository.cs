using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        int Create(Employee employee);

        void Update(Employee employee);

        void Delete(int empNo);

        Employee Get(int no);

        Employee Get(string cin, int societeNo);

        IEnumerable<Employee> GetAll(int societeNo);
    }
}