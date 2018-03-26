using DoWhileTrain.Contracts;
using DoWhileTrain.Models.DwtModels;
using DoWhileTrain.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace DoWhileTrain.Controllers
{
    [Authorize]
    public class TrainingWebApiController : ApiController
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingWebApiController(TrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        #region GET
        [Route("api/Training/get")]
        [HttpGet]
        public List<Training> Get()
        {
            return _trainingRepository.Get(User.Identity.GetUserId()).ToList();
        }
        #endregion

        #region POST
        [Route("api/Training/create")]
        [HttpPost]
        public Training Save(Training training)
        {
            training.OwnerId = User.Identity.GetUserId();
            return _trainingRepository.Create(training);
        }
        #endregion

        #region PATCH
        [Route("api/Training/update")]
        [HttpPatch]
        public Training Update(Training training)
        {
            return _trainingRepository.Update(training.Id, training);
        }
        #endregion

        #region DELTE
        [Route("api/Training/delete/{Id}")]
        [HttpDelete]
        public void Delete(int Id)
        {
            _trainingRepository.Delete(Id);
        }
        #endregion
    }
}