using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class BodyPartFeature : BaseMasterInterface<BodyPart>
    {
        /// <summary>
        /// 部位マスタを読み込み、絞りこみは行わない
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BodyPart> SelectRecords()
        {
            using (var db = new SystemContext())
            {
                return db.BodyParts.Where(x => x.IsDeleted == false).ToList();
            }
        }

        /// <summary>
        /// 部位マスタを挿入する
        /// </summary>
        /// <returns></returns>
        public bool InsertRecord(BodyPart bodyPart)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.BodyParts.Where(x => x.Name == bodyPart.Name).ToList().Count;

                if (recordCount > 0)
                {
                    return false;
                }

                var newBodyPart = new BodyPart
                {
                    Name = bodyPart.Name
                };

                // データベースに新しいオブジェクトを追加
                db.BodyParts.Add(newBodyPart);
                db.SaveChanges();

                return true;

            }
        }

        public bool UpdateRecord(BodyPart bodyPart)
        {
            using (var db = new SystemContext())
            {
                var recordCount = db.BodyParts.Where(x => x.Name == bodyPart.Name).ToList().Count;

                if (recordCount > 0)
                {
                    return false;
                }
                // ★名前の重複は不可にする、サービスを追加する？
                var updateBodyPart = db.BodyParts.FirstOrDefault(x => x.BodyPartId == bodyPart.BodyPartId);
                if (updateBodyPart != null)
                {
                    // 更新処理
                    updateBodyPart.Name = bodyPart.Name;
                    db.SaveChanges();
                    
                }
                return true;
            }
        }

        public bool DeleteRecord(BodyPart bodyPart)
        {
            using (var db = new SystemContext())
            {
                var deleteBodyPart = db.BodyParts.FirstOrDefault(x => x.BodyPartId == bodyPart.BodyPartId);
                if (deleteBodyPart != null)
                {
                    deleteBodyPart.IsDeleted = true;
                    db.SaveChanges();
                }
                return true;
            }
        }
    }

}
