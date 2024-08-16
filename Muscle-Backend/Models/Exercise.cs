using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muscle_Backend.Models
{
    public class Exercise
    {
        /// <summary>
        /// 種目のID
        /// </summary>
        [Key]
        public int ExercisePId { get; set; }

        /// <summary>
        /// 種目の名前
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 種目の重み
        /// </summary>
        [Required]
        public double Weight { get; set; }

        /// <summary>
        /// 種目お部位のID
        /// </summary>
        public int BodyPartId { get; set; }
        [ForeignKey("BodyPartId")]
        public BodyPart BodyPart { get; set; }

        /// <summary>
        /// 論理削除フラグ
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
