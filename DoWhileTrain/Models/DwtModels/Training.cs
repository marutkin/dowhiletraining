using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoWhileTrain.Models.DwtModels
{
    public class Training
    {
        public int Id { get; set; }
        public int WorkCount { get; set; }
        public DateTime WorkoutDate { get; set; }
        /// <summary>
        /// Ссылка на тип тренировки
        /// </summary>
        public int TypeId { get; set; }
        public virtual TrainingType Type { get; set; }
        /// <summary>
        /// Ссылка на пользователя создавшего тренировку
        /// </summary>
        public string OwnerId { get; set; }
        public virtual BodyBuilder Owner { get; set; }
    }
}