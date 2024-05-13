using ManagementDesTaches.Models;
using ManagementDesTaches.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementDesTaches.Repositories
{
    public interface IRepository<Mtask>
    {
       public Task< ActionResult<IEnumerable<Mtask>>>GetAllTask();
        public Task<ActionResult<IEnumerable<Mtask>>> GetAllTask(TaskParameter parameterTask);
       public  Task<ActionResult<Mtask>> GetTaskById(int Id);
       public Task<ActionResult> UpdateTask(int Id,Mtask task);
       public Task DeleteTask(int Id);
       public Task InsertTask(Mtask task); 
       public  Task<ActionResult<IEnumerable<Mtask>>>FilterTask(Mtask mtask,string ParameterSorted);
       public  Task<ActionResult<IEnumerable<Mtask>>>SortTask(string ParameterSorted,string OrderSorted );
       
    }
}
