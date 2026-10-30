using Backend.Interface;
using Backend.Models;

namespace Backend.Repository
{
    public class RecordsRepository : IRepository<Record, int>
    {
        private List<Record> repoList;
        private int nextId;

        public RecordsRepository(bool testData = false)
        {
            nextId = 1;
            repoList = new();

            if (testData)
            {
                repoList.Add(new Record() { Id = nextId++, Artist = "Test Testman", Duration = 180, Genre = "Test Music", PublicationYear = "1773", Title = "Testing This System" });
            }
        }

        public Record Add(Record toAdd)
        {
            throw new NotImplementedException();
        }

        public Record Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Record Edit(int key, Record newInfo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAll()
        {
            return repoList.ToList();
        }

        public Record GetByKey(int key)
        {
            throw new NotImplementedException();
        }
    }
}
