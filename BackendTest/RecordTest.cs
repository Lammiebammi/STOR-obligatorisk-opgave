using Backend;
using Backend.Interface;
using Backend.Repository;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BackendTest
{
    public class RecordTest : IClassFixture<RecordsRepository>
    {
        private IRecordsRepository _recordRepo;
        public RecordTest(RecordsRepository recordsRepository)
        {
            _recordRepo = recordsRepository;
        }
        //Searching a term that matches one record shows exactly that record in the list.
        [Fact]
        public void SearchTermMatch()
        {
            Backend.Models.Record expected = new Backend.Models.Record
            {
                Id = 2,
                Title = "Billie Jean",
                Artist = "Michael Jackson",
                Duration = 294,
                PublicationYear = "1992",
                Genre = "Pop"
            };
            List<Backend.Models.Record> actualList = _recordRepo.Search(title:"Billie Jean", singleSearch: true).ToList();

            Assert.Equal(expected, actualList[0]);
        }

        //Searching a term that matches several records shows all of them.
        [Fact]
        public void SearchMatchingRecords()
        {
            List<Backend.Models.Record> expectedRecords = new List<Backend.Models.Record>
            {
                new Backend.Models.Record { Id = 2,  Title = "Billie Jean",           Artist = "Michael Jackson",  Duration = 294, PublicationYear = "1982", Genre = "Pop" },
                new Backend.Models.Record { Id = 6,  Title = "Rolling in the Deep",   Artist = "Adele",            Duration = 228, PublicationYear = "2010", Genre = "Pop" },
                new Backend.Models.Record { Id = 9,  Title = "Purple Rain",           Artist = "Prince",           Duration = 520, PublicationYear = "1984", Genre = "Pop" },
            };
            List<Backend.Models.Record> actualRecords = _recordRepo.Search(genre: "Pop").ToList();

            Assert.Equal(expectedRecords, actualRecords);
        }

        //Records that don’t match the term do not appear.
        [Fact]
        public void SearchNoAppear()
        {
            Backend.Models.Record expected = new Backend.Models.Record { Id = 9, Title = "Purple Rain", Artist = "Prince", Duration = 520, PublicationYear = "1984", Genre = "Pop" };
            List<Backend.Models.Record> actualList = _recordRepo.Search(title: "Billie Jean").ToList();

            Assert.DoesNotContain<Backend.Models.Record>(expected, actualList);
        }
    }
}
