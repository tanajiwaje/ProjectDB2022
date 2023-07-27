using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
using DatabaseOperationServices.Implementaion;
using DatabaseOperationServices.Interface;
using System.Web;

namespace DatabaseOperationServices.Implementaion
{
   public class UserDetailService:IUserDetailService
    {
        private IRepository<sp_fetch_tbluser_details_Result> usedrepo;
        public UserDetailService(IRepository<sp_fetch_tbluser_details_Result> usedrepo)
     {
         this.usedrepo = usedrepo;

     }
      public void AddUserDetailService(sp_fetch_tbluser_details_Result userdetail)
        {
            string sp_name = "[sp_tbluser_details] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}";
            object[] parameters = { "Insert",userdetail.user_id,userdetail.first_name,userdetail.middle_name,userdetail.last_name,userdetail.gender_id,
                userdetail.location_id,userdetail.local_address,userdetail.role_id,userdetail.birth_date,userdetail.joining_date,userdetail.user_photo,userdetail.mobile_number,
                userdetail.email_address,userdetail.user_name,userdetail.is_permium,userdetail.password };
            usedrepo.ExecuteCommand(sp_name, parameters);

        }
        public void UpdateUserDetailService(sp_fetch_tbluser_details_Result userdetail)
        {
            string sp_name = "[sp_tbluser_details] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}";
            object[] parameters = { "Update",userdetail.user_id, userdetail.first_name,
                userdetail.middle_name, userdetail.last_name,
                userdetail.gender_id, userdetail.location_id,userdetail.local_address, userdetail.role_id, userdetail.birth_date, 
                userdetail.joining_date, userdetail.user_photo,
                userdetail.mobile_number, userdetail.email_address, userdetail.user_name, userdetail.is_permium, 
                userdetail.password };
            usedrepo.ExecuteCommand(sp_name, parameters);

        }
        public void DeleteUserDetailService(int userdetail_id)
        {
            string sp_name = "[sp_tbluser_details] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}";
            object[] parameters = { "Delete", userdetail_id,"","","",0,0,"",0,"","","","","","",0,"" };
            usedrepo.ExecuteCommand(sp_name, parameters);

        }
        public void RestoreUserDetailService(int userdetail_id)
        {
            string sp_name = "[sp_tbluser_details] {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}";
            object[] parameters = { "Restore", userdetail_id, "", "", "", 0, 0, "", 0, "", "", "", "", "", "", 0, ""};
            usedrepo.ExecuteCommand(sp_name, parameters);

        }
        public List<sp_fetch_tbluser_details_Result> GetUserDetailServices()
        {
            string sp_name = "[sp_fetch_tbluser_details]{0}";
            object[] parameters = { 0 };
            return usedrepo.ExecuteQuery(sp_name, parameters).ToList();

        }
        public  sp_fetch_tbluser_details_Result GetUserDetailService(int userdetail_id)
        {
            string sp_name = "[sp_fetch_tbluser_details]{0}";
            object[] parameters = { userdetail_id };
            return usedrepo.ExecuteQuery(sp_name, parameters).ToList().First();

        }

        public void ChangePremium(sp_fetch_tbluser_details_Result user)
        {
            string sp_name = "[sp_is_premium]{0},{1},{2}";
            object[] parameters = { "Update",user.user_id,user.is_permium };
            usedrepo.ExecuteCommand(sp_name, parameters);


        }

        public sp_fetch_tbluser_details_Result GetCode()
        {
            string sp_name = "[sp_fetch_get_code]";
            object[] parameters = { };
            return usedrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        }

        public sp_fetch_tbluser_details_Result LoginCreadential(string UserName,string Pass)
        {
             string sp_name = "[sp_login_user]{0},{1}";
             object[] parameters = { UserName, Pass };
            return usedrepo.ExecuteQuery(sp_name, parameters).ToList().First();
           // return "change";
        }
    }
}
 