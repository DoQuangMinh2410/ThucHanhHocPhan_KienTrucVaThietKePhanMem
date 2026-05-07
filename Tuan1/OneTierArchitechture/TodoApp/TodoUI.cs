using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoUI
    {
        private readonly TodoService _service = new();
        public void ShowTodos()
        {
            var todos = _service.GetTodos();
            Console.WriteLine("=====DANH SÁCH CÔNG VIỆC=====");
            foreach (var item in todos)
            {
                Console.WriteLine(item.ToString());
            }
            if (todos.Count <= 0)
                Console.WriteLine("Chưa có công việc nào!");
            Console.WriteLine("------------------------------");
        }
        public void ShowMennu()
        {
            Console.WriteLine("Chức năng: ");
            Console.WriteLine("1. Thêm mới");
            Console.WriteLine("2. Xóa công việc");
            Console.WriteLine("3. Đánh dấu hoàn thành");
            Console.WriteLine("4. Sửa công việc");
            Console.WriteLine("0. Thoát");
        }
        public void AddTodo()
        {
            Console.Write("Nhập nội dung công việc: ");
            string content = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(content))
                _service.CreateTodo(content);
        }
        public void RemoveTodo()
        {
            Console.WriteLine("Nhập ID công việc cần xóa: ");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteTodo(id);
        }
        public void ToggleTodo()
        {
            Console.WriteLine("Nhập ID công việc: ");
            int id = int.Parse(Console.ReadLine());
            _service.ToggleTodo(id);
        }
        public void EditTodo()
        {
            Console.WriteLine("Nhập ID công việc cần sửa: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập Nội dung mới: ");
            string content = Console.ReadLine();
            _service.UpdateTodo(id, content);
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowTodos();
                ShowMennu();
                Console.Write("- Chọn: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        RemoveTodo();
                        break;
                    case "3":
                        ToggleTodo();
                        break;
                    case "4":
                        EditTodo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
                Console.WriteLine("Nhấn Enter để tiếp tục....");
                Console.ReadLine();
            }
        }
    }
}
