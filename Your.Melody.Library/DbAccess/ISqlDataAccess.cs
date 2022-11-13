namespace Your.Melody.Library.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "");
        Task<IEnumerable<T>> LoadDataFromViewAsync<T>(string storedProcedure, string connectionId = "");
        Task<IEnumerable<T>> LoadMultipleMapDataAsync<T, U, O>(string storedProcedure, U parameters, Func<T, O, T> func, string connectionId = "");
        Task SaveDataAsync<T>(string storedProcedire, T parameters, string connectionId = "");
    }
}