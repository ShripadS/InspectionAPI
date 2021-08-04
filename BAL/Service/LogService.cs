using DAL.Interface;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.Service
{
    public class LogService
    {

        private readonly RepositoryLog _log;

        public LogService(RepositoryLog log)
        {
            _log = log;
        }

        //Add Log
        public void AddLog(string message)
        {
            _log.Create(message);
        }

        //Get All Logs
        public List<Log> GetAllLogs()
        {
            return _log.GetAll().ToList();
        }
    }
}
