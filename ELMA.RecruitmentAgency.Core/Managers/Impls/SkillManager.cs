using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Managers.Impls
{
    public class SkillManager : ISkillManager
    {
        private readonly ISkillRepository skillRepository;

        public SkillManager(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }
        public Skill Get(int id)
        {
            return skillRepository.FirstOrDefault(id);
        }

        public ICollection<Skill> GetAll()
        {
            return skillRepository.GetAllList();
        }
    }
}
