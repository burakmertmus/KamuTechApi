using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamuTechApi.RequestModel
{
    public class UpdateCardModel
    {
        public string PhotoUrl { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
