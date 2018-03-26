using DoWhileTrain.Models.DwtModels;

namespace DoWhileTrain.Contracts
{
    public interface ITrainingTypesRepository : IBaseContract<TrainingType>
    {
        /// <summary>
        /// Получить тип тренировки по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Тип тренировки</returns>
        TrainingType Get(int id);
    }
}