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

        private readonly ILogger<DailyRecordController> _logger;

        public DailyRecordController(ILogger<DailyRecordController> logger)
        {
            _logger = logger;
            _dailyRecordFeature = new DailyRecordFeature();
        }

        private readonly BaseInterface<DailyRecord> _dailyRecordFeature;

        /// <summary>
        /// “ú‚Ì‹L˜^‚ğ‚ğ“Ç‚İ‚İ
        /// </summary>
        [HttpGet("GetDailyRecord",Name = "GetDailyRecord")]
        public IEnumerable<DailyRecord> GetExercises()
        {
            return _dailyRecordFeature.SelectRecords();
        }

        /// <summary>
        /// “ú‚Ì‹L˜^‚ğì¬
        /// </summary>
        [HttpPost("AddDailyRecord", Name = "AddDailyRecord")]
        public void AddDailyRecord()
        {
            _dailyRecordFeature.InsertRecord(new DailyRecord());
        }

        /// <summary>
        /// “ú‚Ì‹L˜^‚ğXV
        /// </summary>
        [HttpPost("UpdateDailyRecord", Name = "UpdateDailyRecord")]
        public void UpdateDailyRecord()
        {
            _dailyRecordFeature.UpdateRecord(new DailyRecord());
        }

        /// <summary>
        /// “ú‚Ì‹L˜^‚ğíœ
        /// </summary>
        [HttpPost("DeleteDailyRecord", Name = "DeleteDailyRecord")]
        public void DeleteDailyRecord()
        {
            _dailyRecordFeature.DeleteRecord(new DailyRecord());
        }
    }
}
