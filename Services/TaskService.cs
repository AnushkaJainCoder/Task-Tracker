using System.Text.Json;
using TaskTracker.Models;
namespace TaskTracker.Services;

public class TaskService
{
    private readonly string file_path = "Data/task.json";
    public List<TasKItem> DisplayAllTasks()
    {
        if (!File.Exists(file_path))
        {
            return new List<TasKItem>();
        }
        string fileData = File.ReadAllText(file_path);
        // Console.Write($"fileData value:{fileData}");
        List<TasKItem>? tasks = JsonSerializer.Deserialize<List<TasKItem>>(fileData);
        return tasks ?? new List<TasKItem>();

    }

    public void SaveTasks(List<TasKItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file_path, json);
    }

    public void AddTask(string description)
    {
        List<TasKItem> tasks = DisplayAllTasks();
        // int id = tasks.Count + 1;
        int id = tasks.Count == 0 ? 1 : tasks.Max(t => t.ID) + 1;
        TasKItem task = new TasKItem()
        {
            ID = id,
            Desc = description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        tasks.Add(task);
        SaveTasks(tasks);

    }

    public void UpdateTask(int id, string desc)
    {
        List<TasKItem> tasks = DisplayAllTasks();


        foreach (var task in tasks)
        {
            if (task.ID == id)
            {
                task.Desc = desc;
                task.UpdatedAt = DateTime.UtcNow;
                SaveTasks(tasks);
                Console.WriteLine($"updated task  {task.ID}, {task.Desc}, {task.UpdatedAt}");
                return;
            }

        }
        Console.WriteLine("no such id found");
    }

    public void UpdateStatus(string status, int id)
    {
        List<TasKItem> tasks = DisplayAllTasks();
        var task = tasks.FirstOrDefault(t => t.ID == id);
        if (task != null)
        {
            if(status == "mark-in-progress")
            {
                task.Status = "in-progress";
                
            }
            else
            {
                task.Status = status=="mark-done" ? "done" : "todo";
            }
            task.UpdatedAt = DateTime.UtcNow;
            // task.Status = status;
            SaveTasks(tasks);
            Console.WriteLine($"Task status has been updated to {status}");
            return;

        }
        Console.WriteLine("Id not found");
    }
    public void DeleteTask(int id)
    {
        List<TasKItem> tasks = DisplayAllTasks();
        //Collection was modified; enumeration operation may not execute.

        // foreach(var task in tasks)
        // {
        //     if(task.ID == id)
        //     {
        //         tasks.Remove(task);
        //         SaveTasks(tasks);
        //         Console.WriteLine($"deleted successfully {id}");
        //         return;
        //     }
        // }
        var task = tasks.FirstOrDefault(i => i.ID == id);
        if (task != null)
        {
            tasks.Remove(task);
            SaveTasks(tasks);
            return;

        }
        Console.WriteLine("id not found");
    }

}