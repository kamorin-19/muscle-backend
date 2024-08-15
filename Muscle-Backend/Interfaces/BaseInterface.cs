namespace Muscle_Backend.Interfaces
{
    public interface BaseInterface
    {
        /// <summary>
        /// データ取得
        /// </summary>
        public IEnumerable<T> SelectRecords<T>();

        /// <summary>
        /// データ作成
        /// </summary>
        public void InsertRecord();

        /// <summary>
        /// データ更新
        /// </summary>
        public void UpdateRecord();

        /// <summary>
        /// データ削除
        /// </summary>
        public void DeleteRecord();

    }
}
