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

        ImprimirValores(queries.TodaLaColeccion());
    }
}