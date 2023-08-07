using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperationServices.Interface;
using ProjectDatabaseOperation;

namespace DatabaseOperationServices.Implementation
{
    public class UserPost : IUserposts
    {

        private IRepository<sp_fetch_tbluser_post_Result> userpost;
        public UserPost(IRepository<sp_fetch_tbluser_post_Result> userpost)
        {
            this.userpost = userpost;
        }
        public void AddPosts(sp_fetch_tbluser_post_Result posts)
        {
            string sp_name = "[sp_tbluser_posts] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Insert", posts.post_id,posts.user_id,posts.post_date,posts.post_title,posts.post_description,posts.photo,posts.is_active };
            userpost.ExecuteCommand(sp_name, parameters);


        }

        public void UpdatePosts(sp_fetch_tbluser_post_Result posts)
        {
            string sp_name = "[sp_tbluser_posts] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Update", posts.post_id, posts.user_id, posts.post_date, posts.post_title, posts.post_description, posts.photo, posts.is_active };
            userpost.ExecuteCommand(sp_name, parameters);

        }

        public void DeletePosts(int post_id)
        {
            string sp_name = "[sp_tbluser_posts] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Delete",post_id, 0, 0, "", "", "","" };
            userpost.ExecuteCommand(sp_name, parameters);

         
        }

        public List<sp_fetch_tbluser_post_Result> GetPosts()
        {
            string sp_name = "[sp_fetch_tbluser_post]{0}";
            object[] parameters = { 0 };
            return userpost.ExecuteQuery(sp_name, parameters).ToList();
        }

        public sp_fetch_tbluser_post_Result GetPosts(int topic_id)
        {
            string sp_name = "[sp_fetch_tbluser_post]{0}";
            object[] parameters = { topic_id };
            return userpost.ExecuteQuery(sp_name, parameters).ToList().First();
        }

        public void RestorePosts(int post_id)
        {
            throw new NotImplementedException();
        }

       
    }
}
