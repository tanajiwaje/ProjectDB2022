using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabaseOperation;
namespace DatabaseOperationServices.Interface
{
   public interface ITopicContentService
    {
        void AddTopiccontent(sp_fetch_tbTopic_Contents_Result topicscontent);
        void UpdateTopiccontent(sp_fetch_tbTopic_Contents_Result topicscontent);
        void DeleteTopiccontent(int topicscontent_id);
        void RestoreTopiccontent(int topicscontent_id);
        List<sp_fetch_tbTopic_Contents_Result> GetTopiccontents();
        sp_fetch_tbTopic_Contents_Result GetTopiccontent(int topicscontent_id);

    }
}
