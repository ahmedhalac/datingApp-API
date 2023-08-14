﻿using System;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<User, MemberDto>()
			.ForMember(dest => dest.PhotoUrl,
			opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.isMain).Url));
		CreateMap<Photo, PhotoDto>();
	}
}
