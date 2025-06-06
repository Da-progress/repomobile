﻿namespace LoDo.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            Application.Current.MainPage.DisplayPromptAsync("test", "test");

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
