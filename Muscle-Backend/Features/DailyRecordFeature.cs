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
                   .ThenInclude(y => y.BodyPart)
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

        public void UpdateRecord(DailyRecord dailyRecord)
        {
            using (var db = new SystemContext())
            {
                var updateDailyRecord = db.DailyRecords.FirstOrDefault(x => x.DailyRecordId == dailyRecord.DailyRecordId);
                if (updateDailyRecord != null)
                {
                    // 更新処理
                    updateDailyRecord.EnforcementDay = dailyRecord.EnforcementDay;
                    updateDailyRecord.ExercisePId = dailyRecord.ExercisePId;
                    updateDailyRecord.FirstSetCount = dailyRecord.FirstSetCount;
                    updateDailyRecord.SecondSetCount = dailyRecord.SecondSetCount;
                    updateDailyRecord.ThirdSetCount = dailyRecord.ThirdSetCount;
                    db.SaveChanges();

                }
            }
        }

        public void DeleteRecord(DailyRecord dailyRecord)
        {
            using (var db = new SystemContext())
            {
                var deletedDailyRecord = db.DailyRecords.FirstOrDefault(x => x.DailyRecordId == dailyRecord.DailyRecordId);
                if (deletedDailyRecord != null)
                {
                    deletedDailyRecord.IsDeleted = true;
                    db.SaveChanges();
                }
            }
        }
    }

}
