using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly TodoContext todoDb;

        public TodoController(TodoContext context)
        {
            this.todoDb = context;
        }


        [HttpGet("{id}")]
        public ActionResult<Order> GetTodoItem(long id)
        {
            var order = todoDb.Orders.FirstOrDefault(o=> o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetTodoItems(string name)
        {
            var query = buildQuery(name);
            return query.ToList();
        }

        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                todoDb.Orders.Add(order);
                todoDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(long id)
        {
            try
            {
                var order = todoDb.Orders.FirstOrDefault(o => o.Id == id);
                if (order != null)
                {
                    todoDb.Remove(order);
                    todoDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}