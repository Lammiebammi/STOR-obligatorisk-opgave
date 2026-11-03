using Backend.Interface;
using Backend.Models;
using System.Reflection.Metadata.Ecma335;

namespace Backend.Repository
{
    public class RecordsRepository : IRecordsRepository
    {
        private readonly List<Record> _records = new()
        {
            new Record { Id = 1,  Title = "Bohemian Rhapsody",     Artist = "Queen",            Duration = 354, PublicationYear = "1975", Genre = "Rock" },
            new Record { Id = 2,  Title = "Billie Jean",           Artist = "Michael Jackson",  Duration = 294, PublicationYear = "1982", Genre = "Pop" },
            new Record { Id = 3,  Title = "Smells Like Teen Spirit", Artist = "Nirvana",        Duration = 301, PublicationYear = "1991", Genre = "Grunge" },
            new Record { Id = 4,  Title = "Hotel California",      Artist = "Eagles",           Duration = 391, PublicationYear = "1976", Genre = "Rock" },
            new Record { Id = 5,  Title = "Lose Yourself",         Artist = "Eminem",           Duration = 326, PublicationYear = "2002", Genre = "Hip-Hop" },
            new Record { Id = 6,  Title = "Rolling in the Deep",   Artist = "Adele",            Duration = 228, PublicationYear = "2010", Genre = "Pop" },
            new Record { Id = 7,  Title = "Take Five",             Artist = "Dave Brubeck",     Duration = 324, PublicationYear = "1959", Genre = "Jazz" },
            new Record { Id = 8,  Title = "Get Lucky",             Artist = "Daft Punk",        Duration = 369, PublicationYear = "2013", Genre = "Electronic" },
            new Record { Id = 9,  Title = "Purple Rain",           Artist = "Prince",           Duration = 520, PublicationYear = "1984", Genre = "Pop" },
            new Record { Id = 10, Title = "Blinding Lights",       Artist = "The Weeknd",       Duration = 200, PublicationYear = "2019", Genre = "Synth-pop" }
        }; 
        private int _nextId = 10;
        private object obj = new();

        public RecordsRepository()
        {

        }

        public async Task<Record> AddAsync(Record record)
        {
            lock (obj)
            {
                record.Id = ++_nextId;
            }

            _records.Add(record);
            return record;
        }

        public async Task<Record?> DeleteAsync(int id)
        {
            Record? recordToDelete = _records.FirstOrDefault(r => r.Id == id);

            if (recordToDelete is null) return null;

            _records.Remove(recordToDelete);
            return recordToDelete;
        }

        public async Task<IEnumerable<Record>> GetRecordsAsync()
        {
            return new List<Record>(_records);
        }

        public async Task<Record?> GetRecordAsync(int id)
        {
            Record? record = _records.FirstOrDefault(r => r.Id == id);

            return record is null ? null : record;
        }

        public async Task<Record?> UpdateAsync(Record record)
        {
            foreach (Record r in _records)
            {
                if (record.Id == r.Id)
                {
                    r.Id = record.Id;
                    r.Title = record.Title;
                    r.Artist = record.Artist;
                    r.Duration = record.Duration;
                    r.PublicationYear = record.PublicationYear;
                    r.Genre = record.Genre;

                    return r;
                }
            }
            return null;
        }

    }
}
