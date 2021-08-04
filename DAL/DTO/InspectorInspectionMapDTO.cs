using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class InspectorInspectionMapDTO
    {
        public int InspectionID { get; set; }
        public string Address { get; set; }

        public string Inspector { get; set; }

        public DateTime? InspectionDate { get; set; }
    }
}
