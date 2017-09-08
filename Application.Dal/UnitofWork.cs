using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Interfaces;
using Architect.Interfaces.Core;
using Architect.Models.Models;
using Application.Dal.Repositories;

namespace Application.Dal
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Department = new DepartmentRepository(context);
            Employee = new EmployeeRepository(context);
        }
        public IDepartmentRepository Department { get; }
        public IEmployeeRepository Employee { get; }

        public void Dispose()
        {
            //this.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
