namespace SimpleStucturesAndArrays
{
    public struct BookStruct
    {
        public BookStruct(int id, string title, string author)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

    }
}
