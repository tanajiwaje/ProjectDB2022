using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
     public interface IRoleService
    {
        void AddRole(sp_fetch_tblroles_Result role);
        void UpdateRole(sp_fetch_tblroles_Result role);
        void DeleteRole(int role_id);
        void RestoreRole(int role_id);
        List<sp_fetch_tblroles_Result> GetRoles();
        sp_fetch_tblroles_Result GetRole(int role_id);


    }
}
