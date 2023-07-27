using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IGenderService
    {
        void AddGender(sp_fetch_tblGender_Result gender);
        void UpdateGender(sp_fetch_tblGender_Result gender);
        void DeleteGender(int gender_id);
        void RestoreGender(int gender_id);
        List<sp_fetch_tblGender_Result> GetGenders();
        sp_fetch_tblGender_Result GetGender(int gender_id);

    }
}
