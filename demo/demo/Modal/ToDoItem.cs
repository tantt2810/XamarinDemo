using System;
using System.Drawing;

namespace demo.Modal
{
    public class ToDoItem
    {
        public TimeSpan Time { get; set; }
        public string Note { get; set; }

        public Color NeedToDoColor
        {
            get
            {
                return (Time - DateTime.Now.TimeOfDay).TotalMinutes <= 30 ? Color.LightCoral : Color.LightBlue;
            }
        }
    }
}
