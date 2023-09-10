using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES.Query.Query_models
{
    public class Blogviewmodel
    {
        public long Id { get; set; }
        public string tiltle { get; set; }
        public string descrrpition { get; set; }
        public string img { get; set; }
        public DateTime time { get; set; }
    }
}
