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

        public void InsertRecord(DailyWeight dailyWeight)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.DailyWeights.Where(x => x.RecordedDay == dailyWeight.RecordedDay).ToList().Count;

                if (recordCount > 0)
                {
                    return;
                }

                var newDailyWeight = new DailyWeight
                {
                    RecordedDay = dailyWeight.RecordedDay,
                    Weight = dailyWeight.Weight,
                };

                // データベースに新しいオブジェクトを追加
                db.DailyWeights.Add(newDailyWeight);
                db.SaveChanges();

                return;

            }
        }

        public void UpdateRecord(DailyWeight dailyWeight)
        {
            using (var db = new SystemContext())
            {
                // ★名前の重複は不可にする、サービスを追加する？
                var updatedDailyweight = db.DailyWeights.FirstOrDefault(x => x.DailyWeightId == dailyWeight.DailyWeightId);
                if (updatedDailyweight != null)
                {
                    // 更新処理
                    updatedDailyweight.Weight = dailyWeight.Weight;
                    updatedDailyweight.RecordedDay = dailyWeight.RecordedDay;
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
