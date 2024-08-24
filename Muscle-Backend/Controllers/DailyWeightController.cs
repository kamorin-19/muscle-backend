using Microsoft.AspNetCore.Mvc;
using Muscle_Backend.Database;
using Muscle_Backend.Features;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;

namespace Muscle_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyWeightController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DailyWeightController> _logger;

        public DailyWeightController(ILogger<DailyWeightController> logger)
        {
            _logger = logger;
            _dailyWeightFeature = new DailyWeightFeature();
        }

        private readonly BaseInterface<DailyWeight> _dailyWeightFeature;

        /// <summary>
        /// 日の体重を読み込み
        /// </summary>
        [HttpGet("GetDailyWeight",Name = "GetDailyWeight")]
        public IEnumerable<DailyWeight> GetDailyWeight()
        {
            return _dailyWeightFeature.SelectRecords(new DailyWeight());
        }

        /// <summary>
        /// 日の体重を作成
        /// </summary>
        [HttpPost("AddDailyWeight", Name = "AddDailyWeight")]
        public void AddDailyWeight()
        {
            _dailyWeightFeature.InsertRecord(new DailyWeight());
        }

        /// <summary>
        /// 日の体重を更新
        /// </summary>
        [HttpPost("UpdateDailyWeight", Name = "UpdateDailyWeight")]
        public void UpdateDailyWeight()
        {
            _dailyWeightFeature.UpdateRecord(new DailyWeight());
        }

        /// <summary>
        /// 日の体重を削除
        /// </summary>
        [HttpPost("DeleteDailyWeight", Name = "DeleteDailyWeight")]
        public void DeleteDailyWeight()
        {
            _dailyWeightFeature.DeleteRecord(new DailyWeight());
        }
    }
}
