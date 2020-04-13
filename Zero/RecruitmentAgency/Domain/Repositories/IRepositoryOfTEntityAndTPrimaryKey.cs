using RecruitmentAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RecruitmentAgency.Domain.Repositories
{

    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа сущности</typeparam>
    public interface IRepository<TEntity, TPrimaryKey>:IRepository
        where TEntity: class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Сохранение сущности в репозитории
        /// </summary>
        /// <param name="entity">Сохраняемая сущность</param>
        /// <returns></returns>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Чтение сущности из репозитория
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns></returns>
        TEntity Read(TPrimaryKey id);

        /// <summary>
        /// Обновление сущности в репозитории
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Уделение сущности из репозитория
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Получить список всех сущностей
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAllList();

        /// <summary>
        /// Получить сущность или стандартное значение по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>TEntity</returns>
        TEntity FirstOrDefault(TPrimaryKey id);

        /// <summary>
        /// Получить сущность или null
        /// </summary>
        /// <param name="predicate">Условие</param>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}
