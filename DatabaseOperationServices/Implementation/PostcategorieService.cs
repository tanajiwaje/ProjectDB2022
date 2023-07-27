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
   public class PostcategorieService:IPostcategorieService
    {
        private IRepository<sp_fetch_tblpostcategories_Result> postgategoriesrepo;
        public PostcategorieService(IRepository<sp_fetch_tblpostcategories_Result> postgategoriesrepo)
       {
           this.postgategoriesrepo = postgategoriesrepo;
       }
     public  void AddPostcategorie(sp_fetch_tblpostcategories_Result postcategories)
       {
           string sp_name = "[sp_tblpostcategories] {0},{1},{2}";
           object[] parameters = { "Insert", postcategories.category_id, postcategories.category_name };
           postgategoriesrepo.ExecuteCommand(sp_name, parameters);
       
       }
      public void UpdatePostcategorie(sp_fetch_tblpostcategories_Result postcategories)
       {
           string sp_name = "[sp_tblpostcategories] {0},{1},{2}";
           object[] parameters = { "Update", postcategories.category_id, postcategories.category_name };
           postgategoriesrepo.ExecuteCommand(sp_name, parameters);

       }
      public void DeletePostcategorie(int postcategories_id)
       {
           string sp_name = "[sp_tblpostcategories] {0},{1},{2}";
           object[] parameters = { "Delete", postcategories_id, "" };
           postgategoriesrepo.ExecuteCommand(sp_name, parameters);

       }
     public  void RestorePostcategorie(int postcategories_id)
       {
           string sp_name = "[sp_tblpostcategories] {0},{1},{2}";
           object[] parameters = { "Restore", postcategories_id, "" };
           postgategoriesrepo.ExecuteCommand(sp_name, parameters);

       }
      public List<sp_fetch_tblpostcategories_Result> GetPostcategories()
       {
           string sp_name = "[sp_fetch_tblpostcategories]{0}";
           object[] parameters = { 0 };
           return postgategoriesrepo.ExecuteQuery(sp_name, parameters).ToList();
        
       }
      public sp_fetch_tblpostcategories_Result GetPostcategorie(int postcategories_id)
       {
           string sp_name = "[sp_fetch_tblpostcategories]{0}";
           object[] parameters = { postcategories_id };
           return postgategoriesrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
       }


    }
}
