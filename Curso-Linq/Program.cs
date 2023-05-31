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

        string formatoDiccionario = "{0,-60} {1, 15} {2, 15}";

        void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
        {
            foreach (var grupo in ListadeLibros)
            {
                Console.WriteLine("");
                Console.WriteLine($"Grupo: {grupo.Key}");
                Console.WriteLine($"{formatoDiccionario}\n", "Titulo", "N. Paginas", "Fecha publicacion");
                foreach (var item in grupo)
                {
                    Console.WriteLine($"{formatoDiccionario}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
                }
            }
        }

        void PrintDictionary(ILookup<char, Book> bookList, char letter)
        {
            Console.WriteLine($"{formatoDiccionario}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var item in bookList[letter])
            {
                Console.WriteLine($"{formatoDiccionario}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
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
        //ImprimirItems(items.PrimerosXLibros(3));

        //* Cantidad de libros entre 200 y 500 páginas
        //Console.WriteLine($"Cantidad de libros entre 200 y 500 páginas: {queries.CantidadLibrosEntreXYPaginas(200, 500)}");

        //* Fecha de publicación más antigüa
        //Console.WriteLine($"Fecha de publicación más antigüa: {queries.FechaDePublicacionMenor()}");

        //* Cantidad mayor de páginas
        //Console.WriteLine($"El libro con la mayor cantidad de páginas tiene: {queries.MayorCantidadPaginas()} páginas");

        //* Libro con menor número de páginas
        //var libroMenosPaginas = queries.LibroConMenorNumeroDePaginas();
        //Console.WriteLine($"Libro con menor número de páginas: {libroMenosPaginas.Title} - Páginas: {libroMenosPaginas.PageCount}");

        //* Libro más reciente
        //var libroMasReciente = queries.LibroMasReciente();
        //Console.WriteLine($"Libro más reciente: {libroMasReciente.Title} - Fecha: {libroMasReciente.PublishedDate}");

        //* Suma de páginas de libros entre 0 y 500
        //Console.WriteLine($"Suma total de páginas {queries.SumaDeTodasLasPaginasLbirosEntreXY(0,500)}");

        //* Libros publicados después del 2015
        //Console.WriteLine($"Libros publicados después del 2015: {queries.LibrosDespuesDeAnioConcatedos(2015)}");

        //* Promedio de caracteres de los títulos de los libros
        //Console.WriteLine($"Promedio de caracteres de títulos: {queries.PromedioCaracteresTitulosLibros()}");

        //* Promedio de páginas de los libros
        //Console.WriteLine($"Promedio de páginas de los libros: {queries.PromedioPaginasLibros()}");

        //* Libros publicados a partir del 2000 agrupados por año
        //ImprimirGrupo(queries.LibrosAPartirDeAnioAgrupadosPorAnio(2000));

        // Diccionario de libros agrupados por primera letra del título
        var diccionarioLookup = queries.DiccionarioDeLibrosPorLetra();
        PrintDictionary(diccionarioLookup, 'P');
    }
}