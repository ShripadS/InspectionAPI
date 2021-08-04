using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("Inspections", Schema = "dbo")]
    public class Inspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required]
        [ForeignKey("Inspector")]
        [Display(Name = "Inspector ID")]
        public int InspectorID { get; set; }
     

        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        
        [Display(Name = "Is Inspection Cancelled")]
        public bool IsCancelled { get; set; }

        
        [Display(Name = "Inspection Date")]
        public DateTime? InspectionDate { get; set; } 
    }
}
