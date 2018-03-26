using DoWhileTrain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoWhileTrain.Models.DwtModels;
using DoWhileTrain.Models;

namespace DoWhileTrain.Repository
{
    public class TrainingTypesRepository : BaseRepository<TrainingType>, ITrainingTypesRepository
    {
        public TrainingTypesRepository(DwtDbContext context) : base(context) { }
        /// <summary>
        /// Создать тип тренировки
        /// </summary>
        public override TrainingType Create(TrainingType trainingType)
        {
            _context.TrainingTypes.Add(trainingType);
            _context.SaveChanges();
            return trainingType;
        }
        /// <summary>
        /// Удалить тип тренировки
        /// </summary>
        public override void Delete(int id)
        {
            var tt = _context.TrainingTypes.FirstOrDefault(t => t.Id == id);
            if (tt == null) return;
            _context.TrainingTypes.Remove(tt);
            _context.SaveChanges();
        }

        /// <summary>
        /// Получить все типы тренировок пользователя
        /// </summary>
        /// <param name="ownerId">ID пользователя</param>
        /// <param name="getall">Флаг, получить все типы тренировок из базы</param>
        /// <returns></returns>
        public override List<TrainingType> Get(string ownerId)
        {
            var result = _context.TrainingTypes
                .Where(t => t.OwnerId == ownerId)
                .ToList();
            foreach (var res in result)
            {
                res.Apparat.Owner = null;
                res.Apparat.OwnerId = "";
                res.Owner = null;
                res.OwnerId = "";
            }
            return result;
        }
        /// <summary>
        /// Получить тип тренировки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TrainingType Get(int id)
        {
            return _context.TrainingTypes.FirstOrDefault(t => t.Id == id);
        }
        /// <summary>
        /// Обновить тип тренировки
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trainingType"></param>
        public override TrainingType Update(int id, TrainingType trainingType)
        {
            var tt = _context.TrainingTypes.Find(id);
            if (tt == null) return tt;
            _context.Entry(tt).CurrentValues.SetValues(trainingType);
            _context.SaveChanges();

            return tt;
        }
    }
}