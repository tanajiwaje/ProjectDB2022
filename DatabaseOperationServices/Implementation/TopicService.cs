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
    public class TopicService : ITopicService
    {
        private IRepository<sp_fetch_tbTopics_Result> topicrepo;
        public TopicService(IRepository<sp_fetch_tbTopics_Result> topicrepo)
        {
            this.topicrepo = topicrepo;
        }
        public void AddTopic(sp_fetch_tbTopics_Result topic)
        {
            string sp_name = "[sp_tblTopics] {0},{1},{2}";
            object[] parameters = { "Insert", topic.topic_id, topic.topic_name };
            topicrepo.ExecuteCommand(sp_name, parameters);

        }
        public void UpdateTopic(sp_fetch_tbTopics_Result topic)
        {
            string sp_name = "[sp_tblTopics] {0},{1},{2}";
            object[] parameters = { "Update", topic.topic_id, topic.topic_name };
            topicrepo.ExecuteCommand(sp_name, parameters);

        }
        public void DeleteTopic(int topic_id)
        {
            string sp_name = "[sp_tblTopics] {0},{1},{2}";
            object[] parameters = { "Delete", topic_id, "" };
            topicrepo.ExecuteCommand(sp_name, parameters);

        }
        public void RestoreTopic(int topic_id)
        {
            string sp_name = "[sp_tblTopics] {0},{1},{2}";
            object[] parameters = { "Restore", topic_id, "" };
            topicrepo.ExecuteCommand(sp_name, parameters);

        }
        public List<sp_fetch_tbTopics_Result> GetTopics()
        {
            string sp_name = "[sp_fetch_tbTopics]{0}";
            object[] parameters = { 0 };
            return topicrepo.ExecuteQuery(sp_name, parameters).ToList();

        }
        public sp_fetch_tbTopics_Result GetTopic(int topic_id)
        {
            string sp_name = "[sp_fetch_tbTopics]{0}";
            object[] parameters = { topic_id };
            return topicrepo.ExecuteQuery(sp_name, parameters).ToList().First();

        }
        
    }
}
