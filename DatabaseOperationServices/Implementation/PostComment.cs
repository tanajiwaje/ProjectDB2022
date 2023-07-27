using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperationServices.Interface;
using ProjectDatabaseOperation;

namespace DatabaseOperationServices.Implementation
{
    public class PostComment : IPostcomments
    {
        private IRepository<sp_fetch_tblpost_comments_Result> com;
        public PostComment(IRepository<sp_fetch_tblpost_comments_Result> comments)
        {
            this.com = comments;
        }

      

        public void AddPostcomments(sp_fetch_tblpost_comments_Result comments)
        {
            string sp_name = "[sp_tblpost_comments] {0},{1},{2},{3},{4},{5},{6}";
            object[] parameters = { "Insert", comments.comment_id,comments.post_id,comments.comment_date,comments.comment_by_user,comments.comment_message,comments.comment_photo};
            com.ExecuteCommand(sp_name, parameters);
        }

        public void UpdatePostcomments(sp_fetch_tblpost_comments_Result comments)
        {
            string sp_name = "[sp_tblpost_comments] {0},{1},{2},{3},{4},{5},{6}";
            object[] parameters = { "Update", comments.comment_id, comments.post_id, comments.comment_date, comments.comment_by_user, comments.comment_message, comments.comment_photo };
            com.ExecuteCommand(sp_name, parameters);
        }

        public void DeletePostcomments(int comment_id)
        {
            string sp_name = "[sp_tblpost_comments] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Insert", comment_id, 0, 0,"", "", "", 0 };
            com.ExecuteCommand(sp_name, parameters);
        }

        public List<sp_fetch_tblpost_comments_Result> GetPostcomments()
        {
            string sp_name = "[sp_fetch_tblpost_comments]{0}";
            object[] parameters = { 0 };
            return com.ExecuteQuery(sp_name, parameters).ToList();
        }

        public sp_fetch_tblpost_comments_Result GetPostcomments(int comment_id)
        {
            string sp_name = "[sp_fetch_tblpost_comments] {0}";
            object[] parameters = { comment_id };
            return com.ExecuteQuery(sp_name, parameters).ToList().First();
        }

        public void RestorePostcomments(int comment_id)
        {
            throw new NotImplementedException();
        }

       
    }
}
