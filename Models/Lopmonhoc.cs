using System.ComponentModel.DataAnnotations;
namespace QLDT_API.Models{
    public class Lopmonhoc{
        [Key]
        [Required]
        public int id {get; set;}
        public string? ma {get; set;}
    }
}