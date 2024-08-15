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
        /// ���ʃ}�X�^��ǂݍ���
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
        /// ���ʃ}�X�^���쐬
        /// </summary>
        [HttpPost("AddBodyParts", Name = "AddBodyParts")]
        public void AddBodyParts()
        {
            using (var db = new SystemContext())
            {
                db.Add(new BodyPart { BodyPartId = 2, Name = "��" });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// ���ʃ}�X�^���X�V
        /// </summary>
        [HttpPost("UpdateBodyParts", Name = "UpdateBodyParts")]
        public void UpdateBodyParts()
        {
            using (var db = new SystemContext())
            {
                // �X�V����f�[�^���擾
                var bodyPart = db.BodyParts.Where(x => x.BodyPartId == 2).FirstOrDefault();

                if (bodyPart != null)
                {
                    // ���ʂ��擾�ł����ꍇ
                    bodyPart.Name = "�r";

                    // �ύX��ۑ�
                    db.SaveChanges();
                }
            }
        }
    }
}
