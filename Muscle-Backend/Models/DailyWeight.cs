using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muscle_Backend.Models
{
    public class DailyWeight
    {
        /// <summary>
        /// 日の記録のID
        /// </summary>
        public int DailyWeightId { get; set; }

        /// <summary>
        /// 計測日
        /// </summary>
        public DateOnly RecordedDay { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// 論理削除フラグ
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
