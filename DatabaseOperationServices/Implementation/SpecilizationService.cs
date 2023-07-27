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
    public class SpecilizationService:ISpecilizationService
    {
        private IRepository<sp_fetch_tblspecializations_Result> specializationrepo;
        public SpecilizationService(IRepository<sp_fetch_tblspecializations_Result> specializationrepo)
       {
           this.specializationrepo = specializationrepo;
       }
      public void AddSpecialization(sp_fetch_tblspecializations_Result specialization)
       {
           string sp_name = "[sp_tblspecializations] {0},{1},{2},{3}";
           object[] parameters = { "Insert",specialization.specialization_id, specialization.qualification_id , specialization.specialization_name};
           specializationrepo.ExecuteCommand(sp_name, parameters);
       
       }
       public void UpdateSpecialization(sp_fetch_tblspecializations_Result specialization)
        {
           string sp_name = "[sp_tblspecializations] {0},{1},{2},{3}";
           object[] parameters = { "Update",specialization.specialization_id, specialization.qualification_id,specialization.specialization_name };
           specializationrepo.ExecuteCommand(sp_name, parameters);

       }
      public void DeleteSpecialization(int specialization_id)
       {
           string sp_name = "[sp_tblspecializations] {0},{1},{2},{3}";
           object[] parameters = { "Delete", specialization_id,0,"" };
           specializationrepo.ExecuteCommand(sp_name, parameters);

       }
       public void RestoreSpecialization(int specialization_id)
        {
           string sp_name = "[sp_tblspecializations] {0},{1},{2},{3}";
           object[] parameters = { "Restore", specialization_id, "",0 };
           specializationrepo.ExecuteCommand(sp_name, parameters);

       }
     public  List<sp_fetch_tblspecializations_Result> GetSpecializations()
       {
           string sp_name = "[sp_fetch_tblspecializations]{0}";
           object[] parameters = { 0 };
           return specializationrepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
       public sp_fetch_tblspecializations_Result GetSpecialization(int specialization_id)
       {
           string sp_name = "[sp_fetch_tblspecializations]{0}";
           object[] parameters = { specialization_id };
           return specializationrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
