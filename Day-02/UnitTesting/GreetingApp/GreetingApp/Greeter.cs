using System;

namespace GreetingApp
{
    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
    public class Greeter
    {
        private readonly ITimeService _timeService;
        public string Name { get; set; }
        public string Message { get; set; }

        /*public Greeter()
        {
            
        }*/
        public Greeter(ITimeService timeService)
        {
            _timeService = timeService;
            Name = string.Empty;
            Message = string.Empty;
        }
        public void Greet()
        {
            
            const string morningMessage = "Hi {0}, Good Morning!";
            const string eveningMessage = "Hi {0}, Good Evening!";

            Message = string.Format(_timeService.GetCurrentTime().Hour < 12 ? morningMessage : eveningMessage, Name);
        }
    }
}