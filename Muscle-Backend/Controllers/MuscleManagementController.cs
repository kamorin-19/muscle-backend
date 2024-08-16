using Microsoft.AspNetCore.Mvc;
using Muscle_Backend.Database;
using Muscle_Backend.Features;
using Muscle_Backend.Interfaces;
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
            _bodyPartFeature = new BodyPartFeature();
        }

        private readonly BaseInterface<BodyPart> _bodyPartFeature;

        /// <summary>
        /// ���ʃ}�X�^��ǂݍ���
        /// </summary>
        [HttpGet("GetBodyParts",Name = "GetBodyParts")]
        public IEnumerable<BodyPart> GetBodyParts()
        {
            return _bodyPartFeature.SelectRecords(new BodyPart());
        }

        /// <summary>
        /// ���ʃ}�X�^���쐬
        /// </summary>
        [HttpPost("AddBodyParts", Name = "AddBodyParts")]
        public void AddBodyParts()
        {
            _bodyPartFeature.InsertRecord(new BodyPart());
        }

        /// <summary>
        /// ���ʃ}�X�^���X�V
        /// </summary>
        [HttpPost("UpdateBodyParts", Name = "UpdateBodyParts")]
        public void UpdateBodyParts()
        {
            _bodyPartFeature.UpdateRecord(new BodyPart());
        }

        /// <summary>
        /// ���ʃ}�X�^���폜
        /// </summary>
        [HttpPost("DeleteBodyParts", Name = "DeleteBodyParts")]
        public void DeleteBodyParts()
        {
            _bodyPartFeature.DeleteRecord(new BodyPart());
        }
    }
}
