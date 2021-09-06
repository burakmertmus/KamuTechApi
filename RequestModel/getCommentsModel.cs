using KamuTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamuTechApi.RequestModel
{
    public class GetCommentsModel
    {
        
        public int ComponetId { get; set; }
        public string PhotoUrl { get; set; }
        public string CommentPost { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Organisation { get; set; }

    }
}
