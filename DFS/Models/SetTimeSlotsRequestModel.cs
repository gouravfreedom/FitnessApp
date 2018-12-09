using System;
using System.Collections.Generic;

namespace DFS.Models
{
    public class SetTimeSlotsRequestModel
    {
        public string emailID { get; set; }

        public string addByEmailID { get; set; }

        public List<TimeSlot> timeSlot { get; set; }

        public class TimeSlot
        {
            public string day { get; set; }

            public string month { get; set; }

            public string year { get; set; }

            public string startTime { get; set; }

            public string endTime { get; set; }

            public string remarks { get; set; }
        }

    }
}
