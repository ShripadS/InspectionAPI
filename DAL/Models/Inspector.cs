using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    [Table("Inspectors", Schema = "dbo")]
    public class Inspector
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;

        
    }
}
