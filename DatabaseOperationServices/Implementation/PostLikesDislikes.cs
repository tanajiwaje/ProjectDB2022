using DatabaseOperationServices.Interface;
using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperationServices.Implementation
{
    public class PostLikesDislikes : IPostLikesDislikes
    {
        private IRepository<sp_fetch_tblpost_like_dislikes_Result> tblpost;
        public PostLikesDislikes(IRepository<sp_fetch_tblpost_like_dislikes_Result> tblpost)
        {
            this.tblpost = tblpost;
        }

        public void AddPostLikesDislikes(sp_fetch_tblpost_like_dislikes_Result likes)
        {
            string sp_name = "[sp_tblpost_like_dislikes] {0},{1},{2},{3},{4},{5}";
            object[] parameters = { "Insert",likes.like_dislike_id,likes.post_id,likes.like_dislike_date,likes.like_dislike_by_user,likes.is_like};
            tblpost.ExecuteCommand(sp_name, parameters);
        }

        public void UpdatePostLikesDislikes(sp_fetch_tblpost_like_dislikes_Result likes)
        {
            string sp_name = "[sp_tblpost_like_dislikes] {0},{1},{2},{3},{4},{5}";
            object[] parameters = { "Update", likes.like_dislike_id, likes.post_id, likes.like_dislike_date, likes.like_dislike_by_user, likes.is_like };
            tblpost.ExecuteCommand(sp_name, parameters);
        }

        public void DeletePostLikesDislikes(int likes_id)
        {
            string sp_name = "[sp_tblpost_like_dislikes]{0}";
            object[] parameters = { likes_id };
            tblpost.ExecuteCommand(sp_name, parameters);
        }

        public List<sp_fetch_tblpost_like_dislikes_Result> GetPostLikesDislikes()
        {
            string sp_name = "[sp_fetch_tblpost_like_dislikes] {0}";
            object[] parameters = { 0 };
            return tblpost.ExecuteQuery(sp_name, parameters).ToList();
        }

        public sp_fetch_tblpost_like_dislikes_Result GetPostLikesDislikes(int likes_id)
        {
            string sp_name = "[sp_fetch_tblpost_like_dislikes] {0}";
            object[] parameters = { 0 };
            return tblpost.ExecuteQuery(sp_name, parameters).ToList().First();
        }

        public void RestorePostLikesDislikes(int likes_id)
        {
            throw new NotImplementedException();
        }

      
    }
}
