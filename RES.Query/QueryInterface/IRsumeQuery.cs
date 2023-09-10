using RES.Query.Query_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES.Query.QueryInterface
{
    public interface IRsumeQuery
    {
        Personalviewmodel pesonaldtails();
        AboutmeViewModels dtails();
        List<Skillviewmodel> skilles();
        List<Blogviewmodel> getbloglist();
        Blogviewmodel getblogdetails(long id);
    }
}
