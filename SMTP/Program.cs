namespace SMTP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SMTP.SendEmail("nicole.tumi@unmsm.edu.pe", "Prueba SMTP", "Soy una prueba ");
        }
    }
}