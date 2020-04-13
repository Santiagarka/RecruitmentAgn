using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;

using NHibernate;

namespace RecruitmentAgency.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="Role"/>
    /// </summary>
    public class RoleRepository: NHRepositoryBase<Role, int>, IRoleRepository
    {

        /// <summary>
        /// Конструктор экземпляра <see cref="RoleRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public RoleRepository(ISession session)
            :base(session)
        {
        }
    }
}
