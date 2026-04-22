using AutoMapper;
using MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserComment, CreateUserCommentCommand>().ReverseMap();
        CreateMap<UserComment, UpdateUserCommentCommand>().ReverseMap();
        CreateMap<UserComment, RemoveUserCommentCommand>().ReverseMap();
        CreateMap<UserComment, GetUserCommentByIdQueryResult>().ReverseMap();
        CreateMap<UserComment, GetUserCommentQueryResult>().ReverseMap();
        CreateMap<UserComment, GetUserCommentByProductIdQueryResult>().ReverseMap();
    }
}
