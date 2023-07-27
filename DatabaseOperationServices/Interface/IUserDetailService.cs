using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IUserDetailService
    {
        void AddUserDetailService(sp_fetch_tbluser_details_Result userdetail);
        void UpdateUserDetailService(sp_fetch_tbluser_details_Result userdetail);
        void DeleteUserDetailService(int userdetail_id);
        void RestoreUserDetailService(int userdetail_id);
        List<sp_fetch_tbluser_details_Result> GetUserDetailServices();
        sp_fetch_tbluser_details_Result GetUserDetailService(int userdetail_id);

        void ChangePremium(sp_fetch_tbluser_details_Result user);
        sp_fetch_tbluser_details_Result GetCode();

        sp_fetch_tbluser_details_Result LoginCreadential(string UserName, string Pass);

    }
}
