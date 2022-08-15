using QLDT_API.Data;
using QLDT_API.Dtos;
using QLDT_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
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
        [HttpGet]
        public ActionResult<DiemdanhReadDto> GetDiemdanh(DiemdanhSendDto diemdanhSendDto){
            var subscription = _mapper.Map<Diemdanh>(diemdanhSendDto);
            var Lop = new SqlParameter("@lop", subscription.Lop);
            var Monhoc = new SqlParameter("@monhoc", subscription.Monhoc);
            var Nguoitao = new SqlParameter("@nguoitao", subscription.nguoiTao);
            try{
                using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
                cmd.CommandText = "sp_api_diemdanh";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@lop", subscription.Lop));
                cmd.Parameters.Add(new SqlParameter("@monhoc", subscription.Monhoc));
                cmd.Parameters.Add(new SqlParameter("@nguoitao", subscription.nguoiTao));

                var data = cmd.ExecuteScalar();
                return Ok(data);
            }     
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }                                                                                   
        }
        
    }
}