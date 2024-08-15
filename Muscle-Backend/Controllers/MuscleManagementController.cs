using Microsoft.AspNetCore.Mvc;
using Muscle_Backend.Database;
using Muscle_Backend.Models;

namespace Muscle_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MuscleManagementController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MuscleManagementController> _logger;

        public MuscleManagementController(ILogger<MuscleManagementController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 部位マスタを読み込み
        /// </summary>
        [HttpGet("GetBodyParts",Name = "GetBodyParts")]
        public IEnumerable<BodyPart> GetBodyParts()
        {
            using (var db = new SystemContext())
            {
                return db.BodyParts.Where(x => x.IsDeleted == false)
                                   .OrderBy(y => y.BodyPartId)
                                   .ToList();
            }
        }

        /// <summary>
        /// 部位マスタを作成
        /// </summary>
        [HttpPost("AddBodyParts", Name = "AddBodyParts")]
        public void AddBodyParts()
        {
            using (var db = new SystemContext())
            {
                db.Add(new BodyPart { BodyPartId = 2, Name = "肩" });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 部位マスタを更新
        /// </summary>
        [HttpPost("UpdateBodyParts", Name = "UpdateBodyParts")]
        public void UpdateBodyParts()
        {
            using (var db = new SystemContext())
            {
                // 更新するデータを取得
                var bodyPart = db.BodyParts.Where(x => x.BodyPartId == 2).FirstOrDefault();

                if (bodyPart != null)
                {
                    // 部位を取得できた場合
                    bodyPart.Name = "腕";

                    // 変更を保存
                    db.SaveChanges();
                }
            }
        }
    }
}
