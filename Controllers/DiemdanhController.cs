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
using NReco.PivotData;
using System.Dynamic;
using System.Collections.Specialized;

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
            List<String> ListData = new List<String>();
            try{
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                var ListDiemdanh = new List<OrderedDictionary>();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "sp_api_diemdanh";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(Lop);
                var reader = cmd.ExecuteReader();
                while(reader.Read()){
                    var dictionary = new OrderedDictionary();
                    for(int i = 0; i < reader.FieldCount; i++){
                        if(reader[i] == DBNull.Value){
                            dictionary.Add(reader.GetName(i),"0");
                        }else{
                            dictionary.Add(reader.GetName(i),reader[i].ToString());
                        }
                    }
                    ListDiemdanh.Add(dictionary);
                }
                return Ok(ListDiemdanh);
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
    }
}