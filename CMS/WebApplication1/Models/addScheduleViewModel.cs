using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class addScheduleViewModel
    {
        [Required]
        [Display(Name = "ContainerID")]
        public string containerid { get; set; }
        [Required]
        [Display(Name = "ContainerInDate")]
        public string containerindate { get; set; }
        [Required]
        [Display(Name = "ContainerOutDate")]
        public string containeroutdate { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public string weight { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public string destination { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime deliver_date { get; set; }
    }
}