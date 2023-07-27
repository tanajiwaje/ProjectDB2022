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
   public class DesignationService:IDesignationService
    {
       private IRepository<sp_fetch_tbldesignations_Result> designationsrepo;

       public DesignationService(IRepository<sp_fetch_tbldesignations_Result> designationsrepo)
       {
           this.designationsrepo = designationsrepo;
       }
       public void AddDesignation(sp_fetch_tbldesignations_Result designation)
       {
           string sp_name = "[sp_tbldesignations] {0},{1},{2}";
           object[] parameters = { "Insert", designation.designation_id, designation.designation_name };
           designationsrepo.ExecuteCommand(sp_name, parameters);
       

       }
     public  void UpdateDesignation(sp_fetch_tbldesignations_Result designation)
       {
           string sp_name = "[sp_tbldesignations] {0},{1},{2}";
           object[] parameters = { "Update", designation.designation_id, designation.designation_name };
           designationsrepo.ExecuteCommand(sp_name, parameters);

        }
     public  void DeleteDesignation(int designation_id)
     {
         string sp_name = "[sp_tbldesignations] {0},{1},{2}";
         object[] parameters = { "Delete", designation_id, "" };
         designationsrepo.ExecuteCommand(sp_name, parameters);

       }


     public  void RestoreDesignation(int designation_id)
       {
           string sp_name = "[sp_tbldesignations] {0},{1},{2}";
           object[] parameters = { "Restore", designation_id, "" };
           designationsrepo.ExecuteCommand(sp_name, parameters);

       } 
     public  List<sp_fetch_tbldesignations_Result> GetDesignations()
       {
           string sp_name = "[sp_fetch_tbldesignations]{0}";
           object[] parameters = { 0 };
           return designationsrepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
      public sp_fetch_tbldesignations_Result GetDesignation(int designation_id)
       {
           string sp_name = "[sp_fetch_tbldesignations]{0}";
           object[] parameters = { designation_id };
           return designationsrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
