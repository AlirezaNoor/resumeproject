using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES.Query.Query_models
{
    public class AboutmeViewModels
    {
        public string Description { get; set; }
        public List<whatidoviewmodel> whatidolist { get; set; }

    }


    public class whatidoviewmodel
    {
        public string title { get; set; }
        public string descrrripton { get; set; }
        public string img { get; set; }
    }
}
