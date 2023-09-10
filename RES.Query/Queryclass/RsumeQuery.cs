
using RES.Query.Query_models;
using RES.Query.QueryInterface;
using RES.Services.Interface;

namespace RES.Query.Queryclass
{
    public class RsumeQuery: IRsumeQuery
    {
        private readonly IUnitOfWork _unit;

        public RsumeQuery(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public Personalviewmodel pesonaldtails()
        {
            var x = _unit.PersonalUW.Get().Take(1).Single();
            return new Personalviewmodel()
            {
                Name = x.Name,
                Adress = x.Adress,
                Email = x.Email,
                skype = x.skype,
                Image = x.Image,
                Expertise = x.Expertise,
                BrithdatDateTime = x.BrithdatDateTime,
            };

            

        }

        public virtual AboutmeViewModels dtails()
        {
            var model = _unit.IdoUW.Get().Select(x => new whatidoviewmodel()
            {
                title = x.title,
                descrrripton = x.descrrripton,
                img = x.img
            });
            var des = _unit.aboutmeUw.Get().Take(1).Single();
            return new AboutmeViewModels()
            {
                Description = des.Description,
                whatidolist = model.ToList()
            };

        }

        public List<Skillviewmodel> skilles()
        {
            return _unit.skilluw.Get().Select(x => new Skillviewmodel()
            {
                subject = x.subject,
                ability = x.ability

            }).ToList();

        }

        public List<Blogviewmodel> getbloglist()
        {
            return _unit.blogAggUW.Get().Select(x => new Blogviewmodel()
            {
                Id = x.Id,
                tiltle = x.tiltle,
                descrrpition = x.descrrpition,
                img = x.img,
                time = x.time
            }).ToList();
        }

        public Blogviewmodel getblogdetails(long id)
        {

            var x = _unit.blogAggUW.getbyid(id);
            return new Blogviewmodel()
            {
                Id = x.Id,
                descrrpition = x.descrrpition,
                img = x.img,
                tiltle = x.tiltle,
            };
        }
    }
}
