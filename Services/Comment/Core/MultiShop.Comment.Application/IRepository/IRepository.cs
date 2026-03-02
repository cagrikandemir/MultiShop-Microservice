namespace MultiShop.Comment.Application.IRepository;

public interface IRepository<T> where T : class 
{
    Task<List<T>> GetAllCommentAsync();
    Task<T> GetByIdCommentAsync(int Id);
    Task CreateComment(T Entity);
    Task UpdateComment(T Entity);
    Task DeleteComment(T Entity);

}
