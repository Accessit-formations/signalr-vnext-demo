using System;
using System.ComponentModel.DataAnnotations;

namespace SignalrDemo.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        [Required] [MaxLength(140)] [MinLength(10)]
        public string Title { get; set; }

        public bool Completed { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}