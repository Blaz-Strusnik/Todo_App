using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Todo_App.Models
{
    public class Tasks_Dto
    {
        public long Id { get; set; }
        public string? Task { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:d.M.yyyy HH:mm}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:d.M.yyyy HH:mm}")]
        public DateTime EndDate { get; set; }
        public string? Ref_User_name { get; set; }
    }
}
