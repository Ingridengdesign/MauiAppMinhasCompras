﻿using MauiAppMinhasCompras.Views;

namespace MauiAppMinhasCompras
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Relatorio), typeof(Relatorio));
        }
    }
}
