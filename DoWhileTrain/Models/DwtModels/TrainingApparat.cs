using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoWhileTrain.Models.DwtModels
{
    public class TrainingApparat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на пользователя создавшего тренировку
        /// </summary>
        public string OwnerId { get; set; }
        public virtual BodyBuilder Owner { get; set; }
    }
}