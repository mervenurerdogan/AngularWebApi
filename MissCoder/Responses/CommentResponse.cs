using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissCoder.Responses
{
    public class CommentResponse
    {

        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string ContentMain { get; set; }
        public DateTime PublishDate { get; set; }

        public ArticleResponse Article { get; set; }
    }
}
