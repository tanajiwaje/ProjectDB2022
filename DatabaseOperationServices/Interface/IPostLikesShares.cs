using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperationServices.Interface
{
    public interface IPostLikesShares
    {
        void AddPostLikesShares(sp_fetch_tblpost_likes_shares_Result shared);
        void UpdatePostLikesShares(sp_fetch_tblpost_like_dislikes_Result shared);
        void DeletePostLikesShares(int shared_id);
        void RestorePostLikesShares(int shared_id);
        List<sp_fetch_tblpost_like_dislikes_Result> GetPostLikesShares();
        sp_fetch_tblpost_like_dislikes_Result GetPostLikesShares(int shared_id);
    }
}
