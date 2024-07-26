public class Program{
    public static void Main(){
        TimeSpan timeSpan = new TimeSpan(3, 5, 10, 0);
        DateTime oggi = DateTime.Today;
        DateTime resultDate = oggi.Add(timeSpan);


        Console.WriteLine("data e ora risualtante", resultDate);


    }
}