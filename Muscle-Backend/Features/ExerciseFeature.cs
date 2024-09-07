using Microsoft.EntityFrameworkCore;
using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class ExerciseFeature : BaseMasterInterface<Exercise>
    {
        /// <summary>
        /// 種目マスタを読み込み、絞りこみは行わない
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Exercise> SelectRecords()
        {
            using (var db = new SystemContext())
            {
                return db.Exercises
                   .Include(x => x.BodyPart)
                   .Where(x => x.IsDeleted == false)
                   .ToList();
            }
        }

        /// <summary>
        /// 種目マスタを挿入する
        /// </summary>
        /// <returns></returns>
        public bool InsertRecord(Exercise exercise)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.Exercises.Where(x => x.Name == exercise.Name).ToList().Count;

                if (recordCount > 0)
                {
                    return false;
                }

                var newExercises = new Exercise
                {
                    Name = exercise.Name
                };

                // データベースに新しいオブジェクトを追加
                db.Exercises.Add(newExercises);
                db.SaveChanges();

                return true;

            }
        }

        /// <summary>
        /// 種目マスタを更新する
        /// </summary>
        /// <returns></returns>
        public bool UpdateRecord(Exercise exercise)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.BodyParts.Where(x => x.Name == exercise.Name).ToList().Count;

                if (recordCount > 0)
                {
                    return false;
                }

                var updateExercise = db.Exercises.FirstOrDefault(x => x.ExercisePId == exercise.ExercisePId);
                if (updateExercise != null)
                {
                    // 更新処理
                    updateExercise.Name = exercise.Name;
                    updateExercise.Weight = exercise.Weight;
                    updateExercise.BodyPartId = exercise.BodyPart.BodyPartId;
                    db.SaveChanges();

                }
                return true;
            }
        }

        /// <summary>
        /// 種目マスタを削除する
        /// </summary>
        public bool DeleteRecord(Exercise exercise)
        {
            using (var db = new SystemContext())
            {
                var deleteExercise = db.Exercises.FirstOrDefault(x => x.ExercisePId == exercise.ExercisePId);
                if (deleteExercise != null)
                {
                    deleteExercise.IsDeleted = true;
                    db.SaveChanges();
                }
                return true;
            }
        }
    }

}
