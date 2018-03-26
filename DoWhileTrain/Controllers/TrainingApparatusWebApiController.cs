using DoWhileTrain.Contracts;
using DoWhileTrain.Models.DwtModels;
using DoWhileTrain.Repository;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;

namespace DoWhileTrain.Controllers
{
    [Authorize]
    public class TrainingApparatusWebApiController : ApiController
    {
        private readonly ITrainingApparatusRepository _trainingApparatusRepository;

        public TrainingApparatusWebApiController(TrainingApparatusRepository trainingApparatusRepository)
        {
            _trainingApparatusRepository = trainingApparatusRepository;
        }

        #region GET
        [Route("api/trainingApparat/get")]
        [HttpGet]
        public List<TrainingApparat> Get()
        {
            return _trainingApparatusRepository.Get(User.Identity.GetUserId());
        }
        #endregion

        #region POST
        [Route("api/trainingApparat/create")]
        [HttpPost]
        public TrainingApparat Save(TrainingApparat trainingApparat)
        {
            if (trainingApparat.Name == null) return null;
            trainingApparat.OwnerId = User.Identity.GetUserId();
            return _trainingApparatusRepository.Create(trainingApparat);
        }
        #endregion

        #region PATCH
        [Route("api/trainingApparat/update")]
        [HttpPatch]
        public TrainingApparat Update(TrainingApparat trainingApparat)
        {
            return _trainingApparatusRepository.Update(trainingApparat.Id, trainingApparat);
        }
        #endregion

        #region DELTE
        [Route("api/trainingApparat/delete/{Id}")]
        [HttpDelete]
        public void Delete(int Id)
        {
            _trainingApparatusRepository.Delete(Id);
        }
        #endregion
    }
}