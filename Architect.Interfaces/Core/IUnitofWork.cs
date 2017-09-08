using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Interfaces.Core
{
    public interface IUnitofWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
