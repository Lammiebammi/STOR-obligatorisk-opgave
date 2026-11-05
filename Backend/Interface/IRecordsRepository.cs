using Backend.Models;

namespace Backend.Interface
{
    public interface IRecordsRepository
    {
        Task<Record> AddAsync(Record record);
        Task<Record?> DeleteAsync(int id);
        Task<Record?> GetRecordAsync(int id);
        Task<IEnumerable<Record>> GetRecordsAsync();
        Task<Record?> UpdateAsync(Record record);
        IEnumerable<Record> Search(string? title = null, string? artist = null, int? duration = null,
            string? publicationYear = null, string? genre = null, bool singleSearch = false, bool caseSensitive = false);
    }
}