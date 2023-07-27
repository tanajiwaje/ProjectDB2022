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
   public class GenderService:IGenderService
    {
       private IRepository<sp_fetch_tblGender_Result> gendersrepo;
       public GenderService(IRepository<sp_fetch_tblGender_Result> gendersrepo)
       {
           this.gendersrepo = gendersrepo;
       }
      public void AddGender(sp_fetch_tblGender_Result gender)
       {
           string sp_name = "[sp_tblGenders] {0},{1},{2}";
           object[] parameters = { "Insert", gender.gender_id, gender.gender_name };
           gendersrepo.ExecuteCommand(sp_name, parameters);
       
       }
      public void UpdateGender(sp_fetch_tblGender_Result gender)
       {
           string sp_name = "[sp_tblGenders] {0},{1},{2}";
           object[] parameters = { "Update", gender.gender_id, gender.gender_name };
           gendersrepo.ExecuteCommand(sp_name, parameters);

       }
     public  void DeleteGender(int gender_id)
       {
           string sp_name = "[sp_tblGenders] {0},{1},{2}";
           object[] parameters = { "Delete", gender_id, "" };
           gendersrepo.ExecuteCommand(sp_name, parameters);

       }
     public  void RestoreGender(int gender_id)
       {
           string sp_name = "[sp_tblGenders] {0},{1},{2}";
           object[] parameters = { "Restore", gender_id, "",0 };
           gendersrepo.ExecuteCommand(sp_name, parameters);

       }
      public List<sp_fetch_tblGender_Result> GetGenders()
        {
           string sp_name = "[sp_fetch_tblGender]{0}";
           object[] parameters = { 0 };
           return gendersrepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
      public sp_fetch_tblGender_Result GetGender(int gender_id)
       {
           string sp_name = "[sp_fetch_tblGender]{0}";
           object[] parameters = { gender_id };
           return gendersrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
