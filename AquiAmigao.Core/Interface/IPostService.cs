using AquiAmigao.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core.Interface
{
    public interface IPostService
    {
        List<Post> GetPosts();
        Post GetPost(string id);
        Post AddPost(Post post);
    }
}
