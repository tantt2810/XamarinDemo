using demo.Modal;
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
    public partial class ToDoAdding : ContentPage
    {
        private ToDoListVM vm;
        public ToDoAdding(ToDoListVM vm)
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            this.vm = vm;
            InitUI();
            //App.Current.Resources["ThemeColor"] = Color.Blue;
        }

        private void InitUI()
        {
            tpTime.Time = DateTime.Now.TimeOfDay;
            InitEvents();
        }

        private void InitEvents()
        {
            btnBack.Clicked += async delegate
            {
                await Navigation.PopAsync();
            };

            btnSave.Clicked += async delegate
            {
                ToDoItem newTodo = new ToDoItem();
                newTodo.Time = tpTime.Time;
                newTodo.Note = edtNote.Text;

                //if(tpTime.Time.CompareTo(DateTime.Now.TimeOfDay) < 0){
                //    newTodo.NeedBeDoneColor = "red";
                //}
                
                vm.AddToDo(newTodo);

                await Navigation.PopAsync();
            };
        }
    }
}