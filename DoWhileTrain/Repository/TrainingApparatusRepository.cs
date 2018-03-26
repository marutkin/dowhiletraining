using DoWhileTrain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoWhileTrain.Models.DwtModels;
using DoWhileTrain.Models;

namespace DoWhileTrain.Repository
{
    public class TrainingApparatusRepository : BaseRepository<TrainingApparat>, ITrainingApparatusRepository
    {
        public TrainingApparatusRepository(DwtDbContext context) : base(context) { }

        public override TrainingApparat Create(TrainingApparat trainingApparat)
        {
            _context.TrainingApparatus.Add(trainingApparat);
            _context.SaveChanges();
            return trainingApparat;
        }

        public override void Delete(int id)
        {
            var tt = _context.TrainingApparatus.FirstOrDefault(t => t.Id == id);
            if (tt == null) return;
            _context.TrainingApparatus.Remove(tt);
            _context.SaveChanges();
        }

        public override List<TrainingApparat> Get(string ownerId)
        {
            var result = _context.TrainingApparatus
                .Where(t => t.OwnerId == ownerId)
                .ToList();
            foreach (var res in result)
            {
                res.Owner = null;
                res.OwnerId = "";
            }
            return result;
        }

        public override TrainingApparat Update(int id, TrainingApparat trainingApparat)
        {
            var tt = _context.TrainingApparatus.Find(id);
            if (tt == null) return tt;
            _context.Entry(tt).CurrentValues.SetValues(trainingApparat);
            _context.SaveChanges();

            return tt;
        }
    }
}