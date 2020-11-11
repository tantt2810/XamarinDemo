using demo.Modal;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace demo.ViewModal
{
    public class ToDoListVM
    {
        public ObservableCollection<ToDoItem> ToDoList { get; set; } = new ObservableCollection<ToDoItem>();
        public ToDoListVM()
        {

        }
        public void AddToDo(ToDoItem item)
        {
            ToDoList.Add(item);
        }

        public void DeleteToDo(ToDoItem item)
        {
            ToDoList.Remove(item);
        }
    }
}
