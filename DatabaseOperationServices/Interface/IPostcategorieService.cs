using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface IPostcategorieService
    {
        void AddPostcategorie(sp_fetch_tblpostcategories_Result postcategories);
        void UpdatePostcategorie(sp_fetch_tblpostcategories_Result postcategories);
        void DeletePostcategorie(int postcategories_id);
        void RestorePostcategorie(int postcategories_id);
        List<sp_fetch_tblpostcategories_Result> GetPostcategories();
        sp_fetch_tblpostcategories_Result GetPostcategorie(int postcategories_id);

    }
}
