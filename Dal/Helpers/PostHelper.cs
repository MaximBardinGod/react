using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Helpers;
public class PostHelper
{
    public static async Task<Post> WithWorkers(this Post post, ApplicationContext db)
    {
        post.Workers = await db.Worker.Where(p =>p.PostId == post.PostId).ToListAsync();
        return post;
    }
}
