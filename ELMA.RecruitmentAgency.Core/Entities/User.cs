﻿using RecruitmentAgency.Domain.Entities;

namespace RecruitmentAgency.Core.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User:Entity
    {
        /// <summary>
        /// Имя таблицы
        /// </summary>
        public const string TableName = "Users";

        /// <summary>
        /// Логин
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
