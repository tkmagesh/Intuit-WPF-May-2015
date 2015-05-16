namespace MyLibrary
{
    using System;

    public class TimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now - new TimeSpan(2,0,0,0);
        }
    }
}

