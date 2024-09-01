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
        /// 種目マスタを読み込み
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
                return StatusCode(StatusCodes.Status500InternalServerError, "データの取得に失敗");
            }
        }

        /// <summary>
        /// 種目マスタを作成
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
                return StatusCode(StatusCodes.Status500InternalServerError, "データの作成に失敗");
            }
        }

        /// <summary>
        /// 種目マスタを更新
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
                return StatusCode(StatusCodes.Status500InternalServerError, "データの更新に失敗");
            }
        }

        /// <summary>
        /// 種目マスタを削除する
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
                return StatusCode(StatusCodes.Status500InternalServerError, "データの削除に失敗");
            }
        }
    }
}
