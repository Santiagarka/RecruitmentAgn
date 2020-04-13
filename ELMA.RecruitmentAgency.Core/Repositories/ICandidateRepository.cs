using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.Core.Repositories
{
    /// <summary>
    /// Репозиторий для сущности <see cref="Candidate"/>
    /// </summary>
    public interface ICandidateRepository : IRepository<Candidate>
    {
    }
}
