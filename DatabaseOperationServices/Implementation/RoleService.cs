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
   public class RoleService:IRoleService
    {
       private IRepository<sp_fetch_tblroles_Result> rolerepo;
       public RoleService(IRepository<sp_fetch_tblroles_Result> rolerepo)
       {
           this.rolerepo = rolerepo;
       }
      public void AddRole(sp_fetch_tblroles_Result role)
       {
           string sp_name = "[sp_tblroles] {0},{1},{2}";
           object[] parameters = { "Insert", role.role_id, role.role };
           rolerepo.ExecuteCommand(sp_name, parameters);
       
       }
      public void UpdateRole(sp_fetch_tblroles_Result role)
       {
           string sp_name = "[sp_tblroles] {0},{1},{2}";
           object[] parameters = { "Update", role.role_id, role.role };
           rolerepo.ExecuteCommand(sp_name, parameters);

       }
      public void DeleteRole(int role_id)
       {
           string sp_name = "[sp_tblroles] {0},{1},{2}";
           object[] parameters = { "Delete", role_id, "" };
           rolerepo.ExecuteCommand(sp_name, parameters);

       }
      public void RestoreRole(int role_id)
       {
           string sp_name = "[sp_tblroles] {0},{1},{2}";
           object[] parameters = { "Resore", role_id, "",0 };
           rolerepo.ExecuteCommand(sp_name, parameters);

       }
     public  List<sp_fetch_tblroles_Result> GetRoles()
       {
           string sp_name = "[sp_fetch_tblroles]{0}";
           object[] parameters = { 0 };
           return rolerepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
      public sp_fetch_tblroles_Result GetRole(int role_id)
       {
           string sp_name = "[sp_fetch_tblroles]{0}";
           object[] parameters = { role_id };
           return rolerepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
