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

        [HttpGet]
        public ActionResult<DiemdanhReadDto> GetDiemdanh(DiemdanhSendDto diemdanhSendDto){
            var subscription = _mapper.Map<Diemdanh>(diemdanhSendDto);
            try
            {
                var Lop = new SqlParameter("@lop", subscription.Lop);
                var Monhoc = new SqlParameter("@monhoc", subscription.Monhoc);
                var Nguoitao = new SqlParameter("@nguoitao", subscription.Nguoitao);

                _context.Database.ExecuteSqlRaw("sp_api_diemdanh @lop={0}, @monhoc={1}, @nguoitao={2}",parameters: new [] {Lop.Value,Monhoc.Value,Nguoitao.Value});
                _context.SaveChanges();                                                                                                       
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
    }
}