
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
    }
}
