using Microsoft.AspNetCore.Mvc;
using Muscle_Backend.Database;
using Muscle_Backend.Features;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ILogger<ExerciseController> _logger;

        public ExerciseController(ILogger<ExerciseController> logger)
        {
            _logger = logger;
            _exerciseFeature = new ExerciseFeature();
        }

        private readonly BaseMasterInterface<Exercise> _exerciseFeature;

        /// <summary>
        /// ��ڃ}�X�^��ǂݍ���
        /// </summary>
        [HttpGet("GetExercises",Name = "GetExercises")]
        public ActionResult<IEnumerable<Exercise>> GetExercises()
        {
            try
            {
                var exercises = _exerciseFeature.SelectRecords();
                return Ok(exercises);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̎擾�Ɏ��s");
            }
        }

        /// <summary>
        /// ��ڃ}�X�^���쐬
        /// </summary>
        [HttpPost("AddExercise", Name = "AddBodyExercise")]
        public ActionResult<bool> AddExercise(Exercise exercise)
        {
            try
            {
                var processState = _exerciseFeature.InsertRecord(exercise);
                return Ok(processState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̍쐬�Ɏ��s");
            }
        }

        /// <summary>
        /// ��ڃ}�X�^���X�V
        /// </summary>
        [HttpPost("UpdateExercise", Name = "UpdateExercise")]
        public ActionResult<bool> UpdateExercise(Exercise exercise)
        {
            try
            {
                var processState = _exerciseFeature.UpdateRecord(exercise);
                return Ok(processState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̍X�V�Ɏ��s");
            }
        }

        /// <summary>
        /// ��ڃ}�X�^���폜����
        /// </summary>
        [HttpPost("DeleteExercise", Name = "DeleteExercise")]
        public ActionResult<bool> DeleteExercise(Exercise exercise)
        {
            try
            {
                var processState = _exerciseFeature.DeleteRecord(exercise);
                return Ok(processState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̍폜�Ɏ��s");
            }
        }
    }
}
