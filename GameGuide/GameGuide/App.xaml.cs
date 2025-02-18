﻿using GameGuide.Services;
using GameGuide.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameGuide
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockGameDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
