namespace RecruitmentAgency.Runtime.Session
{
    /// <summary>
    /// Определяет информацию о сеансе
    /// </summary>
    public interface IAppSession
    {
        /// <summary>
        /// Логин текущего пользователя
        /// </summary>
        string UserLogin { get; }
    }
}
