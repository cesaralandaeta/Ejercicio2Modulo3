using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;

namespace EjercicioModulo3Clase2.Controllers
{
    [Route( "v1" )]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Pasos previos
        /*
         * 1 - Instalar EF Core y EF Core SQL Server
         * 2 - Crear contexto de base de datos y los modelos. Se puede usar Ingenieria Inversa de EF Core Power Tools
         * 3 - Configurar la inyección de dependencia del contexto tanto en Program.cs como en el controlador. No olvidar el string de conexión.
         * 4 - Las rutas de los endpoints queda a criterio de cada uno.
         * 5 - En este controlador, realizar los siguientes ejercicios:
         */
        #endregion
        private readonly ToDoListDBContext _Context;

        public TaskController(ToDoListDBContext context)
        {
            _Context = context;
        }

        #region Ejercicio 1
        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET
        [HttpGet]
        public IActionResult TaskList() 
        {
            return Ok(_Context.Tasks.ToList());
        }
        #endregion

        #region Ejercicio 2
        // Crear un endpoint para obtener una tarea por ID usando HTTP GET
        #endregion
        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult TaskDetail([FromRoute] int id) 
        {
            return Ok(_Context.Tasks.FirstOrDefault(t => t.Id == id));
        }
        #region Ejercicio 3
        // Crear un endpoint para crear una nueva tarea usando HTTP POST
        [HttpPost]
        [Route("AddTask")]
        public IActionResult newTasks([FromBody] TasksDTO tarea)
        {
            Tasks t = new Tasks()
            {
                Title = tarea.Title,
                Description = tarea.Description,
                DueDate = tarea.DueDate,
                IsCompleted = tarea.IsCompleted,
                IsActive = tarea.IsActive,
            };
            _Context.Add(t);
            _Context.SaveChanges();
            return CreatedAtRoute("GetTaskById", new { id = t.Id }, t);
           
        }
        #endregion

        #region Ejercicio 4
        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT
        [HttpPut("{id}")]
        public IActionResult UpDate([FromRoute] int id,[FromBody] TasksDTO tarea)
        {
          var t = _Context.Tasks.FirstOrDefault(t => t.Id == id);
            t.Title = tarea.Title;
            t.Description = tarea.Description;
            t.DueDate = tarea.DueDate;
            t.IsCompleted = tarea.IsCompleted;
            t.IsActive = tarea.IsActive;
            _Context.SaveChanges();
            return Ok(t);
        }
        #endregion

        #region Ejercicio 5
        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)
        #endregion
        [HttpPut("Low/{id}")]
        public IActionResult lowTask([FromRoute] int id, [FromBody] LowTaskDTO tarea)
        {
            var t = _Context.Tasks.FirstOrDefault(t => t.Id == id);
            t.IsActive = tarea.IsActive;
            _Context.SaveChanges();
            return Ok(t);
        }

    }
}
