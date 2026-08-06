using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices;

public interface ICommentService
{
    Task<List<ResultCommentDto>> GetAllCommentAsync();
    Task CreateCommentAsync(CreateCommentDto createCommentDto);
    Task DeleteCommentAsync(string Id);
    Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
    Task<UpdateCommentDto> GetByIdCommentAsync(string Id);
    Task<List<ResultCommentDto>> CommentListByProductId(string id);

}
