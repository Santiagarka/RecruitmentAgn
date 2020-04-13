using System.Linq;

using RecruitmentAgency.Domain.Entities;
using RecruitmentAgency.Domain.Repositories.Impls;

using NHibernate;


namespace RecruitmentAgency.NHibernate.Repositories
{

    /// <summary>
    /// Базовый репозиторий NHibernate
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа</typeparam>
    public class NHRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Сессия
        /// </summary>
        public virtual ISession Session { get; }

        /// <summary>
        /// Конструктор экземпляра <see cref="NHRepositoryBase{TEntity, TPrimaryKey}"/>
        /// </summary>
        /// <param name="session"></param>
        public NHRepositoryBase(ISession session)
        {
            Session = session;
        }

        public override TEntity Create(TEntity entity)
        {
            Session.Save(entity);
            Session.Flush(); //Не правильно, только для тестов работы приложения
            return entity;
        }

        public override TEntity Update(TEntity entity)
        {
            Session.Update(entity);
            Session.Flush(); //Не правильно, только для тестов работы приложения
            return entity;
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Session.Load<TEntity>(id);
            Session.Delete(entity);
            Session.Flush(); //Не правильно, только для тестов работы приложения
        }

        public override IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        
    }
}
