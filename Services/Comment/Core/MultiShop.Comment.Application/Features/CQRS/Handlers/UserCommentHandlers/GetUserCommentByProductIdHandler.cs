using AutoMapper;
using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;
using MultiShop.Comment.Application.IRepository;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers
{
    public class GetUserCommentByProductIdHandler : IRequestHandler<GetUserCommentByProductIdQuery, List<GetUserCommentByProductIdQueryResult>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetUserCommentByProductIdHandler(IMapper mapper, ICommentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetUserCommentByProductIdQueryResult>> Handle(GetUserCommentByProductIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetCommentByProductIdAsync(request.Id);
            return _mapper.Map<List<GetUserCommentByProductIdQueryResult>>(comments);
        }
    }
}