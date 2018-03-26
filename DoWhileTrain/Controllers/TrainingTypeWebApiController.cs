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
    public class TrainingTypeWebApiController : ApiController
    {
        private readonly ITrainingTypesRepository _trainingTypesRepository;

        public TrainingTypeWebApiController(TrainingTypesRepository trainingTypesRepository)
        {
            _trainingTypesRepository = trainingTypesRepository;
        }

        #region GET
        [Route("api/trainingtype/get/{Id}")]
        [HttpGet]
        public TrainingType Get(int Id)
        {
            return _trainingTypesRepository.Get(Id);
        }
        [Route("api/trainingtype/get")]
        [HttpGet]
        public List<TrainingType> Get()
        {
            return _trainingTypesRepository.Get(User.Identity.GetUserId());
        }
        #endregion

        #region POST
        [Route("api/trainingtype/create")]
        [HttpPost]
        public TrainingType Create(TrainingType trainingType)
        {
            if (trainingType.Name == null) return null;
            trainingType.OwnerId = User.Identity.GetUserId();
            return _trainingTypesRepository.Create(trainingType);
        }
        #endregion     
        
        #region PATCH
        [Route("api/trainingtype/update")]
        [HttpPatch]
        public TrainingType Update(int id)
        {
            return _trainingTypesRepository.Get(id);
        }
        #endregion    
        
        #region Delete
        [Route("api/trainingtype/delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _trainingTypesRepository.Delete(id);
        }
        #endregion
    }
}