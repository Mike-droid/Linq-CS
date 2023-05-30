using Curso_Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        LinqQueries queries = new();
        LinqQueriesItems items = new();

        string formatoTextoLibro = "{0, -60} {1, 15} {2, 15}";

        void ImprimirValores(IEnumerable<Book> listaDeLibros)
        {
            Console.WriteLine($"{formatoTextoLibro}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var book in listaDeLibros)
            {
                Console.WriteLine($"{formatoTextoLibro}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }

        string formatoTextoItem = "{0, -60} {1, 15}";

        void ImprimirItems(IEnumerable<Item> listaDeItems)
        {
            Console.WriteLine($"{formatoTextoItem}\n", "Titulo", "N. Paginas");
            foreach (var book in listaDeItems)
            {
                Console.WriteLine($"{formatoTextoItem}", book.Title, book.PageCount);
            }
        }

        //* Toda la colección
        //ImprimirValores(queries.TodaLaColeccion());

        //* Libros después del 2000
        //ImprimirValores(queries.LibrosDespuesDel2000());

        //* Libros con más de 250 páginas y el título contiene 'in Action'
        //ImprimirValores(queries.MasDe250PaginasYTituloContieneInAction());

        //* Todos los libros tienen Status
        //Console.WriteLine($"¿Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()}");

        //* Al menos 1 libro fue publicado en 2005
        //Console.WriteLine($"¿Al menos un libro fue publicado en 2005?: {queries.LibroPublicadoEnAnio(2005)}");

        //* Libros de Python
        //ImprimirValores(queries.LibrosDeCategoria("Python"));

        //* Libros de Java - Ordenados por nombre
        //ImprimirValores(queries.LibrosDeLenguajeProgramacionPorNombreAscendente("Java"));

        //* Libros de Java - Ordenados por nombre descendente
        //ImprimirValores(queries.LibrosMasDeXPaginasDescendente(450));

        //* Primeros 3 libros con fecha de publicación más reciente categorizados en Java
        //ImprimirValores(queries.PrimerosLibrosRecientesCategorizados(3, "Java"));

        //* Tercer y cuarto libro con más de 400 páginas
        //ImprimirValores(queries.LibroPosicionMasDeXPaginas(4, 2, 400));

        //* Primeros X libros filtadros con Select
        ImprimirItems(items.PrimerosXLibros(3));
    }
}