using DoWhileTrain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoWhileTrain.Models.DwtModels;
using DoWhileTrain.Models;

namespace DoWhileTrain.Repository
{
    public class TrainingRepository : BaseRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(DwtDbContext context) : base(context) { }

        public override Training Create(Training training)
        {
            training.WorkoutDate = DateTime.Now;
            _context.Trainings.Add(training);
            _context.SaveChanges();
            return training;
        }

        public override void Delete(int id)
        {
            var tt = _context.Trainings.FirstOrDefault(t => t.Id == id);
            if (tt == null) return;
            _context.Trainings.Remove(tt);
            _context.SaveChanges();
        }

        public override List<Training> Get(string ownerId)
        {
            var result = _context.Trainings
                .Where(t => t.OwnerId == ownerId)
                .ToList();
            foreach (var res in result)
            {
                res.Owner = null;
                res.OwnerId = "";
            }
            return result;
        }

        public override Training Update(int id, Training training)
        {
            var tt = _context.Trainings.Find(id);
            if (tt == null) return tt;
            _context.Entry(tt).CurrentValues.SetValues(training);
            _context.SaveChanges();

            return tt;
        }
    }
}