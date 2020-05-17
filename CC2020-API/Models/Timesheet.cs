using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CC2020_API.Models
{
    public class Timesheet
    {
        //Timesheet Properties
        [Key]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public TimeSpan Break { get; set; }


        //Timesheet Foreign Keys
        [Required]
        public string EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public long CompanyABN { get; set; }
        public virtual Company Company { get; set; }

        /**
         *
         * Helper Method found from: Tetsuya Yamamoto
         *
         * https://stackoverflow.com/questions/53356404/how-to-use-a-select-dropdown-for-datetime-field-and-maintain-mvc-model-binding
         *
         *
         *
         * **/
        [NotMapped]
        public IEnumerable<SelectListItem> ListOfTimeIntervals
        {
            get
            {
                var list = new List<SelectListItem>();
                // range of hours, multiplied by 4 (e.g. 24 hours = 96)
                int timeRange = 96;

                // range of minutes, e.g. 15 min
                int minuteRange = 15;

                // starting time, e.g. 0:00
                TimeSpan startTime = new TimeSpan(0, 0, 0);

                // placeholder
                list.Add(new SelectListItem { Text = "Choose a time", Value = "0", Disabled = true });

                // get standard ticks
                DateTime startDate = new DateTime(DateTime.MinValue.Ticks);

                // create time format based on range above
                for (int i = 0; i < timeRange; i++)
                {
                    int minutesAdded = minuteRange * i;
                    TimeSpan timeAdded = new TimeSpan(0, minutesAdded, 0);
                    TimeSpan tm = startTime.Add(timeAdded);
                    DateTime result = startDate + tm;

                    list.Add(new SelectListItem { Text = result.ToString("HH:mm"), Value = result.ToString("HH:mm") });
                }

                return list;
            }
        }
    }
}
