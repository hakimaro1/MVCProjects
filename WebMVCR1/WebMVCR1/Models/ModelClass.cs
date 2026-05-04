namespace WebMVCR1.Models
{
    public class ModelClass
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public static string ModelHello()
        {
            int hour = DateTime.Now.Hour;
            string Greeting = hour < 12 ? "Доброе утро" :
           "Добрый день";
            return Greeting;
        }
    }

}
