using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMinhasCompras.Models;
using System;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.ViewModels
{
    public partial class NovoProdutoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string descricao;

        [ObservableProperty]
        private double quantidade;

        [ObservableProperty]
        private double preco;

        [ObservableProperty]
        private DateTime dataCadastro = DateTime.Now;

        [RelayCommand]
        private void SalvarProduto()
        {
            try
            {
                var produto = new Produto
                {
                    Descricao = Descricao,
                    Quantidade = Quantidade,
                    Preco = Preco,
                    DataCadastro = this.DataCadastro 
                };

                App.ListaProdutos.Add(produto);
                App.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private void Cancelar()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}