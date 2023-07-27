using DatabaseOperationServices.Interface;
using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperationServices.Implementation
{
    public class PostLikesShares : IPostLikesShares
    {
        private IRepository<sp_fetch_tblpost_likes_shares_Result> shared;
        public PostLikesShares(IRepository<sp_fetch_tblpost_likes_shares_Result> shared)
        {
            this.shared = shared;
        }

        public void AddPostLikesShares(sp_fetch_tblpost_likes_shares_Result shared)
        {
            throw new NotImplementedException();
        }


        public void UpdatePostLikesShares(sp_fetch_tblpost_like_dislikes_Result shared)
        {
            throw new NotImplementedException();
        }
        public void DeletePostLikesShares(int shared_id)
        {
            throw new NotImplementedException();
        }

        public List<sp_fetch_tblpost_like_dislikes_Result> GetPostLikesShares()
        {
            throw new NotImplementedException();
        }

        public sp_fetch_tblpost_like_dislikes_Result GetPostLikesShares(int shared_id)
        {
            throw new NotImplementedException();
        }

        public void RestorePostLikesShares(int shared_id)
        {
            throw new NotImplementedException();
        }

        
    }
}
