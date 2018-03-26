using System.Collections.Generic;

namespace DoWhileTrain.Contracts
{
    public interface IBaseContract<T>
    {
        /// <summary>
        /// Получить все данные для пользователя, типа - Т
        /// </summary>
        /// <param name="ownerId">GUID пользователя (владельца)ы</param>
        /// <returns></returns>
        List<T> Get(string ownerId);
        /// <summary>
        /// Создать
        /// </summary>
        /// <returns></returns>
        T Create(T trainingType);
        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trainingType"></param>
        T Update(int id, T trainingType);
        /// <summary>
        /// Удалить
        /// </summary>
        void Delete(int id);
    }
}
