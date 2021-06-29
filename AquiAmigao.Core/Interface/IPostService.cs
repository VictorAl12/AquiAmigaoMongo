using AquiAmigao.Core.Entity;
using AquiAmigao.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiAmigao.Core.Interface
{
    public interface IPostService
    {
        List<PostResponse> GetPosts();
        PostResponse GetPost(string id);
        BaseResponse AddPost(PostRequest request);
        BaseResponse UpdatePost(PostRequest request);
        BaseResponse DeleteUsuario(string id);
    }
}
