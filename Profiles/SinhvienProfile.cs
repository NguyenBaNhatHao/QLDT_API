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
            .ForMember(dest=>dest.SoTinchi,act=>act.MapFrom(src=>src.SoTinchi))
            .ForMember(dest=>dest.KhoaHoc,act=>act.MapFrom(src=>src.KhoaHoc))
            .ForMember(dest=>dest.Namhoc,act=>act.MapFrom(src=>src.Namhoc))
            .ForMember(dest=>dest.nguoiCapNhat,act=>act.MapFrom(src=>src.nguoiCapNhat))
            .ForMember(dest=>dest.nguoiTao,act=>act.MapFrom(src=>src.nguoiTao));
            CreateMap<Diemdanh,DiemdanhReadDto>();
        }
    }
}