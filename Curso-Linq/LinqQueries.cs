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

        public IEnumerable<Book> LibrosDeLenguajeProgramacionPorNombreAscendente(string programmingLanguage)
        {
            return librosCollection.Where(book => book.Categories.Contains(programmingLanguage)).OrderBy(book => book.Title);
        }

        public IEnumerable<Book> LibrosMasDeXPaginasDescendente(int pages)
        {
            return librosCollection.Where(book => book.PageCount > pages).OrderByDescending(book => book.PageCount);
        }

        public IEnumerable<Book> PrimerosLibrosRecientesCategorizados(int quantity, string category)
        {
            return librosCollection.Where(book => book.Categories.Contains(category)).OrderByDescending(book => book.PublishedDate).Take(quantity);
        }

        public IEnumerable<Book> LibroPosicionMasDeXPaginas(int takeValue, int skipValue, int pageQuantity)
        {
            return librosCollection.Where(book => book.PageCount > pageQuantity).Take(takeValue).Skip(skipValue);
        }

        public int CantidadLibrosEntreXYPaginas(int limiteInferior, int limiteSuperior)
        {
            return librosCollection.Count(book => book.PageCount >= limiteInferior && book.PageCount <= limiteSuperior);
        }

        public DateTime FechaDePublicacionMenor()
        {
            return librosCollection.Min(book => book.PublishedDate);
        }

        public int MayorCantidadPaginas()
        {
            return librosCollection.Max(book => book.PageCount);
        }

        public Book? LibroConMenorNumeroDePaginas() //* protección de retorno null
        {
            return librosCollection.Where(book => book.PageCount > 0).MinBy(book => book.PageCount);
        }

        public Book? LibroMasReciente() //* protección de retorno null
        {
            return librosCollection.MaxBy(book => book.PublishedDate);
        }

        public int SumaDeTodasLasPaginasLbirosEntreXY(int limiteInferior, int limiteSuperior)
        {
            return librosCollection.Where(book => book.PageCount >= limiteInferior && book.PageCount <= limiteSuperior).Sum(book => book.PageCount);
        }

        public string LibrosDespuesDeAnioConcatedos(int anio)
        {
            return librosCollection
                .Where(book => book.PublishedDate.Year > anio)
                .Aggregate("", (TitulosLibros, next) =>
                    {
                        if(TitulosLibros != string.Empty)
                        {
                            TitulosLibros += " - " + next.Title;
                        }
                        else
                        {
                            TitulosLibros += next.Title;
                        }
                        return TitulosLibros;
                    }
                );
        }

        public double PromedioCaracteresTitulosLibros()
        {
            return librosCollection.Average(book => book.Title.Length);
        }

        public double PromedioPaginasLibros()
        {
            return librosCollection.Where(book => book.PageCount > 0).Average(book => book.PageCount);
        }

        public IEnumerable<IGrouping<int, Book>> LibrosAPartirDeAnioAgrupadosPorAnio(int anio)
        {
            return librosCollection.Where(book => book.PublishedDate.Year >= anio).OrderBy(book => book.PublishedDate).GroupBy(book => book.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
        {
            return librosCollection.ToLookup(book => book.Title[0], book => book);
        }

        public IEnumerable<Book> LibrosDespuesDeAnioConMasDeXPaginas(int anio, int paginas)
        {
            var librosDespuesDelAnio = librosCollection.Where(book => book.PublishedDate.Year > anio);

            var librosConMasDeXPaginas = librosCollection.Where(book => book.PageCount > paginas);

            return librosDespuesDelAnio.Join(librosConMasDeXPaginas, book => book.Title, book2 => book2.Title, (book, book2) => book);
        }
    }

    internal class LinqQueriesItems
    {

        private List<Item> items = new List<Item>();
        public LinqQueriesItems()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.items = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public IEnumerable<Item> PrimerosXLibros(int quantity)
        {
            return items.Take(quantity)
                .Select(book => new Item()
                {
                    Title = book.Title,
                    PageCount = book.PageCount
                });
        }
    }
}
