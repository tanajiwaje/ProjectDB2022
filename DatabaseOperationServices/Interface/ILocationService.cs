using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
    public interface ILocationService
    {
        void AddLocation(sp_fetch_tbllocation_Result location);
        void UpdateLocation(sp_fetch_tbllocation_Result location);
        void DeleteLocation(int location_id);
        void RestoreLocation(int location_id);
        List<sp_fetch_tbllocation_Result> GetLocations();
        sp_fetch_tbllocation_Result GetLocation(int location_id);

    }
}
