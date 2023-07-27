using DatabaseOperationServices.Interface;
using ProjectDatabaseOperation;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseOperationServices.Implementaion
{
    public class QualificationService : IQualificationService
    {
        private IRepository<sp_fetch_qualifications_Result> qualificationrepo;
        public QualificationService(IRepository<sp_fetch_qualifications_Result> qualificationrepo)
        {
            this.qualificationrepo = qualificationrepo;
        }
        public void AddQualificatonService(sp_fetch_qualifications_Result qualificatonservice)
        {
            string sp_name = "[sp_qualifications] {0},{1},{2}";
            object[] parameters = { "Insert", qualificatonservice.qualification_id, qualificatonservice.qualification_name };
            qualificationrepo.ExecuteCommand(sp_name, parameters);

        }
        public void UpdateQualificatonService(sp_fetch_qualifications_Result qualificatonservice)
        {
            string sp_name = "[sp_qualifications] {0},{1},{2}";
            object[] parameters = { "Update", qualificatonservice.qualification_id, qualificatonservice.qualification_name };
            qualificationrepo.ExecuteCommand(sp_name, parameters);

        }
        public void DeleteQualificatonService(int qualificatonservice_id)
        {
            string sp_name = "[sp_qualifications] {0},{1},{2}";
            object[] parameters = { "Delete", qualificatonservice_id, ""};
            qualificationrepo.ExecuteCommand(sp_name, parameters);

        }
        public void RestoreQualificatonService(int qualificatonservice_id)
        {
            string sp_name = "[sp_qualifications] {0},{1},{2}";
            object[] parameters = { "Restore", qualificatonservice_id, "",0 };
            qualificationrepo.ExecuteCommand(sp_name, parameters);

        }
        public List<sp_fetch_qualifications_Result> GetQualificatonServices()
        {
            string sp_name = "[sp_fetch_qualifications]{0}";
            object[] parameters = { 0 };
            return qualificationrepo.ExecuteQuery(sp_name, parameters).ToList();

        }
        public sp_fetch_qualifications_Result GetQualificatonService(int qualificatonservice_id)
        {
            string sp_name = "[sp_fetch_qualifications]{0}";
            object[] parameters = { qualificatonservice_id };
            return qualificationrepo.ExecuteQuery(sp_name, parameters).ToList().First();

        }

    }
}
