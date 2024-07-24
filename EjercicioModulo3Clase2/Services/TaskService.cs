using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Repository;
using EjercicioModulo3Clase2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EjercicioModulo3Clase2.Services
{
    public class TaskService: ITaskService
    {
        private readonly ToDoListDBContext _context;
        public TaskService(ToDoListDBContext context)
        {
            _context = context;
        }
        public List<Tasks> GetAllTasks()
        {
            return _context.Tasks.ToList(); 
        }
        public Tasks GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public Tasks AddTask(TasksDTO taskDto)
        {
            var task = new Tasks
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                IsCompleted = taskDto.IsCompleted,
                IsActive = taskDto.IsActive,
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public Tasks UpdateTask(int id, TasksDTO taskDto)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.DueDate = taskDto.DueDate;
            task.IsCompleted = taskDto.IsCompleted;
            task.IsActive = taskDto.IsActive;

            _context.SaveChanges();
            return task;
        }

        public Tasks MarkTaskAsInactive(int id, LowTaskDTO taskDto)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            task.IsActive = taskDto.IsActive;
            _context.SaveChanges();
            return task;
        }
    }
}
