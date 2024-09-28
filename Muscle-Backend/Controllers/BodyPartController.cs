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
        /// ���ʃ}�X�^��ǂݍ���
        /// </summary>
        [HttpGet("GetBodyParts",Name = "GetBodyParts")]
        public ActionResult<IEnumerable<BodyPart>> GetBodyParts()
        {
            try
            {
                var bodyParts = _bodyPartFeature.SelectRecords();
                return Ok(bodyParts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̎擾�Ɏ��s");
            }
        }

        /// <summary>
        /// ���ʃ}�X�^���쐬
        /// </summary>
        [HttpPost("AddBodyParts", Name = "AddBodyParts")]
        public ActionResult<bool> AddBodyParts(BodyPart bodyPart)
        {
            try
            {
                var processState = _bodyPartFeature.InsertRecord(bodyPart); 

                if (!processState)
                {
                    throw new Exception();
                }

                return Ok(processState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̍쐬�Ɏ��s");
            }
        }

        /// <summary>
        /// ���ʃ}�X�^���X�V
        /// </summary>
        [HttpPost("UpdateBodyParts", Name = "UpdateBodyParts")]
        public ActionResult<bool> UpdateBodyParts(BodyPart bodyPart)
        {
            try
            {
                var processState = _bodyPartFeature.UpdateRecord(bodyPart);

                if (!processState)
                {
                    throw new Exception();
                }

                return Ok(processState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̍X�V�Ɏ��s");
            }
        }

        /// <summary>
        /// ���ʃ}�X�^���폜
        /// </summary>
        [HttpPost("DeleteBodyParts", Name = "DeleteBodyParts")]
        public ActionResult<bool> DeleteBodyParts(BodyPart bodyPart)
        {
            try
            {
                var processState = _bodyPartFeature.DeleteRecord(bodyPart);
                return Ok(processState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̍폜�Ɏ��s");
            }
        }
    }
}
