using DAL.Data;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryInspector : IRepository<Inspector>
    {
        ApplicationDbContext _dbContext;
        public RepositoryInspector(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Inspector> Create(Inspector _object)
        {
            var obj = await _dbContext.Inspectors.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Inspector _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Inspector> GetAll()
        {
            try
            {
                return _dbContext.Inspectors.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Inspector GetById(int Id)
        {
            return _dbContext.Inspectors.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Inspector _object)
        {
            _dbContext.Inspectors.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
