using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;


namespace DatabaseOperationServices.Implementation
{
      public interface IPostCommentReplays
    {

        void AddPostcommentsReplay(sp_fetch_tblpost_comment_replys_Result replay);
        void UpdatePostcommentsReplay(sp_fetch_tblpost_comment_replys_Result replay);
        void DeletePostcommentsReplay(int replay_id);
        void RestorePostcommentsReplay(int replay_id);
        List<sp_fetch_tblpost_comment_replys_Result> GetPostcommentsReplay();
        sp_fetch_tblpost_comment_replys_Result GetPostcommentsReplay(int replay_id);
    }
}
