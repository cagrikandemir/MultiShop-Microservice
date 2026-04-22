using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.IRepository;

public interface ICommentRepository 
{
    Task <List<UserComment>>GetCommentByProductIdAsync(string Id);
}
