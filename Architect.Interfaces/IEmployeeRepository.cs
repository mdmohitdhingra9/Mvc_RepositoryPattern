using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Interfaces.Core;
using Architect.Models.Models;

namespace Architect.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
