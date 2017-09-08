using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Interfaces.Business.Processors;
using Architect.Models.Models;
using Application.Dal;
using Architect.Interfaces.Core;

namespace Architect.BAL.Processors
{
    public class DepartmentProcessor : IDepartmentProcessor
    {
        private readonly ApplicationDbContext _context;
        
        //private readonly IUnitofWork unitofwork;
        public DepartmentProcessor(ApplicationDbContext context)
        {
            this._context = context;
            //this.unitofwork = unitofwork;
        }
        public void Add(Architect.Models.Models.Deparment entity)
        {
            try
            {
                using (var uow = new UnitofWork(_context))
                {
                    uow.Department.Add(entity);
                    uow.Save();
                }

            }
            catch (Exception ex)
            {
                // log
            }
        }

        public void AddRange(IEnumerable<Architect.Models.Models.Deparment> entities)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Department.AddRange(entities);
                uow.Save();
            }
        }

        public void Delete(Architect.Models.Models.Deparment entity)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Department.Delete(entity);
                uow.Save();
            }
        }

        public void Delete(object id)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Department.Delete(id);
                uow.Save();
            }
        }

        public Architect.Models.Models.Deparment Get(object id)
        {
            Deparment dept = null;
            using (var uow = new UnitofWork(_context))
            {
                dept = uow.Department.Get(id);
                uow.Save();
            }
            return dept;
        }

        public IEnumerable<Architect.Models.Models.Deparment> Get(System.Linq.Expressions.Expression<Func<Architect.Models.Models.Deparment, bool>> predicate)
        {
            List<Deparment> depts = null;
            using (var uow = new UnitofWork(_context))
            {
                depts = uow.Department.Get(predicate).ToList();
                uow.Save();

            }
            return depts;
        }

        public IEnumerable<Architect.Models.Models.Deparment> GetAll()
        {
            List<Deparment> depts = null;
            using (var uow = new UnitofWork(_context))
            {
                depts = uow.Department.GetAll().ToList();
                uow.Save();

            }
            return depts;
        }

        public void Update(Architect.Models.Models.Deparment entity)
        {
            using (var uow = new UnitofWork(_context))
            {
                uow.Department.Update(entity);
                uow.Save();

            }
        }
    }
}
