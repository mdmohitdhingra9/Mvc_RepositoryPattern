using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Interfaces.Core;
using Architect.Interfaces;
using Architect.Models.Models;

namespace Application.Dal.Repositories
{
    public class DepartmentRepository : Repository<Deparment>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
