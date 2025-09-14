using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
 
            if (string.IsNullOrEmpty(txt_descricao.Text) ||
                string.IsNullOrEmpty(txt_quantidade.Text) ||
                string.IsNullOrEmpty(txt_preco.Text))
            {
                await DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),
                DataCadastro = dpk_data.Date 
            };

            await App.Db.Insert(p);

            await DisplayAlert("Sucesso!", "Produto salvo com sucesso!", "OK");

            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}