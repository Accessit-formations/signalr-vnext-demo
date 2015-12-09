using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalrDemo.Models;

namespace SignalrDemo.Hubs
{
    [HubName("tasks")]
    public class Tasks : Hub
    {
        /// <summary>
        /// Our method to create a task
        /// </summary>
        public bool Add(Task newTask)
        {
            try
            {
                Clients.All.taskAdded(newTask);
                return true;
            }
            catch (Exception ex)
            {
                Clients.Caller.reportError($"Unable to create task. Make sure title length is between 10 and 140. Message: {ex.Message}");
                return false;
            }

        }

        /// <summary>
        /// To get all the tasks up on init
        /// </summary>
        public void GetAll()
        {
            var tasks = new List<Task>
            {
                new Task
                {
                    Completed = true,
                    LastUpdated = DateTime.Now.AddDays(-1),
                    TaskId = 1,
                    Title = "tutu"
                },
                new Task
                {
                    Completed = false,
                    LastUpdated = DateTime.Now.AddDays(-1),
                    TaskId = 2,
                    Title = "toto"
                },
            };

            Clients.Caller.taskAll(tasks);
        }
    }
}