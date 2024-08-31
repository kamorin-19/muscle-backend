using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class ExerciseFeature : BaseInterface<Exercise>
    {
        public IEnumerable<Exercise> SelectRecords()
        {
            using (var db = new SystemContext())
            {
                return db.Exercises.Where(x => x.IsDeleted == false).ToList();
            }
        }

        public void InsertRecord(Exercise featureType)
        {
            using (var db = new SystemContext())
            {
                // 最新のIDを取得(自動インクリメントにしたい
                var excercise = db.Exercises.OrderBy(x => x.ExercisePId).Last();
                var maxId = excercise == null ? 0 : excercise.ExercisePId + 1;
                db.Add(new Exercise { ExercisePId = maxId, Name = "ランジ", Weight = 0.2, BodyPartId = 1 });
                db.SaveChanges();
            }
        }

        public void UpdateRecord(Exercise featureType)
        {
            using (var db = new SystemContext())
            {
                // ★名前の重複は不可にする、サービスを追加する？
                var excercise = db.Exercises.FirstOrDefault(x => x.ExercisePId == featureType.ExercisePId);
                if (excercise != null)
                {
                    // 更新処理
                    excercise.Name = "ブルガリアンスクワット";
                    db.SaveChanges();
                }
            }
        }

        public void DeleteRecord(Exercise featureType)
        {
            using (var db = new SystemContext())
            {
                var excercise = db.Exercises.FirstOrDefault(x => x.ExercisePId == featureType.ExercisePId);
                if (excercise != null)
                {
                    excercise.IsDeleted = true;
                    db.SaveChanges();
                }
            }
        }
    }

}
