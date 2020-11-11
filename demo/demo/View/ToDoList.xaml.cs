using demo.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace demo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {
        private ToDoListVM vm;
        public ToDoList()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            InitUI();

            //lvTodo.ItemsSource = new List<string>()
            //{
            //    "Have breakfast",
            //    "Do exercise",
            //};
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowNotification();
        }

        private void InitUI()
        {
            vm = new ToDoListVM();
            vm.AddToDo(new Modal.ToDoItem() { Time = DateTime.Now.TimeOfDay, Note = "First Note" });
            vm.AddToDo(new Modal.ToDoItem() { Time = DateTime.Now.TimeOfDay, Note = "Second Note" });
            this.BindingContext = vm;


            //ShowNotification();
            InitEvents();
        }

        private void InitEvents()
        {
            //btnAdd.Clicked += async delegate
            //{
            //    await Navigation.PushAsync(new ToDoAdding(vm));
            //};
            TapGestureRecognizer addTapGesture = new TapGestureRecognizer();
            addTapGesture.Tapped += async delegate
            {
                await Navigation.PushAsync(new ToDoAdding(vm));
            };
            btnAdd.GestureRecognizers.Add(addTapGesture);


        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            var toDoItem = ((Button)sender).BindingContext as Modal.ToDoItem;
            vm.DeleteToDo(toDoItem);
            ShowNotification();
        }

        private void ShowNotification()
        {
            bool isEmptyList = vm.ToDoList.Count == 0;
            lvTodo.IsVisible = !isEmptyList;
            lblNotification.IsVisible = isEmptyList;
            lblNotification.Text = "Empty List";
        }
    }
}