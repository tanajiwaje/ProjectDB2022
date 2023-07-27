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
   public class UserQualificationService:IUserQualificationService
    {
        private IRepository<sp_fetch_tbluser_qualifications_Result> userqualificatonservicesrepo;
        public UserQualificationService(IRepository<sp_fetch_tbluser_qualifications_Result> userqualificatonservicesrepo)
       {
           this.userqualificatonservicesrepo = userqualificatonservicesrepo;
       }
       public void AddUserQualificatonService(sp_fetch_tbluser_qualifications_Result userqualificatonservice)
       {
           string sp_name = "[sp_tbluser_qualifications] {0},{1},{2},{3},{4},{5},{6},{7}";
           object[] parameters = {"Insert", userqualificatonservice.user_qualification_id, userqualificatonservice.user_id, userqualificatonservice.specialization_id, userqualificatonservice.university, userqualificatonservice.passing_year, userqualificatonservice.medium, userqualificatonservice.percentage };
           userqualificatonservicesrepo.ExecuteCommand(sp_name, parameters);
       }
        public void UpdateUserQualificatonService(sp_fetch_tbluser_qualifications_Result userqualificatonservice)
        {
            string sp_name = "[sp_tbluser_qualifications] {0},{1},{2},{3},{4},{5},{6},{7}";
            object[] parameters = { "Update", userqualificatonservice.user_qualification_id, userqualificatonservice.user_id,
                userqualificatonservice.specialization_id, userqualificatonservice.university, userqualificatonservice.passing_year,
                userqualificatonservice.medium, userqualificatonservice.percentage };
            userqualificatonservicesrepo.ExecuteCommand(sp_name, parameters);

        }

        public void DeleteUserQualificatonService(int userqualificatonservice_id)
       {
           string sp_name = "[sp_tbluser_qualifications] {0},{1},{2},{3},{4},{5},{6},{7}";
           object[] parameters = { "Delete", userqualificatonservice_id,0,0,"",0,"",0 };
           userqualificatonservicesrepo.ExecuteCommand(sp_name, parameters);

       }
       public void RestoreUserQualificatonService(int userqualificatonservice_id)
       {
           string sp_name = "[sp_tbluser_qualifications] {0},{1},{2},{3},{4},{5},{6},{7}";
           object[] parameters = { "Restore", userqualificatonservice_id, 0, 0, "", 0, "", 0 };
           userqualificatonservicesrepo.ExecuteCommand(sp_name, parameters);

       }
       public List<sp_fetch_tbluser_qualifications_Result> GetUserQualificatonServices()
       {
           string sp_name = "[sp_fetch_tbluser_qualifications]{0}";
           object[] parameters = { 0 };
           return userqualificatonservicesrepo.ExecuteQuery(sp_name, parameters).ToList();
        

       }
        public sp_fetch_tbluser_qualifications_Result GetUserQualificatonServiceById(int userqualificatonservice_id)
        {
            string sp_name = "[sp_fetch_tbluser_qualifications]{0}";
            object[] parameters = { userqualificatonservice_id};
            return userqualificatonservicesrepo.ExecuteQuery(sp_name, parameters).ToList().First();


        }

    }

    }

