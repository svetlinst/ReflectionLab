namespace Stealer
{
    using System;

    public class StartUp
    {
        [Author("SvetlinStoyanov")]
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
            
        }
    }
}
