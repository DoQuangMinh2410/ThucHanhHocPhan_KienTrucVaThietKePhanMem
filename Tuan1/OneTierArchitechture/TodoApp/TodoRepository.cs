using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos = new();
        private readonly string _filepath = "todos.txt";
        private int _nextID = 1;
        public TodoRepository() 
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if(!File.Exists(_filepath)) return;
            foreach (var line in File.ReadAllLines(_filepath))
            {
                var item = Todo.FromFileString(line);
                _todos.Add(item);
                if (item.Id >= _nextID)
                {
                    _nextID = item.Id++;
                }
            }
        }
        public void SaveChanges()
        {
            File.WriteAllLines(
                _filepath,
                _todos.Select(x => x.ToFileString())
            );
        }
        public List<Todo> GetAll() => _todos;
        public Todo AddTodo(string title)
        {
            var item = new Todo
            {
                Id = _nextID++,
                Title = title,
                IsSuccess = false
            };
            _todos.Add(item);
            SaveChanges();
            return item;
        }
        public bool UpdateTodo(int id, string title)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Title = title;
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteTodo(int id)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _todos.Remove(item);
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool ToggleComplete(int id)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsSuccess = !item.IsSuccess;
                SaveChanges();
                return true;
            }
            return false;
        }
    }
}
