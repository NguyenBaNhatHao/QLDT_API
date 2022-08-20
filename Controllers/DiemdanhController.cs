using QLDT_API.Data;
using QLDT_API.Dtos;
using QLDT_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
        [HttpPost]
        public ActionResult<DiemdanhReadDto> GetDiemdanh(DiemdanhSendDto diemdanhSendDto){
            var subscription = _mapper.Map<Diemdanh>(diemdanhSendDto);
            var Lop = new SqlParameter("@lop", subscription.Lop);
            try{
                var jsonResult = new StringBuilder();
                var data = new StringBuilder(); 
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "sp_api_diemdanh";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(Lop);
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        data = jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
                return Ok(data.ToString().Replace("\\",""));
            }     
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }                                                                                   
        }
        [HttpPost("header")]
        public ActionResult<DiemdanhReadDto> GetHeaderdiemdanh(DiemdanhSendDto diemdanhSendDto){
            var subscription = _mapper.Map<Diemdanh>(diemdanhSendDto);
            var Lop = new SqlParameter("@lop", subscription.Lop);
            try{
                var jsonResult = new StringBuilder();
                var data = new StringBuilder(); 
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "sp_api_diemdanh_header";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(Lop);
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        data = jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
                
                return Ok(data.ToString().Replace("\\",""));
            }     
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }                                                                                   
        }
        [HttpGet("lop")]
        public ActionResult<List<Lopmonhoc>> GetLop(){
            var query = from ma in _context.tbl_QLDT_TKB_LopMonHoc orderby ma.ma select ma; 
            var dataQuery = query.ToList();
            return dataQuery;
        }
<<<<<<< HEAD
        [HttpGet("monhoc")]
        public ActionResult<List<Monhoc>> Getmonhoc(){ 
            var query = from ten in _context.tbl_QLDT_CTDT_MonHoc select ten; 
            var dataQuery = query.ToList();
            return dataQuery;
        }
        [HttpGet("nguoitao")]
        public ActionResult<List<NguoitaoReadDTO>> Getnguoitao(){ 
            try{
                var jsonResult = new StringBuilder();
                var data = new StringBuilder(); 
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "sp_api_diemdanh_nguoitao";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        data = jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
                return Ok(data.ToString().Replace("\\",""));
            }     
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("khoahoc")]
        public ActionResult<List<NguoitaoReadDTO>> Getkhoahoc(){ 
            try{
                var jsonResult = new StringBuilder();
                var data = new StringBuilder(); 
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "sp_api_diemdanh_khoahoc";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        data = jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
                return Ok(data.ToString().Replace("\\",""));
            }     
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
 
=======
               
>>>>>>> 2da6f0f8014618bec205ccc1cde51fdd468b7a73
    }
}