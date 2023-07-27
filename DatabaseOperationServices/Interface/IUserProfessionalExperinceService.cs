using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IUserProfessionalExperinceService
    {
        void AddUserProfessionalExperince(sp_fetch_tblexperience_details_Result userprofessional);
        void UpdateUserProfessionalExperince(sp_fetch_tblexperience_details_Result userprofessional);
        void DeleteUserProfessionalExperince(int userprofessional_id);
        void RestoreUserProfessionalExperince(int userprofessional_id);
        List<sp_fetch_tblexperience_details_Result> GetUserProfessionalExperinces();
        sp_fetch_tblexperience_details_Result GetUserProfessionalExperince(int userprofessional_id);

    }
}
