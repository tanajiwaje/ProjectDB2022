using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface ITopicService
    {
        void AddTopic(sp_fetch_tbTopics_Result topic);
        void UpdateTopic(sp_fetch_tbTopics_Result topic);
        void DeleteTopic(int topic_id);
        void RestoreTopic(int topic_id);
        List<sp_fetch_tbTopics_Result> GetTopics();
        sp_fetch_tbTopics_Result GetTopic(int topic_id);

    }
}
