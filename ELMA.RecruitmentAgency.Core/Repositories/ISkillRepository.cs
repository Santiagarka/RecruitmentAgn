using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.Core.Repositories
{
    /// <summary>
    /// Репозиторий для сущности <see cref="Skill"/>
    /// </summary>
    public interface ISkillRepository : IRepository<Skill>
    {
    }
}
