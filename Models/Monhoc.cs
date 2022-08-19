using System.ComponentModel.DataAnnotations;
namespace QLDT_API.Models{
    public class Monhoc{
        [Key]
        [Required]
        public int id {get; set;}
        public string? ten {get; set;}
        public string? maMonHoc {get; set;}
    }
}