using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace QLDT_API.Dtos{
    public class DiemdanhSendDto{
        [Key]
        public int id { get; set; }
        public string? Hoten { get; set; }
        public string? Ngaysinh { get; set; }
        public string? Ngaydiemdanh { get; set; }
        public string? Mssv { get; set; }
        public string? Nganh { get; set; }
        public string? Hedaotao { get; set; }
        public string? Monhoc { get; set; }
        public string? Lop { get; set; }
        public string? SoTC { get; set; }
        public string? Khoa { get; set; }
        public string? Namhoc { get; set; }
        public string? Giangvien { get; set; }
        public string? Nguoitao { get; set; }
        public string? Nguoicapnhat { get; set; }

    }
}