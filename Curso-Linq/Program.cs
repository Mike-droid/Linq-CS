using Curso_Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        LinqQueries queries = new LinqQueries();

        string formatoTexto = "{0, -60} {1, 15} {2, 15}";

        void ImprimirValores(IEnumerable<Book> listaDeLibros)
        {
            Console.WriteLine($"{formatoTexto}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var book in listaDeLibros)
            {
                Console.WriteLine($"{formatoTexto}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
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
        ImprimirValores(queries.LibrosMasDeXPaginasDescendente(450));
    }
}