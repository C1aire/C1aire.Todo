using System;
using System.Collections.Generic;

namespace C1aire.Todoer
{
    public class TodoStore
    {
        public List<Todo> Todoes = new List<Todo>();
        public void Add(Todo todo)
        {
            Todoes.Add(todo);
        }
        public void Remove(int todoId)
        {
            Todoes.RemoveAt(todoId);
        }
        public void Update(int todoId, string text)
        {
            Todoes[todoId] = new Todo(text);
        }
    }
    public class Todo
    {
        public readonly string Title;
        public Todo(string title)
        {
            this.Title = title;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var store = new TodoStore();
            for (;;)
            {
                try
                {
                    Console.WriteLine("Задачи:");
                    for (var i = 0; i < store.Todoes.Count; ++i)
                        Console.WriteLine($"{i+1}: {store.Todoes[i].Title}");
                    Console.WriteLine();
                    Console.WriteLine("1 - добавить, 2 - удалить, 3 - изменить, 0 - выход");
                    Console.Write("> ");
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "0":
                            return;
                            break;
                        case "1":
                            Console.WriteLine("Введите");
                            Console.Write("> ");
                            var text = Console.ReadLine();
                            store.Add(new Todo(text));
                            break;
                        case "2":
                        {
                            Console.WriteLine("Введите номер задачи для удаления");
                            var numberText = Console.ReadLine();
                            store.Remove(int.Parse(numberText)-1);
                            break;
                        }
                        case "3":
                        {
                            Console.WriteLine("Введите номер задачи для изменения");
                            var numberText = Console.ReadLine();
                            Console.WriteLine("Введите новый текст задачи");
                            var title = Console.ReadLine();
                            store.Update(int.Parse(numberText)-1, title);
                            break;
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Ошибка: {exc.Message}");
                }

              

            }

        }
    }
}
