using Microsoft.AspNetCore.Mvc;
using Muscle_Backend.Database;
using Muscle_Backend.Features;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyPartController : ControllerBase
    {
        private readonly ILogger<BodyPartController> _logger;

        public BodyPartController(ILogger<BodyPartController> logger)
        {
            _logger = logger;
            _bodyPartFeature = new BodyPartFeature();
        }

        private readonly BaseMasterInterface<BodyPart> _bodyPartFeature;

        /// <summary>
        /// 部位マスタを読み込み
        /// </summary>
        [HttpGet("GetBodyParts",Name = "GetBodyParts")]
        public IEnumerable<BodyPart> GetBodyParts()
        {
            return _bodyPartFeature.SelectRecords();
        }

        /// <summary>
        /// 部位マスタを作成
        /// </summary>
        [HttpPost("AddBodyParts", Name = "AddBodyParts")]
        public bool AddBodyParts(BodyPart bodyPart)
        {
            return _bodyPartFeature.InsertRecord(bodyPart);
        }

        /// <summary>
        /// 部位マスタを更新
        /// </summary>
        [HttpPost("UpdateBodyParts", Name = "UpdateBodyParts")]
        public bool UpdateBodyParts(BodyPart bodyPart)
        {
            return _bodyPartFeature.UpdateRecord(bodyPart);
        }

        /// <summary>
        /// 部位マスタを削除
        /// </summary>
        [HttpPost("DeleteBodyParts", Name = "DeleteBodyParts")]
        public bool DeleteBodyParts(BodyPart bodyPart)
        {
            return _bodyPartFeature.DeleteRecord(bodyPart);
        }
    }
}
