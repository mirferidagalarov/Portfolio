using Entities.Concrete.TableModels;

namespace Entities.Concrete.ViewModels
{
    public class HomeViewModel
    {
        public Person People { get; set; }
        public List<AboutSkill> AboutSkills { get; set; }
        public List<Experience> Experience { get; set; }
        public List<Position> Positions { get; set; }  
        public  List<Service> Services { get; set; }
        public List<Skill> Skill { get; set; }
        public List<WorkCategory> WorkCategories { get; set; }
        public List<Portfoli> Portfolis { get; set; }

    }
}
