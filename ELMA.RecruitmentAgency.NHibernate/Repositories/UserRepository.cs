using NHibernate;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;

namespace RecruitmentAgency.NHibernate.Repositories
{
    /// <summary>
    /// Репозиторий сущности <see cref="User"/>
    /// </summary>
    public class UserRepository : NHRepositoryBase<User, int>, IUserRepository
    {
        /// <summary>
        /// Конструктор экземпляра <see cref="UserRepository"/>
        /// </summary>
        /// <param name="session">Сессия NHibernate</param>
        public UserRepository(ISession session) 
            : base(session)
        {
        }
    }
}
