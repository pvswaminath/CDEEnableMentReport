using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{   
    [Table("AssociateCourseDetails")]
    public class AssociateCourseDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Associate Id is required")]
        public string AssociateID { get; set; }

        [Required(ErrorMessage = "Associate Name is required")]
        [StringLength(60, ErrorMessage = "Associate Name can't be longer than 60 characters")]
        public string AssociateName { get; set; }
        public string Course { get; set; }
        public string Stack { get; set; }
        public string Training_Vendor { get; set; }
        public string Recommendation { get; set; }
        public string Reporting_Status { get; set; }
        public string Grade2 { get; set; }
        public string Level_Description { get; set; }
        public string DepartmentDescription { get; set; }
        public string DepartmentGroup { get; set; }
        public string Classification { get; set; }
        public string HorizontalName { get; set; }
        public string VerticalName { get; set; }
    }
}
