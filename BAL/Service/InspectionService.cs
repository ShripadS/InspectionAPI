using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class InspectionService
    {
        private readonly IRepository<Inspection> _inspection;
       

        public InspectionService(IRepository<Inspection> inspection)
        {
            _inspection = inspection;
            
        }
        //Get Inspection Details by Date
        public List<Inspection> GetInspectionsByDate(string InspectionDate)            
        {
            return _inspection.GetAll().Where(x => x.CreatedOn.Date == Convert.ToDateTime(InspectionDate).Date).ToList();
        }

        //Get all inspections
        public List<Inspection> GetAllInspections()
        {
            return _inspection.GetAll().ToList();
        }

        //Add Inspection 
        public async Task<Inspection> AddInspection(Inspection Inspection)
        {
            return await _inspection.Create(Inspection);
        }

        //Update inspection
        public bool UpdateInspection(Inspection Inspection)
        {
            try
            {
                _inspection.Update(Inspection);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Remove/Delete Inspection
        public bool DeleteInspection(int id)
        {

            try
            {
                var item = _inspection.GetAll().Where(x => x.Id == id).FirstOrDefault();
                _inspection.Delete(item);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Update inspection Date by ID
        public bool UpdateInspectionDate(int ID, string inspDate)
        {
            try
            {
                var item = _inspection.GetAll().Where(x => x.Id == ID).FirstOrDefault();
                item.InspectionDate = Convert.ToDateTime(inspDate);

                _inspection.Update(item);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        //Cancel inspection by ID
        public bool CancelInspection(int ID, bool IsCancelled)
        {
            try
            {
                var item = _inspection.GetAll().Where(x => x.Id == ID).FirstOrDefault();
                item.IsCancelled = IsCancelled;

                    item.IsCancelled = IsCancelled;
                    _inspection.Update(item);
                    return true;
               
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
