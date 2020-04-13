using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.Core.Repositories
{
    /// <summary>
    /// Репозиторий для сущности <see cref="User"/>
    /// </summary>
    public interface IUserRepository :IRepository<User>
    {
    }
}
