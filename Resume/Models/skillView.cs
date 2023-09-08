using RES.ApplicationContract.Skillvview;
using RES.Domin.Skills;

namespace Resume.Models
{
    public class skillView
    {
        public CreateSkill Skill { get; set; }
        public List<Skill> List { get; set; }
    }
}
