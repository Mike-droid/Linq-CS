namespace Curso_Linq
{
    internal class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();
        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosDespuesDel2000()
        {
            //* extension method
            //return librosCollection.Where(book => book.PublishedDate.Year > 2000);

            //* query expression
            return from book in librosCollection where book.PublishedDate.Year > 2000 select book;
        }

        public IEnumerable<Book> MasDe250PaginasYTituloContieneInAction()
        {
            //return librosCollection.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));

            return from book in librosCollection
                        where book.PageCount > 250
                        && book.Title.Contains("in Action")
                        select book;
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(book => book.Status != String.Empty);
        }

        public bool LibroPublicadoEnAnio(int year)
        {
            return librosCollection.Any(book => book.PublishedDate.Year == year);
        }

        public IEnumerable<Book> LibrosDeCategoria(string text)
        {
            return librosCollection.Where(book => book.Categories.Contains(text));
        }
    }
}
