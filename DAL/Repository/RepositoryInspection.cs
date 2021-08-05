using DAL.Data;
using DAL.DTO;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryInspection : IRepository<Inspection>
    {
        ApplicationDbContext _dbContext;
        public RepositoryInspection(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Inspection> Create(Inspection _object)
        {
            var obj = await _dbContext.Inspections.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Inspection _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Inspection> GetAll()
        {
            try
            {
                return _dbContext.Inspections.Include(r=>r.Inspector).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Inspection GetById(int Id)
        {
            return _dbContext.Inspections.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Inspection _object)
        {
            _dbContext.Inspections.Update(_object);
            _dbContext.SaveChanges();
        }

        public List<InspectorInspectionMapDTO> GetInspectionWithInspector()
        {
            try
            {
                return _dbContext.Inspections.Join(_dbContext.Inspectors, u => u.InspectorID, x => x.Id, (u, x) => new { u, x }).Select(m => new InspectorInspectionMapDTO
                {
                    InspectionID = m.u.Id,
                    InspectionDate = m.u.InspectionDate,
                    Address = m.u.Address,
                    Inspector = m.x.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
