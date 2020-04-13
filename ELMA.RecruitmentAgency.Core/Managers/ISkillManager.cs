using RecruitmentAgency.Core.Entities;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Managers
{
    public interface ISkillManager
    {
        Skill Get(int id);

        ICollection<Skill> GetAll();
    }
}
