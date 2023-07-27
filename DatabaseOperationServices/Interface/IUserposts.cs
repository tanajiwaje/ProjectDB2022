using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;

namespace DatabaseOperationServices.Interface
{
    public  interface IUserposts
    {
        void AddPosts(sp_fetch_tbluser_posts_Result posts);
        void UpdatePosts(sp_fetch_tbluser_posts_Result posts);
        void DeletePosts(int post_id);
        void RestorePosts(int post_id);
        List<sp_fetch_tbluser_posts_Result> GetPosts();
        sp_fetch_tbluser_posts_Result GetPosts(int topic_id);
    }
}
