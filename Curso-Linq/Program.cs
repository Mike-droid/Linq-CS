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
        ImprimirValores(queries.MasDe250PaginasYTituloContieneInAction());
    }
}