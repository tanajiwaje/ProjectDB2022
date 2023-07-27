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
   public class ExperienceDetailService:IExperienceDetailService
    {
       private IRepository<sp_fetch_tblexperience_details_Result> experiencerepo;
       public ExperienceDetailService(IRepository<sp_fetch_tblexperience_details_Result> experiencerepo)
       {
           this.experiencerepo = experiencerepo;
       }
      public void AddExperienceDetail(sp_fetch_tblexperience_details_Result experincedetail)
       {
           string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6},{7}";
           object[] parameters = { "Insert", experincedetail.experience_id, experincedetail.user_id, experincedetail.designation_id, experincedetail.company_name, experincedetail.from_year, experincedetail.to_year, experincedetail.job_description };
           experiencerepo.ExecuteCommand(sp_name, parameters);
       
       }
      public void UpdateExperienceDetail(sp_fetch_tblexperience_details_Result experincedetail)
       {
           string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6},{7}";
           object[] parameters = { "Update", experincedetail.experience_id, experincedetail.user_id, experincedetail.designation_id, experincedetail.company_name, experincedetail.from_year, experincedetail.to_year, experincedetail.job_description };
           experiencerepo.ExecuteCommand(sp_name, parameters);

       }
     public  void DeleteExperienceDetail(int experincedetail_id)
       {
           string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6},{7}";
           object[] parameters = { "Delete", experincedetail_id, 0,0,"","","","" };
           experiencerepo.ExecuteCommand(sp_name, parameters);

       }
     public  void RestoreExperienceDetail(int experincedetail_id)
       {
           string sp_name = "[sp_tblexperience_details] {0},{1},{2},{3},{4},{5},{6}";
           object[] parameters = { "Restore", experincedetail_id, "" };
           experiencerepo.ExecuteCommand(sp_name, parameters);

       }
      public List<sp_fetch_tblexperience_details_Result> GetExperienceDetails()
       {
           string sp_name = "[sp_fetch_tblexperience_details]{0}";
           object[] parameters = { 0 };
           return experiencerepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
     public  sp_fetch_tblexperience_details_Result GetExperienceDetail(int experincedetail_id)
       {
           string sp_name = "[sp_fetch_tblexperience_details]{0}";
           object[] parameters = { experincedetail_id };
           return experiencerepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
