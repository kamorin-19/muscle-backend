using Microsoft.AspNetCore.Mvc;
using Muscle_Backend.Database;
using Muscle_Backend.Features;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyRecordController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DailyRecordController> _logger;

        public DailyRecordController(ILogger<DailyRecordController> logger)
        {
            _logger = logger;
            _dailyRecordFeature = new DailyRecordFeature();
        }

        private readonly BaseInterface<DailyRecord> _dailyRecordFeature;

        /// <summary>
        /// 日の記録をを読み込み
        /// </summary>
        [HttpGet("GetDailyRecord",Name = "GetDailyRecord")]
        public IEnumerable<DailyRecord> GetExercises()
        {
            return _dailyRecordFeature.SelectRecords(new DailyRecord());
        }

        /// <summary>
        /// 日の記録を作成
        /// </summary>
        [HttpPost("AddDailyRecord", Name = "AddDailyRecord")]
        public void AddDailyRecord()
        {
            _dailyRecordFeature.InsertRecord(new DailyRecord());
        }

        /// <summary>
        /// 日の記録を更新
        /// </summary>
        [HttpPost("UpdateDailyRecord", Name = "UpdateDailyRecord")]
        public void UpdateDailyRecord()
        {
            _dailyRecordFeature.UpdateRecord(new DailyRecord());
        }

        /// <summary>
        /// 日の記録を削除
        /// </summary>
        [HttpPost("DeleteDailyRecord", Name = "DeleteDailyRecord")]
        public void DeleteDailyRecord()
        {
            _dailyRecordFeature.DeleteRecord(new DailyRecord());
        }
    }
}
