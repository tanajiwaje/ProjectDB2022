using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IDesignationService
    {
        void AddDesignation(sp_fetch_tbldesignations_Result designation);
        void UpdateDesignation(sp_fetch_tbldesignations_Result designation);
        void DeleteDesignation(int designation_id);
        void RestoreDesignation(int designation_id);
        List<sp_fetch_tbldesignations_Result> GetDesignations();
        sp_fetch_tbldesignations_Result GetDesignation(int designation_id);

    }
}
