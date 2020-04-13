using NHibernate;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;

namespace RecruitmentAgency.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="Candidate"/>
    /// </summary>
    public class CandidateRepository : NHRepositoryBase<Candidate, int>, ICandidateRepository
    {
        /// <summary>
        /// Конструктор экземпляра <see cref="CandidateRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public CandidateRepository(ISession session) : base(session)
        {
        }
    }
}
