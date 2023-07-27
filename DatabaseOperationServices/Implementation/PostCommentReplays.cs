using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseOperationServices.Implementation
{
    public class PostCommentReplays : IPostCommentReplays
    {
        private IRepository<sp_fetch_tblpost_comment_replys_Result> postcomments;
        public PostCommentReplays(IRepository<sp_fetch_tblpost_comment_replys_Result> postcomments)
        {
            this.postcomments = postcomments;
        }

        public void AddPostcommentsReplay(sp_fetch_tblpost_comment_replys_Result replay)
        {
            string sp_name = "[sp_tblpost_comment_replys] {0},{1},{2},{3},{4},{5},{6}";
            object[] parameters = { "Insert", replay.reply_id,replay.comment_id,replay.reply_date,replay.reply_by_user,replay.reply_message,replay.comment_photo };
            postcomments.ExecuteCommand(sp_name, parameters);
        }
        public void UpdatePostcommentsReplay(sp_fetch_tblpost_comment_replys_Result replay)
        {
            string sp_name = "[sp_tblpost_comment_replys] {0},{1},{2},{3},{4},{5},{6}";
            object[] parameters = { "Update", replay.reply_id, replay.comment_id, replay.reply_date, replay.reply_by_user, replay.reply_message, replay.comment_photo };
            postcomments.ExecuteCommand(sp_name, parameters);
        }
        public void DeletePostcommentsReplay(int replay_id)
        {
            string sp_name = "[sp_tblpost_comment_replys] {0},{1},{2},{3},{4},{5},{6}";
            object[] parameters = { "Delete", replay_id, 0, 0, "", "","" };
            postcomments.ExecuteCommand(sp_name, parameters);
        }
        public List<sp_fetch_tblpost_comment_replys_Result> GetPostcommentsReplay()
        {
            string sp_name = "[sp_tblpost_comment_replys] {0}";
            object[] parameters = { 0 };
            return postcomments.ExecuteQuery(sp_name, parameters).ToList();
        }
        public sp_fetch_tblpost_comment_replys_Result GetPostcommentsReplay(int replay_id)
        {
            string sp_name = "[sp_tblpost_comment_replys] {0}";
            object[] parameters = { replay_id };
           return postcomments.ExecuteQuery(sp_name, parameters).ToList().First();
        }
        public void RestorePostcommentsReplay(int replay_id)
        {
            throw new NotImplementedException();
        }

      
    }
}
