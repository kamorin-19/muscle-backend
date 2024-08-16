using Muscle_Backend.Database;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Features
{
    public class BodyPartFeature : BaseInterface<BodyPart>
    {
        public IEnumerable<BodyPart> SelectRecords(BodyPart featureType)
        {
            using (var db = new SystemContext())
            {
                return db.BodyParts.Where(x => x.IsDeleted == false).ToList();
            }
        }

        public void InsertRecord(BodyPart featureType)
        {
            using (var db = new SystemContext())
            {
                // 最新のIDを取得(自動インクリメントにしたい
                var lastBodyPart = db.BodyParts.Where(x => x.IsDeleted == false).OrderBy(x => x.BodyPartId).Last();
                var maxId = lastBodyPart.BodyPartId + 1;
                db.Add(new BodyPart { BodyPartId = maxId, Name = "肩" });
                db.SaveChanges();
            }
        }

        public void UpdateRecord(BodyPart featureType)
        {
            using (var db = new SystemContext())
            {
                // ★名前の重複は不可にする、サービスを追加する？
                var bodyPart = db.BodyParts.FirstOrDefault(x => x.BodyPartId == featureType.BodyPartId);
                if (bodyPart != null)
                {
                    // 更新処理
                    bodyPart.Name = featureType.Name;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteRecord(BodyPart featureType)
        {
            using (var db = new SystemContext())
            {
                var bodyPart = db.BodyParts.FirstOrDefault(x => x.BodyPartId == featureType.BodyPartId);
                if (bodyPart != null)
                {
                    bodyPart.IsDeleted = true;
                    db.SaveChanges();
                }
            }
        }
    }

}
