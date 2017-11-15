using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Akavache;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace TaskList
{
    public partial class TaskListPage : ContentPage
    {
        public ObservableCollection<TodoItem> ToDoItems { get; set; }
        public ICommand DeleteCommand { get; set; }
    
        public TaskListPage()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem() { Text = "+", Command = new Command(ShowAddForm) });
            DeleteCommand = new Command<TodoItem>(RemoveItem);
        }

        private void ShowAddForm(object obj)
        {
            Navigation.PushModalAsync(new AddItemPage());
        }

        private void RemoveItem(TodoItem obj)
        {
            ToDoItems.Remove(obj);
            TodoList.ItemsSource = ToDoItems;
        }

        void Handle_Pressed(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var todoItem = button.BindingContext as TodoItem;
            DeleteCommand.Execute(todoItem);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                ToDoItems = await BlobCache.UserAccount.GetObject<ObservableCollection<TodoItem>>("TodoList");
            }
            catch (KeyNotFoundException ex)
            {
                ToDoItems = new ObservableCollection<TodoItem>() {
                   new TodoItem() {Importance = TodoItem.priority.low, ItemName = "Take out trash", ItemId = Guid.NewGuid().ToString()},
                   new TodoItem() {Importance = TodoItem.priority.medium, ItemName = "Walk Dog", ItemId = Guid.NewGuid().ToString()}
               };
                await BlobCache.UserAccount.InsertObject("TodoList", ToDoItems);
            }

            TodoList.ItemsSource = ToDoItems;
        }
    }


}
