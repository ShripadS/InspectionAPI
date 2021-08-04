using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryLog
    {
        ApplicationDbContext _dbContext;
        public RepositoryLog(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public void Create(string message)
        {
            Log objLog = new Log();
            objLog.LogMessage = message;
            var obj =  _dbContext.Logs.AddAsync(objLog);
            _dbContext.SaveChanges();
           
        }

        public IEnumerable<Log> GetAll()
        {
            try
            {
                return _dbContext.Logs.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
