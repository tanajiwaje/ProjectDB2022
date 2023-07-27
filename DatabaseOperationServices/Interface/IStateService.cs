using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IStateService
    {
        void AddState(sp_fetch_tblstates_Result state);
        void UpdateState(sp_fetch_tblstates_Result state);
        void DeleteState(int state_id);
        void RestoreState(int state_id);
        List<sp_fetch_tblstates_Result> GetStates();
        sp_fetch_tblstates_Result GetState(int state_id);

    }
}
