using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperationServices.Interface
{
    public interface IPostcomments
    {
        void AddPostcomments(sp_fetch_tblpost_comments_Result comments);
        void UpdatePostcomments(sp_fetch_tblpost_comments_Result comments);
        void DeletePostcomments(int comment_id);
        void RestorePostcomments(int comment_id);
        List<sp_fetch_tblpost_comments_Result> GetPostcomments();
        sp_fetch_tblpost_comments_Result GetPostcomments(int comment_id);
    }
}
