using System.ComponentModel.DataAnnotations;
namespace QLDT_API.Models{
    public class Diemdanh{
        
        public int? id { get; set; }
        public string? Hoten { get; set; }
        public string? Ngaysinh { get; set; }
        public string? Ngaydiemdanh { get; set; }
        public string? Mssv { get; set; }
        public string? Nganh { get; set; }
        public string? Hedaotao { get; set; }
        public string? Monhoc { get; set; }
        public string? Lop { get; set; }
        public int? SoTinchi { get; set; }
        public string? KhoaHoc { get; set; }
        public string? Namhoc { get; set; }
        public string? nguoiTao { get; set; }
        public string? nguoiCapNhat { get; set; }

    }
}