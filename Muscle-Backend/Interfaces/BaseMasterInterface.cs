namespace Muscle_Backend.Interfaces
{
    interface BaseMasterInterface<T>
    {
        /// <summary>
        /// データ取得
        /// </summary>
        public IEnumerable<T> SelectRecords();

        /// <summary>
        /// データ作成
        /// </summary>
        public bool InsertRecord(T featureType);

        /// <summary>
        /// データ更新
        /// </summary>
        public bool UpdateRecord(T featureType);

        /// <summary>
        /// データ削除
        /// </summary>
        public bool DeleteRecord(T featureType);

    }
}
