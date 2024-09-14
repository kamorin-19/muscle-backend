using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muscle_Backend.Models
{
    public class DailyRecord
    {
        /// <summary>
        /// 日の記録のID
        /// </summary>
        [Key]
        // オートインクリメントを指定
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DailyRecordId { get; set; }

        /// <summary>
        /// 実施日
        /// </summary>
        public DateOnly EnforcementDay { get; set; }

        /// <summary>
        /// 種目のID
        /// </summary>
        public int ExercisePId { get; set; }
        [ForeignKey("ExercisePId")]
        public Exercise Exercise { get; set; }

        /// <summary>
        /// 1セット目の回数
        /// </summary>
        [Required]
        public int FirstSetCount { get; set; }

        /// <summary>
        /// 2セット目の回数
        /// </summary>
        public int SecondSetCount { get; set; }

        /// <summary>
        /// 3セット目の回数
        /// </summary>
        public int ThirdSetCount { get; set; }

        /// <summary>
        /// 4セット目の回数
        /// </summary>
        public int FourthSetCount { get; set; }

        /// <summary>
        /// 5セット目の回数
        /// </summary>
        public int FifthSetCount { get; set; }

        /// <summary>
        /// 論理削除フラグ
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
