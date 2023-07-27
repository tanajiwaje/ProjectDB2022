using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IQualificationService
    {
        void AddQualificatonService(sp_fetch_qualifications_Result qualificatonservice);
        void UpdateQualificatonService(sp_fetch_qualifications_Result qualificatonservice);
        void DeleteQualificatonService(int qualificatonservice_id);
        void RestoreQualificatonService(int qualificatonservice_id);
        List<sp_fetch_qualifications_Result> GetQualificatonServices();
        sp_fetch_qualifications_Result GetQualificatonService(int qualificatonservice_id);

    }
}
