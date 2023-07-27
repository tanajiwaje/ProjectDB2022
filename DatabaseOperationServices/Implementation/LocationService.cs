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
   public class LocationService:ILocationService
    {
       private IRepository<sp_fetch_tbllocation_Result> locationsrepo;
       public LocationService(IRepository<sp_fetch_tbllocation_Result> locationsrepo)
       {
           this.locationsrepo = locationsrepo;
       }
      public void AddLocation(sp_fetch_tbllocation_Result location)
       {
           string sp_name = "[sp_tblLocations] {0},{1},{2},{3}";
           object[] parameters = { "Insert", location.location_id, location.location_name, location.city_id };
           locationsrepo.ExecuteCommand(sp_name, parameters);
       
       }
     public  void UpdateLocation(sp_fetch_tbllocation_Result location)
       {
           string sp_name = "[sp_tblLocations] {0},{1},{2},{3}";
           object[] parameters = { "Update", location.location_id, location.location_name, location.city_id };
           locationsrepo.ExecuteCommand(sp_name, parameters);

       }
     public  void DeleteLocation(int location_id)
       {
           string sp_name = "[sp_tblLocations] {0},{1},{2},{3}";
           object[] parameters = { "Delete", location_id, "",1 };
           locationsrepo.ExecuteCommand(sp_name, parameters);

       }
       public void RestoreLocation(int location_id)
       {
           string sp_name = "[sp_tblLocations] {0},{1},{2},{3}";
           object[] parameters = { "Restore", location_id, "" ,0};
           locationsrepo.ExecuteCommand(sp_name, parameters);

       }
      public List<sp_fetch_tbllocation_Result> GetLocations()
       {
           string sp_name = "[sp_fetch_tbllocation]{0}";
           object[] parameters = { 0 };
           return locationsrepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
      public sp_fetch_tbllocation_Result GetLocation(int location_id)
       {
           string sp_name = "[sp_fetch_tbllocation]{0}";
           object[] parameters = { location_id };
           return locationsrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }

    }
}
