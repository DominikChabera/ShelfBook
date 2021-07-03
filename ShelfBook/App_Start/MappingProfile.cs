using AutoMapper;
using ShelfBook.Dtos;
using ShelfBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfBook.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Book, BookDto>().ReverseMap();
            Mapper.CreateMap<Author, AuthorDto>().ReverseMap();
            Mapper.CreateMap<Genre, GenreDto>().ReverseMap();
            Mapper.CreateMap<Image, ImageDto>().ReverseMap();
            Mapper.CreateMap<Price, PriceDto>().ReverseMap();
            Mapper.CreateMap<PublishingHouse, PublishingHouseDto>().ReverseMap();
        }
    }
}