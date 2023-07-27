using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
using DatabaseOperationServices.Implementaion;
using DatabaseOperationServices.Interface;
namespace DatabaseOperationServices.Implementaion
{
    public class UserProfessionalExperinceService:IUserProfessionalExperinceService
    {
         private IRepository<sp_fetch_tblexperience_details_Result> userprofeesinalexperencerepo;
         public UserProfessionalExperinceService(IRepository<sp_fetch_tblexperience_details_Result> userprofeesinalexperencerepo)
       {
           this.userprofeesinalexperencerepo = userprofeesinalexperencerepo;
       }
      
        public void AddUserProfessionalExperince(sp_fetch_tblexperience_details_Result userprofessional)
        {
            string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Insert", userprofessional.experience_id, userprofessional.user_id, userprofessional.designation_id, userprofessional.company_name, userprofessional.from_year, userprofessional.to_year, userprofessional.job_description };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public void UpdateUserProfessionalExperince(sp_fetch_tblexperience_details_Result userprofessional)
        {
            string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Update", userprofessional.experience_id, userprofessional.user_id, userprofessional.designation_id, userprofessional.company_name,userprofessional.from_year,userprofessional.to_year,userprofessional.job_description};
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public void DeleteUserProfessionalExperince(int userprofessional_id)
        {
            string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Delete", userprofessional_id, 0,0, "", 0, 0,"" };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public void RestoreUserProfessionalExperince(int userprofessional_id)
        {
            string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3}";
            object[] parameters = { "Restore", userprofessional_id, "" };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public List<sp_fetch_tblexperience_details_Result> GetUserProfessionalExperinces()
        {
            string sp_name = "[sp_fetch_tblexperience_details]{0}";
            object[] parameters = { 0 };
            return userprofeesinalexperencerepo.ExecuteQuery(sp_name, parameters).ToList();
        
        }
        public sp_fetch_tblexperience_details_Result GetUserProfessionalExperince(int userprofessional_id)
        {
            string sp_name = "[sp_fetch_tblexperience_details]{0}";
            object[] parameters = { userprofessional_id };
            return userprofeesinalexperencerepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
        }

    }
}
