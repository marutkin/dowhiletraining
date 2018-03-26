using Microsoft.AspNet.Identity.EntityFramework;
using DoWhileTrain.Models.DwtModels;
using System.Data.Entity;

namespace DoWhileTrain.Models
{
    public class DwtDbContext : IdentityDbContext<BodyBuilder>
    {
        public DwtDbContext()
            : base("DWTrainConnection", throwIfV1Schema: false)
        {
        }

        public static DwtDbContext Create()
        {
            return new DwtDbContext();
        }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<TrainingApparat> TrainingApparatus { get; set; }
    }
}