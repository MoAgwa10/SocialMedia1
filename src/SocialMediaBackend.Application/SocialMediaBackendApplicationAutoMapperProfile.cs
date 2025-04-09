using System.Collections.Generic;
using System;
using AutoMapper;
using Bdaya.SocialTraining.V1;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.AutoMapper;
using SocialMediaBackend.SocialMedia;
using AutoMapper.Configuration.Annotations;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace SocialMediaBackend;

public class SocialMediaBackendApplicationAutoMapperProfile : Profile
{
    public SocialMediaBackendApplicationAutoMapperProfile()
    {

        CreateMap<Volo.Abp.Identity.IdentityUser, UserInfo>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
           .Ignore(dest => dest.ImageUrl);





        CreateMap<Posts, Post>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .Ignore(dest => dest.Date)
          .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
          .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
          .ForMember(dest => dest.Review, opt => opt.MapFrom(src => src.Review))
          .ForMember(dest => dest.Stats, opt => opt.MapFrom(src => src.Status))
          .ForMemberWithItemEntry(x => x.User, nameof(Volo.Abp.Identity.IdentityUser),
          (Posts src, IReadOnlyDictionary<Guid, Volo.Abp.Identity.IdentityUser> usersDict)
          => usersDict.GetValueOrDefaultBetter(src.CreatorId)
          );

        //ForMemberWithItemEntry is the right method 
        //i downloaded Bdaya.AutoMapper package to use this method     




        CreateMap<PostRevieww, PostReview>()
            .ForMember(dest => dest.ReviewedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ReviewDetails, opt => opt.MapFrom(src => src.ReviewDetails))
            .ForMember(dest => dest.ReviewedBy, opt => opt.MapFrom(src => src.ReviewedBy))
            .Ignore(dest => dest.Status);


        CreateMap< Images, AppImage>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            .Ignore(dest => dest.TakenDateTime);

        CreateMap< PostStatus, PostStats>()
             .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
              .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
               .ForMember(dest => dest.Shares, opt => opt.MapFrom(src => src.Shares));






    }
}
