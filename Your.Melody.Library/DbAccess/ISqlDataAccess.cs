namespace Your.Melody.Library.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "AzureDB");
        Task<IEnumerable<T>> LoadDataFromViewAsync<T>(string view, string connectionId = "AzureDB");
        Task<IEnumerable<T>> LoadMultipleMapDataAsync<T, U, O>(string storedProcedure, U parameters, Func<T, O, T> func, string connectionId = "AzureDB");
        Task SaveDataAsync<T>(string storedProcedire, T parameters, string connectionId = "AzureDB");
    }
}