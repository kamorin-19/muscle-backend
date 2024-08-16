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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ExerciseController> _logger;

        public ExerciseController(ILogger<ExerciseController> logger)
        {
            _logger = logger;
            _exerciseFeature = new ExerciseFeature();
        }

        private readonly BaseInterface<Exercise> _exerciseFeature;

        /// <summary>
        /// 種目マスタを読み込み
        /// </summary>
        [HttpGet("GetExercises",Name = "GetExercises")]
        public IEnumerable<Exercise> GetExercises()
        {
            return _exerciseFeature.SelectRecords(new Exercise());
        }

        /// <summary>
        /// 種目マスタを作成
        /// </summary>
        [HttpPost("AddExercise", Name = "AddBodyExercise")]
        public void AddExercise()
        {
            _exerciseFeature.InsertRecord(new Exercise());
        }

        /// <summary>
        /// 種目マスタを更新
        /// </summary>
        [HttpPost("UpdateExercise", Name = "UpdateExercise")]
        public void UpdateExercise()
        {
            _exerciseFeature.UpdateRecord(new Exercise());
        }

        /// <summary>
        /// 種目マスタを削除
        /// </summary>
        [HttpPost("DeleteExercise", Name = "DeleteExercise")]
        public void DeleteExercise()
        {
            _exerciseFeature.DeleteRecord(new Exercise());
        }
    }
}
