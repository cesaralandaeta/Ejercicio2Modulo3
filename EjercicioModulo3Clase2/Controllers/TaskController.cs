using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;
using EjercicioModulo3Clase2.Services;
using Microsoft.EntityFrameworkCore;
using EjercicioModulo3Clase2.Services.Interfaces;

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
       private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        #region Ejercicio 1
        // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET
        [HttpGet]
        public IActionResult TaskList() 
        {
            var result = _taskService.GetAllTasks(); 
            return Ok(result);
        }
        #endregion

        #region Ejercicio 2
        // Crear un endpoint para obtener una tarea por ID usando HTTP GET
        #endregion
        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult TaskDetail([FromRoute] int id) 
        {
            var result = _taskService.GetTaskById(id);
            return Ok(result);
        }
        #region Ejercicio 3
        // Crear un endpoint para crear una nueva tarea usando HTTP POST
        [HttpPost]
        [Route("AddTask")]
        public IActionResult newTasks([FromBody] TasksDTO tarea)
        {
            var result = _taskService.AddTask(tarea);
            return CreatedAtRoute("GetTaskById", new { id = result.Id }, result);
           
        }
        #endregion

        #region Ejercicio 4
        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT
        [HttpPut("{id}")]
        public IActionResult UpDate([FromRoute] int id, [FromBody] TasksDTO tarea)
        {
            var result = _taskService.GetTaskById(id);

            return Ok(result);
        }
        #endregion

        #region Ejercicio 5
        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)
        #endregion
        [HttpPut("Low/{id}")]
        public IActionResult lowTask([FromRoute] int id, [FromBody] LowTaskDTO tarea)
        {
            var result = _taskService.MarkTaskAsInactive(id, tarea);
           
            return Ok(result);
        }

    }
}
