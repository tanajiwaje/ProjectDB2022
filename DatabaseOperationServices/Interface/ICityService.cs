using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ProjectDatabaseOperation;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface ICityService
    {
        void AddCity(sp_fetch_tblCities_Result city);
        void UpdateCity(sp_fetch_tblCities_Result city);
        void DeleteCity(int city_id);
        void RestoreCity(int city_id);
        List<sp_fetch_tblCities_Result> GetCitys();
        sp_fetch_tblCities_Result GetCity(int city_id);
    
    }
}
