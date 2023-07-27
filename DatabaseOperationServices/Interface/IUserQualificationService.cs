using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
  public interface IUserQualificationService
    {
        void AddUserQualificatonService(sp_fetch_tbluser_qualifications_Result userqualificatonservice);
        void UpdateUserQualificatonService(sp_fetch_tbluser_qualifications_Result userqualificatonservice);
        void DeleteUserQualificatonService(int userqualificatonservice_id);
        void RestoreUserQualificatonService(int userqualificatonservice_id);
        List<sp_fetch_tbluser_qualifications_Result> GetUserQualificatonServices();
        sp_fetch_tbluser_qualifications_Result GetUserQualificatonServiceById(int userqualificatonservice_id);

    }
}
