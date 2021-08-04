using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{

    public class InspectorService
    {
        private readonly IRepository<Inspector> _inspector;
        private readonly InspectionService _inspectionService;

        public InspectorService(IRepository<Inspector> inspector, InspectionService InspectionService)
        {
            _inspector = inspector;
            _inspectionService = InspectionService;
        }
        //Get Inspector Detail by ID
        public IEnumerable<Inspector> GetInspectorByUserId(string Id)
        {
            return _inspector.GetAll().Where(x => x.Id == Convert.ToInt32(Id)).ToList();
        }
        //GET All Inspector Details  
        public IEnumerable<Inspector> GetAllInspectors()
        {
            try
            {
                return _inspector.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Inspetor By Name 
        public Inspector GetInspectorByName(string UserName)
        {
            return _inspector.GetAll().Where(x => x.Name == UserName).FirstOrDefault();
        }
        //Add Inspector  
        public async Task<Inspector> AddInspector(Inspector Inspector)
        {
            return await _inspector.Create(Inspector);
        }
        //Delete Inspector   
        public bool DeleteInspector(int id)
        {

            try
            {
                var item = _inspector.GetAll().Where(x => x.Id == id).FirstOrDefault();
                _inspector.Delete(item);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //Update Inspector Details  
        public bool UpdateInspector(Inspector inspector)
        {
            try
            {
                _inspector.Update(inspector);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Get Inspector Without Inspection
        public List<Inspector> GetInspectorsWithoutInspection(string date)
        {

            List<Inspection> inspList = _inspectionService.GetAllInspections();

            return _inspector.GetAll().Where(x => !inspList.Any(i=>i.InspectorID==x.Id && i.CreatedOn.Date==Convert.ToDateTime(date).Date)).ToList();
        }
    }
}
