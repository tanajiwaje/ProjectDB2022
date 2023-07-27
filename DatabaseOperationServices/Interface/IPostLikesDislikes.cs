using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperationServices.Interface
{
    public interface IPostLikesDislikes
    {

        void AddPostLikesDislikes(sp_fetch_tblpost_like_dislikes_Result likes);
        void UpdatePostLikesDislikes(sp_fetch_tblpost_like_dislikes_Result likes);
        void DeletePostLikesDislikes(int likes_id);
        void RestorePostLikesDislikes(int likes_id);
        List<sp_fetch_tblpost_like_dislikes_Result> GetPostLikesDislikes();
        sp_fetch_tblpost_like_dislikes_Result GetPostLikesDislikes(int likes_id);


    }
}
