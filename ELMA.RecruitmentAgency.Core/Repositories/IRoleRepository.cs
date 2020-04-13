using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.Core.Repositories
{
    /// <summary>
    /// Репозиторий для сущности <see cref="Role"/>
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
    }
}
