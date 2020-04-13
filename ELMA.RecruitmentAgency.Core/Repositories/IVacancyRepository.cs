using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.Core.Repositories
{
    /// <summary>
    /// Репозиторий для сущности <see cref="Vacancy"/>
    /// </summary>
    public interface IVacancyRepository : IRepository<Vacancy>
    {
        void CreateProc(Vacancy entity);
    }
}
