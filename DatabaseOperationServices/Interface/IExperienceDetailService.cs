using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IExperienceDetailService
    {
        void AddExperienceDetail(sp_fetch_tblexperience_details_Result experincedetail);
        void UpdateExperienceDetail(sp_fetch_tblexperience_details_Result experincedetail);
        void DeleteExperienceDetail(int experincedetail_id);
        void RestoreExperienceDetail(int experincedetail_id);
        List<sp_fetch_tblexperience_details_Result> GetExperienceDetails();
        sp_fetch_tblexperience_details_Result GetExperienceDetail(int experincedetail_id);

    }
}
