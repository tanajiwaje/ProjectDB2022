using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IUserExpertise
    {
        void AddUserExpertise(sp_fecth_tbluser_professional_expertise_Result userprofessional);
        void UpdateUserExpertise(sp_fecth_tbluser_professional_expertise_Result userprofessional);
        void DeleteUserExpertise(int userprofessional_id);
        void RestoreUserExpertise(int userprofessional_id);
        List<sp_fecth_tbluser_professional_expertise_Result> GetUserExpertise();
        sp_fecth_tbluser_professional_expertise_Result GetUserExpertise(int userprofessional_id);

    }
}
