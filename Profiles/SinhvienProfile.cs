using AutoMapper;
using QLDT_API.Dtos;
using QLDT_API.Models;

namespace VidoWebApi.Profiles{
    public class SinhvienProfile : Profile{
        public SinhvienProfile(){
            CreateMap<DiemdanhSendDto,Diemdanh>()
            .ForMember(dest=>dest.id,act=>act.MapFrom(src=>src.id))
            .ForMember(dest=>dest.Hoten,act=>act.MapFrom(src=>src.Hoten))
            .ForMember(dest=>dest.Mssv,act=>act.MapFrom(src=>src.Mssv))
            .ForMember(dest=>dest.Ngaydiemdanh,act=>act.MapFrom(src=>src.Ngaydiemdanh))
            .ForMember(dest=>dest.Ngaysinh,act=>act.MapFrom(src=>src.Ngaysinh))
            .ForMember(dest=>dest.Nganh,act=>act.MapFrom(src=>src.Nganh))
            .ForMember(dest=>dest.Hedaotao,act=>act.MapFrom(src=>src.Hedaotao))
            .ForMember(dest=>dest.Monhoc,act=>act.MapFrom(src=>src.Monhoc))
            .ForMember(dest=>dest.Lop,act=>act.MapFrom(src=>src.Lop))
            .ForMember(dest=>dest.SoTC,act=>act.MapFrom(src=>src.SoTC))
            .ForMember(dest=>dest.Khoa,act=>act.MapFrom(src=>src.Khoa))
            .ForMember(dest=>dest.Namhoc,act=>act.MapFrom(src=>src.Namhoc))
            .ForMember(dest=>dest.Nguoicapnhat,act=>act.MapFrom(src=>src.Nguoicapnhat))
            .ForMember(dest=>dest.Nguoitao,act=>act.MapFrom(src=>src.Nguoitao));
            CreateMap<Diemdanh,DiemdanhReadDto>();
        }
    }
}