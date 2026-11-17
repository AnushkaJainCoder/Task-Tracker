// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!")
// ;

using TaskTracker.Models;
using TaskTracker.Services;

TaskService service = new TaskService();

if (args.Length == 0)
{
    Console.WriteLine("please provide a command");
    return;
}

void displayItems()
{
    List<TasKItem> tasks = service.DisplayAllTasks();
    foreach (var task in tasks)
    {
        Console.WriteLine($"{task.ID} - {task.Desc} - {task.Status}");
    }
}


string cmd = args[0].ToLower();

if (cmd == "list")
{
    displayItems();
}
else if (cmd == "add")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Usage: add  <description>");
        return;
    }
    service.AddTask(args[1]);
    Console.WriteLine("Added Successfully");
    displayItems();
}
else if (cmd == "update")
{
    if (args.Length < 3)
    {
        Console.WriteLine("Usage: update <id> <description>");
        return;
    }
    service.UpdateTask(Convert.ToInt32(args[1]), args[2]);
    displayItems();
}
else if (cmd == "delete")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Usage: delete <id>");
        return;
    }
    service.DeleteTask(Convert.ToInt32(args[1]));
    displayItems();
}
else if(cmd == "mark-todo" || cmd == "mark-in-progress" || cmd == "mark-done")
{
    service.UpdateStatus(args[0], Convert.ToInt32(args[1]));
    displayItems();
}
else
{
    Console.WriteLine("Invalid Input");
}


// foreach(var arg in args)
// {
//     Console.WriteLine(arg);
// }

// service.AddTask("Learn ASP.NET Core");
// List<TasKItem> tasks = service.DisplayAllTasks();
// foreach(var task in tasks)
// {
//     Console.WriteLine($"{task.ID} - {task.Desc}");
//     //Console.WriteLine(task.Desc);

// }
// service.UpdateTask(4, "Learn Python");
// service.DeleteTask(4);
// List<TasKItem> asks = service.DisplayAllTasks();
// foreach(var task in asks)
// {
//     Console.WriteLine($"{task.ID} - {task.Desc}");
//     //Console.WriteLine(task.Desc);

// }
// var tasks = service.DisplayAllTasks();
// List<TasKItem> tasks = new();

// tasks.Add(
//     new TasKItem
//     {
//         ID = 2,
//         Desc = "Learn ASP.NET"
//     }
// );
// service.SaveTasks(tasks);
// Console.WriteLine("saved");



// List<TasKItem> tasks = service.DisplayAllTasks();

// if(tasks.Count == 0)
// {
//     Console.WriteLine("empty");
// }
// foreach(var i in tasks)
// {

//     Console.WriteLine(i.ID);
//     Console.WriteLine(i.Desc);

//     // Console.WriteLine("numbver are ");
// }
