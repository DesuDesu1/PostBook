using PostBook.Domain;

namespace PostBook.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
        Task<bool> CreatePostAsync(Post postToCreate);
        Task<Post> GetPostByIdAsync(Guid postid);
        Task<bool> UpdatePostAsync(Post postToUpdate);
        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> UserOwnsPostAsync(Guid postId, string userId);
    }
}
