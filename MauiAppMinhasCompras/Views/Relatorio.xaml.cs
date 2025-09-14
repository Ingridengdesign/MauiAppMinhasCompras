using MauiAppMinhasCompras.Models;
using System.Linq;

namespace MauiAppMinhasCompras.Views;


public partial class Relatorio : ContentPage
{
    public Relatorio()
    {
        InitializeComponent(); 

        var hoje = DateTime.Today;
        dpk_inicial.Date = new DateTime(hoje.Year, hoje.Month, 1);
        dpk_final.Date = hoje;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FiltrarProdutos();
    }

    private async void Button_Filtrar_Clicked(object sender, EventArgs e)
    {
        await FiltrarProdutos();
    }

    private async Task FiltrarProdutos()
    {
        try
        {
            DateTime dataInicial = dpk_inicial.Date;
            DateTime dataFinal = dpk_final.Date;

            List<Produto> todosOsProdutos = await App.Db.GetAll();

            var produtosDoPeriodo = todosOsProdutos.Where(p =>
                p.DataCadastro.Date >= dataInicial.Date &&
                p.DataCadastro.Date <= dataFinal.Date
            ).OrderByDescending(p => p.DataCadastro).ToList();

            cv_produtos_filtrados.ItemsSource = produtosDoPeriodo;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}