using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoService
    {
        private readonly TodoRepository _repository = new();
        public List<Todo> GetTodos() => _repository.GetAll();
        public Todo CreateTodo(string title) => _repository.AddTodo(title);
        public bool UpdateTodo(int id, string title) =>
            _repository.UpdateTodo(id, title);
        public bool DeleteTodo(int id) => _repository.DeleteTodo(id);
        public bool ToggleTodo(int id) => _repository.ToggleComplete(id);
    }
}
