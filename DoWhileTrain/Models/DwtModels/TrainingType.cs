using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoWhileTrain.Models.DwtModels
{
    public class TrainingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Силовая или Кардио тренировка
        public bool IsCardio { get; set; }
        /// <summary>
        /// Ссылка на тип тренажера
        /// </summary>
        public int ApparatId { get; set; }
        public virtual TrainingApparat Apparat { get; set; }
        /// <summary>
        /// Ссылка на пользователя создавшего тренировку
        /// </summary>
        public string OwnerId { get; set; }
        public virtual BodyBuilder Owner { get; set; }
    }
}