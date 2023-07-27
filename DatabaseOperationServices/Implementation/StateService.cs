using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
using DatabaseOperationServices.Implementaion;
using DatabaseOperationServices.Interface;

namespace DatabaseOperationServices.Implementaion
{
   public class StateService:IStateService
    {
        private IRepository<sp_fetch_tblstates_Result> staterepo;
        public StateService(IRepository<sp_fetch_tblstates_Result> staterepo)
       {
           this.staterepo = staterepo;
       }

      public void AddState(sp_fetch_tblstates_Result state)
       {
           string sp_name = "[sp_tblStates] {0},{1},{2}";
           object[] parameters = { "Insert", state.state_id, state.state_name };
           staterepo.ExecuteCommand(sp_name, parameters);
       
       }
      public void UpdateState(sp_fetch_tblstates_Result state)
       {
           string sp_name = "[sp_tblStates] {0},{1},{2}";
           object[] parameters = { "Update", state.state_id, state.state_name };
           staterepo.ExecuteCommand(sp_name, parameters);

       }
      public void DeleteState(int state_id)
       {
           string sp_name = "[sp_tblStates] {0},{1},{2}";
           object[] parameters = { "Delete", state_id, "" };
           staterepo.ExecuteCommand(sp_name, parameters);

       }
      public void RestoreState(int state_id)
       {
           string sp_name = "[sp_tblStates] {0},{1},{2}";
           object[] parameters = { "Resore", state_id, " " };
           staterepo.ExecuteCommand(sp_name, parameters);

       }
      public List<sp_fetch_tblstates_Result> GetStates()
       {
           string sp_name = "[sp_fetch_tblstates]{0}";
           object[] parameters = { 0 };
           return staterepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
      public sp_fetch_tblstates_Result GetState(int state_id)
       {
           string sp_name = "[sp_fetch_tblstates]{0}";
           object[] parameters = { state_id };
           return staterepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
