using MauiAppMinhasCompras.ViewModels;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
        // O BindingContext j� � criado no XAML, mas voc� pode setar aqui tamb�m se preferir.
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