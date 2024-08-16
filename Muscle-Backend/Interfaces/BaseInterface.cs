namespace Muscle_Backend.Interfaces
{
    interface BaseInterface<T>
    {
        /// <summary>
        /// データ取得
        /// </summary>
        public IEnumerable<T> SelectRecords(T featureType);

        /// <summary>
        /// データ作成
        /// </summary>
        public void InsertRecord(T featureType);

        /// <summary>
        /// データ更新
        /// </summary>
        public void UpdateRecord(T featureType);

        /// <summary>
        /// データ削除
        /// </summary>
        public void DeleteRecord(T featureType);

    }
}
