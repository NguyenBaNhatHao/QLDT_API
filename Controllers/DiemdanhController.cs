using QLDT_API.Data;
using QLDT_API.Dtos;
using QLDT_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;


namespace VidoWebApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemdanhController : ControllerBase{
        private readonly VidoWebDbContext _context;
        private readonly IMapper _mapper;

        public DiemdanhController(VidoWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // [HttpGet]
        // public ActionResult<DiemdanhReadDto> GetDiemdanh(DiemdanhSendDto diemdanhSendDto){
        //     var subscription = _mapper.Map<Diemdanh>(diemdanhSendDto);
        //     var Lop = new SqlParameter("@lop", subscription.Lop);
        //     var Monhoc = new SqlParameter("@monhoc", subscription.Monhoc);
        //     var Nguoitao = new SqlParameter("@nguoitao", subscription.Nguoitao);
        //     try{
        //         using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
        //         cmd.CommandText = "sp_api_diemdanh";
        //         cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //         if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
        //         cmd.Parameters.Add(new SqlParameter("@lop", subscription.Lop));
        //         cmd.Parameters.Add(new SqlParameter("@monhoc", subscription.Monhoc));
        //         cmd.Parameters.Add(new SqlParameter("@nguoitao", subscription.Nguoitao));

        //         cmd.ExecuteNonQuery();
        //         cmd.ExecuteScalar();
        //         using var reader = cmd.ExecuteReader();
        //         if(reader.HasRows)
        //         {
        //             while(reader.Read()){
        //                 for(int i=0; i<reader.FieldCount;i++){
        //                     var x = reader.GetName(i);
        //                     var y = reader.GetValue(i);
        //                     Console.WriteLine($"field {x}: "+y);
        //                     Console.WriteLine("------------");
        //                 }
                       
        //             }
        //         }
        //         cmd.Connection.Close();
        //         return Ok();
        //     }     
        //     }catch(Exception ex){
        //         return BadRequest(ex.Message);
        //     }                                                                                   
        //     return Ok();
        // }
        [HttpGet]
        public ActionResult<DiemdanhReadDto> GetDiemdanh(DiemdanhSendDto diemdanhSendDto){
            var subscription = _mapper.Map<Diemdanh>(diemdanhSendDto);
            string sql ="DECLARE @ngaytao NVARCHAR(MAX) ='' ,@sql     NVARCHAR(MAX) = '';SELECT @ngaytao += QUOTENAME(NgayTao) + ','FROM (select DISTINCT convert(varchar,tbl_QLDT_QLHV_DiemDanh.ngayTao,103) AS NgayTao from tbl_QLDT_QLHV_HocVien INNER JOIN tbl_QLDT_QLHV_DiemDanh ON tbl_QLDT_QLHV_HocVien.id = tbl_QLDT_QLHV_DiemDanh.hocVienId INNER JOIN tbl_QLDT_CTDT_HeDaoTao ON tbl_QLDT_QLHV_HocVien.heDaoTaoId = tbl_QLDT_CTDT_HeDaoTao.id INNER JOIN tbl_QLDT_TKB_LopMonHoc ON tbl_QLDT_QLHV_DiemDanh.lopMonHocId = tbl_QLDT_TKB_LopMonHoc.id INNER JOIN tbl_QLDT_TKB_LopMonHoc_KhoiNganh ON tbl_QLDT_QLHV_DiemDanh.lopMonHocId = tbl_QLDT_TKB_LopMonHoc_KhoiNganh.lopMonHocId INNER JOIN tbl_QLDT_CTDT_KhoiNganh ON tbl_QLDT_TKB_LopMonHoc_KhoiNganh.khoiNganhId = tbl_QLDT_CTDT_KhoiNganh.id INNER JOIN tbl_QLDT_CTDT_KhoiNganh_MonHoc ON tbl_QLDT_CTDT_KhoiNganh.id = tbl_QLDT_CTDT_KhoiNganh_MonHoc.khoiNganhId INNER JOIN tbl_QLDT_CTDT_MonHoc ON tbl_QLDT_CTDT_KhoiNganh_MonHoc.monHocId = tbl_QLDT_CTDT_MonHoc.id where tbl_QLDT_TKB_LopMonHoc.ma LIKE N'212_2TH104_13THC' AND tbl_QLDT_CTDT_MonHoc.ten LIKE N'%Anh văn 1%' and tbl_QLDT_QLHV_DiemDanh.nguoiTao LIKE N'%ctphu%' and tbl_QLDT_QLHV_DiemDanh.nguoiCapNhat LIKE N'%ctphu%') A SET @ngaytao = LEFT(@ngaytao, LEN(@ngaytao) - 1); SET @sql ='with diemdanh as (select DISTINCT tbl_QLDT_QLHV_HocVien.ho + tbl_QLDT_QLHV_HocVien.ten as Hoten, tbl_QLDT_QLHV_HocVien.mshv, tbl_QLDT_QLHV_HocVien.KhoaHoc,tbl_QLDT_TKB_LopMonHoc.ma as Lop,( select DISTINCT convert(varchar,tbl_QLDT_QLHV_HocVien.ngaySinh,103) as [DD/MM/YYYY]) as Ngaysinh,tbl_QLDT_CTDT_KhoiNganh.ten AS Khoinganh,tbl_QLDT_CTDT_MonHoc.ten as Monhoc,tbl_QLDT_CTDT_MonHoc.soTinChi,tbl_QLDT_CTDT_HeDaoTao.ten as he,tbl_QLDT_QLHV_DiemDanh.hienDienYN,  ( select DISTINCT convert(varchar,tbl_QLDT_QLHV_DiemDanh.ngayTao,103) as [DD/MM/YYYY]) as Ngaytao,tbl_QLDT_QLHV_DiemDanh.nguoiTao, tbl_QLDT_QLHV_DiemDanh.nguoiCapNhat from tbl_QLDT_QLHV_HocVien INNER JOIN tbl_QLDT_QLHV_DiemDanh ON tbl_QLDT_QLHV_HocVien.id = tbl_QLDT_QLHV_DiemDanh.hocVienId INNER JOIN tbl_QLDT_CTDT_HeDaoTao ON tbl_QLDT_QLHV_HocVien.heDaoTaoId = tbl_QLDT_CTDT_HeDaoTao.id INNER JOIN tbl_QLDT_TKB_LopMonHoc ON tbl_QLDT_QLHV_DiemDanh.lopMonHocId = tbl_QLDT_TKB_LopMonHoc.id INNER JOIN tbl_QLDT_TKB_LopMonHoc_KhoiNganh ON tbl_QLDT_QLHV_DiemDanh.lopMonHocId = tbl_QLDT_TKB_LopMonHoc_KhoiNganh.lopMonHocId INNER JOIN tbl_QLDT_CTDT_KhoiNganh ON tbl_QLDT_TKB_LopMonHoc_KhoiNganh.khoiNganhId = tbl_QLDT_CTDT_KhoiNganh.id INNER JOIN tbl_QLDT_CTDT_KhoiNganh_MonHoc ON tbl_QLDT_CTDT_KhoiNganh.id = tbl_QLDT_CTDT_KhoiNganh_MonHoc.khoiNganhId INNER JOIN tbl_QLDT_CTDT_MonHoc ON tbl_QLDT_CTDT_KhoiNganh_MonHoc.monHocId = tbl_QLDT_CTDT_MonHoc.id where tbl_QLDT_TKB_LopMonHoc.ma LIKE ''%'+@lop+'%'' AND tbl_QLDT_CTDT_MonHoc.ten LIKE N''%'+@monhoc+'%'' and tbl_QLDT_QLHV_DiemDanh.nguoiTao LIKE N''%'+@nguoitao+'%'' and tbl_QLDT_QLHV_DiemDanh.nguoiCapNhat LIKE N''%'+@nguoitao+'%'') select * from (SELECT Hoten,mshv,KhoaHoc,Lop,Ngaysinh,Khoinganh,Monhoc,soTinChi,he,ngayTao,nguoiTao,nguoiCapNhat, CAST(diemdanh.hienDienYN AS INT) AS INTColumn from diemdanh) as sourcetable PIVOT (MAX(INTColumn) for ngayTao in ('+@ngaytao+') ) as pvt for json auto'; EXECUTE sp_executesql @sql;";
            var Lop = new SqlParameter("@lop", subscription.Lop);
            var Monhoc = new SqlParameter("@monhoc", subscription.Monhoc);
            var Nguoitao = new SqlParameter("@nguoitao", subscription.Nguoitao);
            try{
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.Connection.Open();
                cmd.CommandText = sql;
                cmd.Parameters.Add(new SqlParameter("@lop", subscription.Lop));
                cmd.Parameters.Add(new SqlParameter("@monhoc", subscription.Monhoc));
                cmd.Parameters.Add(new SqlParameter("@nguoitao", subscription.Nguoitao));
                string data = (string)cmd.ExecuteScalar();
                Console.WriteLine(data);
                return Ok(data);
            }     
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }                                                                                   
            return Ok();
        }
    }
}