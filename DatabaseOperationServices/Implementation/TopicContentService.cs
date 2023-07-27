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
   public class TopicContentService:ITopicContentService
    {
       private IRepository<sp_fetch_tbTopic_Contents_Result> topiccontentrepo;
       public TopicContentService(IRepository<sp_fetch_tbTopic_Contents_Result> topiccontentrepo)
        {
            this.topiccontentrepo = topiccontentrepo;
        }
        public void AddTopiccontent(sp_fetch_tbTopic_Contents_Result topicscontent)
        {
            string sp_name = "[sp_tbTopic_Contents] {0},{1},{2},{3}";
            object[] parameters = { "Insert",topicscontent.content_id,topicscontent.content_name,topicscontent.topic_id };
            topiccontentrepo.ExecuteCommand(sp_name, parameters);
       
        }
       public void UpdateTopiccontent(sp_fetch_tbTopic_Contents_Result topicscontent)
        {
            string sp_name = "[sp_tbTopic_Contents] {0},{1},{2},{3}";
            object[] parameters = { "Update", topicscontent.content_id, topicscontent.content_name, topicscontent.topic_id };
            topiccontentrepo.ExecuteCommand(sp_name, parameters);

        }
       public void DeleteTopiccontent(int topicscontent_id)
        {
            string sp_name = "[sp_tbTopic_Contents] {0},{1},{2},{3}";
            object[] parameters = { "Delete", topicscontent_id, "" ,1};
            topiccontentrepo.ExecuteCommand(sp_name, parameters);

        }
       public void RestoreTopiccontent(int topicscontent_id)
        {
            string sp_name = "[sp_tbTopic_Contents] {0},{1},{2},{3}";
            object[] parameters = { "Restore", topicscontent_id, "",0 };
            topiccontentrepo.ExecuteCommand(sp_name, parameters);

        }
       public List<sp_fetch_tbTopic_Contents_Result> GetTopiccontents()
        {
            string sp_name = "[sp_fetch_tbTopic_Contents]{0}";
            object[] parameters = { 0 };
            return topiccontentrepo.ExecuteQuery(sp_name, parameters).ToList();
        
        }
      public  sp_fetch_tbTopic_Contents_Result GetTopiccontent(int topicscontent_id)
 {
            string sp_name = "[sp_fetch_tbTopic_Contents]{0}";
            object[] parameters = { topicscontent_id };
            return topiccontentrepo.ExecuteQuery(sp_name, parameters).ToList().First();
        
        }


    }
}
