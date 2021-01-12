using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorSamples.Client.Components
{
    public class TaskListBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public ILogger<TaskListBase> Logger { get; set; }
        
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Tasks = new List<TaskItem>();
                Tasks.Add(new TaskItem()
                {
                    Title = "Buy milk",
                    Description = "Buy milk at the store",
                    Status = TaskItemStatus.InProgress
                });

            } 
            catch(Exception e)
            {
                Logger.LogDebug(e, e.Message);
            }
        }

        public void AddTask()
        {
            NavManager.NavigateTo("taskedit");
        }
    }

    public class TaskItem
    {
        public int HRTaskId { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public int AssignedTo { get; set; }

        public TaskItemStatus Status { get; set; }
        
    }

    public enum TaskItemStatus
    {
        Open,
        Assigned,
        InProgress,
        Blocked,
        Complete
    }
}