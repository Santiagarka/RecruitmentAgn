namespace RecruitmentAgency.Domain.Entities
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа<</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
