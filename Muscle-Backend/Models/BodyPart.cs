using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muscle_Backend.Models
{
    public class BodyPart
    {
        /// <summary>
        /// 部位のID
        /// </summary>
        [Key]
        // オートインクリメントを指定
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BodyPartId { get; set; }

        /// <summary>
        /// 部位の名前
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 論理削除フラグ
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
