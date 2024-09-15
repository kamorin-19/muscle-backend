using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Muscle_Backend.Database;
using Muscle_Backend.Features;
using Muscle_Backend.Interfaces;
using Muscle_Backend.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Muscle_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImportCsvController : ControllerBase
    {
        private readonly ILogger<ImportCsvController> _logger;

        public ImportCsvController(ILogger<ImportCsvController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// ��ڃ}�X�^��ǂݍ���
        /// </summary>
        [HttpPost("AddDailyRecords",Name = "AddDailyRecords")]
        public void AddDailyRecords(ImportRecord importRecords)
        {
            using (var db = new SystemContext())
            {
                //foreach (var record in importRecords)
                //{
                    // ��ږ�����ID���擾
                    var exercidseId = db.Exercises.Where(x => x.Name == importRecords.ExerciseName).FirstOrDefault();

                    if (exercidseId != null)
                    {
                        var newDailyRecord = new DailyRecord
                        {
                            EnforcementDay = importRecords.EnforcementDay,
                            ExercisePId = exercidseId.ExercisePId,
                            FirstSetCount = importRecords.FirstSetCount,
                            SecondSetCount = importRecords.SecondSetCount,
                            ThirdSetCount = importRecords.ThirdSetCount,
                            FourthSetCount = 0,
                            FifthSetCount = 0
                        };

                        // �f�[�^�x�[�X�ɐV�����I�u�W�F�N�g��ǉ�
                        db.DailyRecords.Add(newDailyRecord);
                        db.SaveChanges();
                    }
                //}

                

                
            }
        }
        
    }

    public class ImportRecord
    {
        public DateOnly EnforcementDay { get; set; }
        public String? ExerciseName { get; set; }
        public int FirstSetCount { get; set; }
        public int SecondSetCount { get; set; }
        public int ThirdSetCount { get; set; }
    }
}
