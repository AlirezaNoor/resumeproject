using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RES.Domin.Whatido;

namespace RES.Services.Interface.CustomRepository
{
    public interface IIdoRepository
    {
        void create(List<Ido> idos);
    }
}
