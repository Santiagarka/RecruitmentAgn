using NHibernate;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;

namespace RecruitmentAgency.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="Skill"/>
    /// </summary>
    public class SkillRepository : NHRepositoryBase<Skill, int>, ISkillRepository
    {
        /// <summary>
        /// Конструктор экземпляра <see cref="SkillRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public SkillRepository(ISession session)
            : base(session)
        {
        }
    }
}
