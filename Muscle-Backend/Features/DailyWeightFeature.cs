using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class DailyWeightFeature : BaseInterface<DailyWeight>
    {
        public IEnumerable<DailyWeight> SelectRecords()
        {
            using (var db = new SystemContext())
            {
                return db.DailyWeights.Where(x => x.IsDeleted == false).ToList();
            }
        }

        public void InsertRecord(DailyWeight featureType)
        {
            using (var db = new SystemContext())
            {
                // 最新のIDを取得(自動インクリメントにしたい
                var dailyweight = db.DailyWeights.OrderBy(x => x.DailyWeightId).Last();
                var maxId = dailyweight == null ? 0 : dailyweight.DailyWeightId + 1;
                db.Add(new DailyWeight { DailyWeightId = maxId,
                                         RecordedDay = new DateOnly(2024, 8, 24),
                                         Weight = 1.0
                                       });
                db.SaveChanges();
            }
        }

        public void UpdateRecord(DailyWeight featureType)
        {
            using (var db = new SystemContext())
            {
                // ★名前の重複は不可にする、サービスを追加する？
                var dailyweight = db.DailyWeights.FirstOrDefault(x => x.DailyWeightId == featureType.DailyWeightId);
                if (dailyweight != null)
                {
                    // 更新処理
                    dailyweight.Weight = 10.0;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteRecord(DailyWeight featureType)
        {
            using (var db = new SystemContext())
            {
                var dailyweight = db.DailyWeights.FirstOrDefault(x => x.DailyWeightId == featureType.DailyWeightId);
                if (dailyweight != null)
                {
                    dailyweight.IsDeleted = true;
                    db.SaveChanges();
                }
            }
        }
    }

}
