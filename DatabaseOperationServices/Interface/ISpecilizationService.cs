using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface ISpecilizationService
    {
        void AddSpecialization(sp_fetch_tblspecializations_Result specialization);
        void UpdateSpecialization(sp_fetch_tblspecializations_Result specialization);
        void DeleteSpecialization(int specialization_id);
        void RestoreSpecialization(int specialization_id);
        List<sp_fetch_tblspecializations_Result> GetSpecializations();
        sp_fetch_tblspecializations_Result GetSpecialization(int specialization_id);

    }
}
