using Microsoft.EntityFrameworkCore;
using Muscle_Backend.Models;

namespace Muscle_Backend.Database
{
    internal class SystemContext : DbContext
    {
        /// <summary>
        /// 部位テーブル
        /// </summary>
        public DbSet<BodyPart> BodyParts { get; set; }

        /// <summary>
        /// 種目テーブル
        /// </summary>
        public DbSet<Exercise> Exercises { get; set; }

        /// <summary>
        /// DBの格納パス
        /// </summary>
        public string DbPath { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SystemContext()
        {
            // 特殊フォルダ（デスクトップ）の絶対パスを取得
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // DBファイルの保存先とDBファイル名をDbPathに格納
            DbPath = $"{path}{Path.DirectorySeparatorChar}Muscle.db";
        }

        // デスクトップ上にSQLiteのDBファイルが作成される
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
