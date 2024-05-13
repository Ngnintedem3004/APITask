using ManagementDesTaches.Models;
using ManagementDesTaches.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementDesTaches.Repositories
{
    public class Repository : IRepository<Mtask>
    {
        private  MTaskContext _context { get; }

    public Repository( MTaskContext context) { 
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Mtask>>> GetAllTask()// get all Task 
        {
            return 
                await _context.Tasks
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Mtask>>> GetAllTask(TaskParameter parameterTask)// Get All Task by Pagging 
        {
           
         return 
                await _context.Tasks
                .Skip((parameterTask.PageNumber-1)* parameterTask.PageSize)
                .Take(parameterTask.PageSize)
                .ToListAsync();
        }

        public async Task<ActionResult<Mtask>> GetTaskById(int Id)// Get Task by Id 
        {
            return await _context.Tasks
                          .FindAsync(Id);    
                
        }

        public Task<ActionResult> UpdateTask(int Id, Mtask task)
        {
            throw new NotImplementedException();
        }

        public async  Task  DeleteTask(int Id)
        {
           var mtask=  await _context.Tasks
                                  .FindAsync (Id);
                      _context.

                Remove(mtask);
            
        }

        public async  Task InsertTask(Mtask task)
        {
              _context.Tasks.Add(task);
        }

        public async Task<ActionResult<IEnumerable<Mtask>>> SortTask(string ParameterSorted, string OrderSorted = "Asc")// sort Task
        {
            if (OrderSorted == "Asc")
            {
                switch (ParameterSorted)
                {
                    case "Id":
                        return await _context.Tasks
                    .OrderBy(x => x.Id)
                    .ToListAsync();
                    case "Priority":

                        return await _context.Tasks
                    .OrderBy(x => x.Priority)
                    .ToListAsync();
                    case "Description":
                        return await _context.Tasks
                   .OrderBy(x => x.Description)
                   .ToListAsync();
                    case "Name":
                        return await _context.Tasks
                  .OrderBy(x => x.Name)
                  .ToListAsync();
                    case "date":
                        return await _context.Tasks
                  .OrderBy(x => x.DueDate)
                  .ToListAsync();
                    case "Satus":

                        return await _context.Tasks
                  .OrderBy(x => x.status)
              .ToListAsync();
                    default:
                        return await _context.Tasks
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                }
                
            }
            else
            {
                switch (ParameterSorted)
                {
                    case "Id":
                        return await _context.Tasks
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
                    case "Priority":

                        return await _context.Tasks
                    .OrderByDescending(x => x.Priority)
                    .ToListAsync();
                    case "Description":
                        return await _context.Tasks
                   .OrderByDescending(x => x.Description)
                   .ToListAsync();
                    case "Name":
                        return await _context.Tasks
                  .OrderByDescending(x => x.Name)
                  .ToListAsync();
                    case "date":
                        return await _context.Tasks
                  .OrderByDescending(x => x.DueDate)
                  .ToListAsync();
                    case "Satus":

                        return await _context.Tasks
                  .OrderByDescending(x => x.status)
              .ToListAsync();

                        default: return
                           await _context.Tasks
                           .OrderBy(x => x.Id)
                           .ToListAsync();
                }

            }
        }

        public async Task<ActionResult<IEnumerable<Mtask>>> FilterTask(Mtask mtask ,string ParameterSorted="Id")//filter Task
        {
            switch (ParameterSorted)
            {
                case "Id":
                    return await _context.Tasks
                .Where(x => x.Id==mtask.Id)
                .ToListAsync();
                case "Priority":

                    return await _context.Tasks
                .Where(x => x.Priority==mtask.Priority)
                .ToListAsync();
                case "Description":
                    return await _context.Tasks
               .Where(x => x.Description==mtask.Description)
               .ToListAsync();
                case "Name":
                    return await _context.Tasks
              .Where(x => x.Name==mtask.Name)
              .ToListAsync();
                case "date":
                    return await _context.Tasks
              .Where(x => x.DueDate==mtask.DueDate)
              .ToListAsync();
                case "Satus":

                    return await _context.Tasks
              .Where(x =>x.status==mtask.status)
          .ToListAsync();

                default:
                    return
                   await _context.Tasks
                   .Where(x => x.Id==mtask.Id)
                   .ToListAsync();
            }


        }

    }
}
   