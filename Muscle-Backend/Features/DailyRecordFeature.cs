using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class DailyRecordFeature : BaseInterface<DailyRecord>
    {
        public IEnumerable<DailyRecord> SelectRecords(DailyRecord featureType)
        {
            using (var db = new SystemContext())
            {
                return db.DailyRecords.Where(x => x.IsDeleted == false).ToList();
            }
        }

        public void InsertRecord(DailyRecord featureType)
        {
            using (var db = new SystemContext())
            {
                // 最新のIDを取得(自動インクリメントにしたい
                var dailyRecord = db.DailyRecords.OrderBy(x => x.ExercisePId).Last();
                var maxId = dailyRecord == null ? 0 : dailyRecord.DailyRecordId + 1;
                db.Add(new DailyRecord { DailyRecordId = maxId,
                                         EnforcementDay = new DateOnly(2024, 8, 24),
                                         ExercisePId = 1,
                                         FirstSetCount = 0,
                                         SecondSetCount = 0,
                                         ThirdSetCount = 0,
                                         FourthSetCount = 0,
                                         FifthSetCount = 0
                                       });
                db.SaveChanges();
            }
        }

        public void UpdateRecord(DailyRecord featureType)
        {
            using (var db = new SystemContext())
            {
                // ★名前の重複は不可にする、サービスを追加する？
                var dailyRecord = db.DailyRecords.FirstOrDefault(x => x.DailyRecordId == featureType.DailyRecordId);
                if (dailyRecord != null)
                {
                    // 更新処理
                    dailyRecord.FifthSetCount = 10;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteRecord(DailyRecord featureType)
        {
            using (var db = new SystemContext())
            {
                var dailyRecord = db.DailyRecords.FirstOrDefault(x => x.DailyRecordId == featureType.DailyRecordId);
                if (dailyRecord != null)
                {
                    dailyRecord.IsDeleted = true;
                    db.SaveChanges();
                }
            }
        }
    }

}
