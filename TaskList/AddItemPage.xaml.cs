using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TaskList
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
            PriorityPicker.Items.Add("low");
            PriorityPicker.Items.Add("medium");
            PriorityPicker.Items.Add("high");
            PriorityPicker.Items.Add("critical");
        }

        void Handle_Pressed(object sender, System.EventArgs e)
        {
            
        }
    }
}
