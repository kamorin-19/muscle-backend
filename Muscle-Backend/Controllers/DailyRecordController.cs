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
        /// ���̋L�^����ǂݍ���
        /// </summary>
        [HttpGet("GetDailyRecord",Name = "GetDailyRecord")]
        public ActionResult<IEnumerable<DailyRecord>> GetExercises()
        {
            try
            {
                var dailyRecords = _dailyRecordFeature.SelectRecords();
                return Ok(dailyRecords);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "�f�[�^�̎擾�Ɏ��s");
            }
        }

        /// <summary>
        /// ���̋L�^���쐬
        /// </summary>
        [HttpPost("AddDailyRecord", Name = "AddDailyRecord")]
        public void AddDailyRecord(DailyRecord dailyRecord)
        {

            _dailyRecordFeature.InsertRecord(dailyRecord);
        }

        /// <summary>
        /// ���̋L�^���X�V
        /// </summary>
        [HttpPost("UpdateDailyRecord", Name = "UpdateDailyRecord")]
        public void UpdateDailyRecord(DailyRecord dailyRecord)
        {
            _dailyRecordFeature.UpdateRecord(dailyRecord);
        }

        /// <summary>
        /// ���̋L�^���폜
        /// </summary>
        [HttpPost("DeleteDailyRecord", Name = "DeleteDailyRecord")]
        public void DeleteDailyRecord()
        {
            _dailyRecordFeature.DeleteRecord(new DailyRecord());
        }
    }
}
