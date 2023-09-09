using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RES.Query.QueryInterface;

namespace Resume.ViewComponents
{
    [ViewComponent(Name = "PersonalDtails")]
    public class Personaldtails:ViewComponent
    {
        private readonly IRsumeQuery _query;

        public Personaldtails(IRsumeQuery query)
        {
            _query = query;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
             return View("Index", _query.pesonaldtails());
        }
}
}
