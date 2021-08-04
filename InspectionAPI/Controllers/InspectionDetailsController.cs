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
    public class InspectionDetailsController : ControllerBase
    {
        private readonly InspectionService _inspectionService;
        private readonly LogService _logs;

        private readonly IRepository<Inspection> _Inspection;

        public InspectionDetailsController(IRepository<Inspection> Inspection, InspectionService InspectionService, LogService log)
        {
            _inspectionService = InspectionService;
            _Inspection = Inspection;
            _logs = log;
        }

        //Add Inspector JSON
        [HttpPost("AddInspection")]
        public async Task<Object> AddInspection([FromBody] Inspection inspection)
        {
            try
            {
                await _inspectionService.AddInspection(inspection);
                return true;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return false;
            }
        }

        //Add inspection with seperate values
        [HttpPost("AddInspectionNew")]
        public async Task<Object> AddInspectionNew(string InspectionDate, string address, int inspectorID)
        {
            try
            {
                Inspection insp = new Inspection();
                insp.InspectorID = inspectorID;
                insp.Address = address;
                insp.InspectionDate = Convert.ToDateTime(InspectionDate);
                await _inspectionService.AddInspection(insp);
                return true;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return false;
            }
        }


        // Update Inspection
        [HttpPut("UpdateInspection")]
        public bool UpdateInspection(Inspection Object)
        {
            try
            {
                _inspectionService.UpdateInspection(Object);

                return true;
            }
            catch (Exception ex)
            {
                _logs.AddLog(ex.Message + " Trace: " + ex.StackTrace);
                return false;
            }
        }

        //GET Inspection By Date
        [HttpGet("GetInspectionByDate")]
        public Object GetInspectionByDate(string Date)
        {
            try
            {
                var data = _inspectionService.GetInspectionsByDate(Date);
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

        //Update inspection Date
        [HttpGet ("UpdateInspectionDate")]       
        public string UpdateInspectionDate(int ID,string Date)
        {
            try
            {
                string data = string.Empty;
                var res = _inspectionService.UpdateInspectionDate(ID, Date);
                if (res == true)
                {
                    data = "Date Updated successfully";
                }
                else
                {
                    data = "Date not updated successfully";
                }
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


        //Cancel Inspection

        [HttpGet("CancelInspection")]
        public string CancelInspection(int ID, bool IsCancelled)
        {
            try
            {
                string data = string.Empty;
                var res = _inspectionService.CancelInspection(ID, IsCancelled);
                if (res == true)
                {
                    data = "Inspection updated successfully";
                }
                else
                {
                    data = "Inspection  not updated";
                }
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
