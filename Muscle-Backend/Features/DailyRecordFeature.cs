using Microsoft.EntityFrameworkCore;
using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class DailyRecordFeature : BaseInterface<DailyRecord>
    {
        public IEnumerable<DailyRecord> SelectRecords()
        {
            using (var db = new SystemContext())
            {

                return db.DailyRecords.Include(x => x.Exercise)
                   .Where(x => x.IsDeleted == false)
                   .ToList();
            }
        }

        public void InsertRecord(DailyRecord dailyRecord)
        {
            using (var db = new SystemContext())
            {
                var newDailyRecord = new DailyRecord
                {
                    EnforcementDay = dailyRecord.EnforcementDay,
                    ExercisePId = dailyRecord.Exercise.ExercisePId,
                    FirstSetCount = dailyRecord.FirstSetCount,
                    SecondSetCount = dailyRecord.SecondSetCount,
                    ThirdSetCount = dailyRecord.ThirdSetCount,
                    FourthSetCount = 0,
                    FifthSetCount = 0
                };

                // データベースに新しいオブジェクトを追加
                db.DailyRecords.Add(newDailyRecord);
                db.SaveChanges();

                return;
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
