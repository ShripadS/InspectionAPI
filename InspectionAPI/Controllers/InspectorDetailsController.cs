using BAL.Service;
using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorDetailsController : ControllerBase
    {
        private readonly InspectorService _inspectorService;
        private readonly LogService _logs;

        private readonly IRepository<Inspector> _Inspector;

        public InspectorDetailsController(IRepository<Inspector> Inspector, InspectorService InspectorService, LogService log)
        {
            _inspectorService = InspectorService;
            _Inspector = Inspector;
            _logs = log;
        }

        //Add Inspector
        [HttpPost("AddInspector")]
        public async Task<Object> AddInspector([FromBody] Inspector inspector)
        {
            try
            {
                await _inspectorService.AddInspector(inspector);
                return true;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return false;
            }
        }

        //Delete Inspector  
        [HttpDelete("DeleteInspector")]  
        public bool DeleteInspector(int id)  
        {  
            try  
            {
                _inspectorService.DeleteInspector(id);  
                return true;  
            }  
            catch (Exception ex)  
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return false;  
            }  
        }
        // Update Inspector
        [HttpPut("UpdateInspector")]
        public bool UpdateInspector(Inspector Object)
        {
            try
            {
                _inspectorService.UpdateInspector(Object);
                return true;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return false;
            }
        }

        //GET Inspector By Name  
        [HttpGet("GetInspectorByName")]
        public Object GetInspectorByName(string Name)
        {
            try
            {
                var data = _inspectorService.GetInspectorByName(Name);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return null;
            }
        }

        //GET All Inspector  
        [HttpGet("GetAllInspector")]
        public Object GetAllInspector()
        {
            try
            {
                var data = _inspectorService.GetAllInspectors();
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return null;
            }
        }


        //Get all Inspector without Inspection
        [HttpGet("GetAllInspectorWithoutInspection")]
        public Object GetInspectorsWithoutInspection(string date)
        {
            try
            {
                var data = _inspectorService.GetInspectorsWithoutInspection(date);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                return json;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return null;
            }
        }
    }
}
