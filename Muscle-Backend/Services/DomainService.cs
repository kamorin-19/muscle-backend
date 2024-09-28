using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Services
{
    public class DomainService
    {
        /// <summary>
        /// 部位マスタの重複チェックを行う
        /// </summary>
        /// <param name="bodyPart"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool ValidateBodyPartDuplicates(BodyPart bodyPart)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.BodyParts.Where(x => x.Name == bodyPart.Name).ToList().Count;

                if (recordCount > 0)
                {
                    return false;
                }

                return true;

            }
        }

        /// <summary>
        /// 種目マスタの重複チェックを行う
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool ValidateExercisesDuplicates(Exercise exercise)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.Exercises.Where(x => x.Name == exercise.Name).ToList().Count;

                if (recordCount > 0)
                {
                    return false;
                }

                return true;

            }
        }
    }
}
