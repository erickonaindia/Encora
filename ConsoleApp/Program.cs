using ConsoleApp.Model;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Request stringRequest = new Request()
            {
                N = 3,
                Strings = new List<string>()
            {
                "kkkjjffg5",
                "gxtjtmtywr",
                "hnlnxiupgt",
            }
            };

            try
            {
                foreach (var item in SortingOperationsHelper.SortingOperations(stringRequest))
                {
                    Console.WriteLine($"Value: {item}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}