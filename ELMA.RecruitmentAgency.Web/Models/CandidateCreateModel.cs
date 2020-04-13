using Microsoft.AspNetCore.Http;
using RecruitmentAgency.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentAgency.Web.Models
{
    public class CandidateCreateModel
    {
        /// <summary>
        /// Новый экземпляр
        /// </summary>
        public static CandidateCreateModel New
        {
            get { return new CandidateCreateModel(); }
        }

        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("ФИО")]
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Опыт работы (количество лет)
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Опыт работы")]
        public uint Experience { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public string FotoURL { get; set; }

        /// <summary>
        /// Скиллы
        /// </summary>
        [DisplayName("Скиллы")]
        public IEnumerable<int> SkillsId { get; set; }

        /// <summary>
        /// Ожидаемая зарплата
        /// </summary>
        [Required(ErrorMessage = "Заполните обязательное поле")]
        [DisplayName("Ожидаемая зарплата")]
        public decimal Salary { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        public int CreatorId { get; set; }

        public IFormFile Foto { set; get; }

        public CandidateCreateModel()
        {
            SkillsId = new List<int>();
        }
    }
}
