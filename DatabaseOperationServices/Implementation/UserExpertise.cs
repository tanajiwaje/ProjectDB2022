using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperationServices.Interface;
using DatabaseOperationServices.Implementaion;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Implementaion
{
   public class UserExpertise:IUserExpertise
    {
        private IRepository<sp_fecth_tbluser_professional_expertise_Result> userprofeesinalexperencerepo;
        public UserExpertise(IRepository<sp_fecth_tbluser_professional_expertise_Result> userprofeesinalexperencerepo)
        {
            this.userprofeesinalexperencerepo = userprofeesinalexperencerepo;
        }

        public void AddUserExpertise(sp_fecth_tbluser_professional_expertise_Result userprofessional)
        {
            string sp_name = "[sp_tbluser_professional_expertise] {0},{1},{2},{3},{4}";
            object[] parameters = { "Insert", userprofessional.expertise_id, userprofessional.user_id, userprofessional.topic_id, userprofessional.description };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public void UpdateUserExpertise(sp_fecth_tbluser_professional_expertise_Result userprofessional)
        {
            string sp_name = "[sp_tbluser_professional_expertise] {0},{1},{2},{3},{4}";
            object[] parameters = { "Update", userprofessional.expertise_id, userprofessional.user_id, userprofessional.topic_id, userprofessional.description };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public void DeleteUserExpertise(int userprofessional_id)
        {
            string sp_name = "[sp_tbluser_professional_expertise] {0},{1},{2},{3},{4}";
            object[] parameters = { "Delete", userprofessional_id, 0, 0, "" };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public void RestoreUserExpertise(int userprofessional_id)
        {
            
            string sp_name = "[sp_tbluser_professional_expertise] {0},{1},{2},{3}";
            object[] parameters = { "Restore", userprofessional_id, "" };
            userprofeesinalexperencerepo.ExecuteCommand(sp_name, parameters);

        }
        public List<sp_fecth_tbluser_professional_expertise_Result> GetUserExpertise()
        {
           


            string sp_name = "[sp_fecth_tbluser_professional_expertise]{0}";
            object[] parameters = { 0 };
            return userprofeesinalexperencerepo.ExecuteQuery(sp_name, parameters).ToList();

        }
        public sp_fecth_tbluser_professional_expertise_Result GetUserExpertise(int userprofessional_id)
        {
            string sp_name = "[sp_fecth_tbluser_professional_expertise]{0}";
            object[] parameters = { userprofessional_id };
            return userprofeesinalexperencerepo.ExecuteQuery(sp_name, parameters).ToList().First();

        }
    }
}
