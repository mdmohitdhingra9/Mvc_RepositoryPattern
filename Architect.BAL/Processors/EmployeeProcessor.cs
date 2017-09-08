using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Architect.Interfaces.Business.Processors;
using Architect.Models.Models;
using Application.Dal;

namespace Architect.BAL.Processors
{
    public class EmployeeProcessor : IEmployeeProcessor
    {
        private readonly ApplicationDbContext _context;
        public EmployeeProcessor(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Add(Employee entity)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Employee.Add(entity);
                uow.Save();
            }
        }

        public void AddRange(IEnumerable<Employee> entities)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Employee.AddRange(entities);
                uow.Save();
            }
        }

        public void Delete(Employee entity)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Employee.Delete(entity);
                uow.Save();
            }
        }

        public void Delete(object id)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Employee.Delete(id);
                uow.Save();
            }
        }

        public Employee Get(object id)
        {
            Employee emp;
            using (var uow = new UnitofWork(_context))
            {
                emp = uow.Employee.Get(id);
                //uow.Save();
            }
            return emp;
        }

        public IEnumerable<Employee> Get(Expression<Func<Employee, bool>> predicate)
        {
            List<Employee> emplist;
            using (var uow = new UnitofWork(_context))
            {
                emplist = uow.Employee.Get(predicate).ToList();
            }
            return emplist;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> emplist;
            using (var uow = new UnitofWork(_context))
            {
                emplist = uow.Employee.GetAll().ToList();
            }
            return emplist;
        }

        public void Update(Employee entity)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Employee.Update(entity);
                uow.Save();
            }
        }
    }
}
