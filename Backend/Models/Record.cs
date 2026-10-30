namespace Backend.Models
{
    public class Record
    {
        // properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public string PublicationYear { get; set; }
        public string Genre { get; set; }

        // ToString method
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Artist: {Artist}, Duration: {Duration}, PublicationYear: {PublicationYear}, Genre: {Genre}";
        }
    }
}
