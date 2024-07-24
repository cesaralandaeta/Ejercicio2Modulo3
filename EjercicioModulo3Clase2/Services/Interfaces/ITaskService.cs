using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Domain.Entities;

namespace EjercicioModulo3Clase2.Services.Interfaces
{
    public interface ITaskService
    {
        public List<Tasks> GetAllTasks();
        Tasks GetTaskById(int id);
        Tasks AddTask(TasksDTO taskDto);
        Tasks UpdateTask(int id, TasksDTO taskDto);
        Tasks MarkTaskAsInactive(int id, LowTaskDTO taskDto);
    }
}
