using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperationServices.Interface;

using DatabaseOperationServices.Implementaion;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Implementaion
{
   public class CityService:ICityService
    {
       private IRepository<sp_fetch_tblCities_Result> cityrepo;
       public CityService(IRepository<sp_fetch_tblCities_Result> cityrepo)
       {
           this.cityrepo = cityrepo;
       }
       public void AddCity(sp_fetch_tblCities_Result city)
       {
           string sp_name = "[sp_tblCities] {0},{1},{2},{3}";
           object[] parameters = { "Insert", city.city_id, city.city_name, city.state_id };
           cityrepo.ExecuteCommand(sp_name, parameters);
       
       }
       public void UpdateCity(sp_fetch_tblCities_Result city)
       {
           string sp_name = "[sp_tblCities] {0},{1},{2},{3}";
           object[] parameters = { "Update", city.city_id, city.city_name, city.state_id };
           cityrepo.ExecuteCommand(sp_name, parameters);

       }
       public void DeleteCity(int city_id)
       {
           string sp_name = "[sp_tblCities] {0},{1},{2},{3}";
           object[] parameters = { "Delete", city_id, "" ,1};
           cityrepo.ExecuteCommand(sp_name, parameters);

       }
       public void RestoreCity(int city_id)
       {
           string sp_name = "[sp_tblCities] {0},{1},{2},{3}";
           object[] parameters = { "Restore", city_id, "",0 };
           cityrepo.ExecuteCommand(sp_name, parameters);

       }
       public List<sp_fetch_tblCities_Result> GetCitys()
       {
           string sp_name = "[sp_fetch_tblCities]{0}";
           object[] parameters = { 0 };
           return cityrepo.ExecuteQuery(sp_name, parameters).ToList();
        

       }
       public sp_fetch_tblCities_Result GetCity(int city_id)
       {
           string sp_name = "[sp_fetch_tblCities]{0}";
           object[] parameters = { city_id };
           return cityrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}

