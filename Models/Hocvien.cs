using System.ComponentModel.DataAnnotations;
namespace QLDT_API.Models{
    public class Hocvien{
        [Key]
        [Required]
        public int? id { get; set; }
        public string? Ho { get; set; }
        public string? ten { get; set; }
        public string? maLop { get; set; }
        public string? hedaotaoId { get; set; }
        public string? nganhId { get; set; }
        public string? chuyenNganhId { get; set; }
        public string? KhoinganhId { get; set; }
        public string? namNhaphoc { get; set; }
        public string? KhoaHoc { get; set; }
        public string? Namhoc { get; set; }
        public string? ngaySinh { get; set; }
        public string? email { get; set; }

    }
}