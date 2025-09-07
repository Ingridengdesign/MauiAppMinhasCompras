using MauiAppMinhasCompras.ViewModels;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
        // O BindingContext já é criado no XAML, mas você pode setar aqui também se preferir.
        // BindingContext = new ListaProdutoViewModel();
    }

    protected override async void OnAppearing()
    {
        // Pede para a ViewModel carregar os dados
        if (BindingContext is ListaProdutoViewModel vm)
        {
            await vm.CarregarProdutos();
        }
    }
}