using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiAppMinhasCompras.ViewModels
{
    public partial class RelatorioViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime dataInicial;

        [ObservableProperty]
        private DateTime dataFinal;

        [ObservableProperty]
        private ObservableCollection<Produto> produtosFiltrados;

        public RelatorioViewModel()
        {
            
            var hoje = DateTime.Today;
            DataInicial = new DateTime(hoje.Year, hoje.Month, 1);
            DataFinal = hoje;

            ProdutosFiltrados = new ObservableCollection<Produto>();
            Filtrar(); 
        }

        [RelayCommand]
        private void Filtrar()
        {
       
            if (App.ListaProdutos == null) return;

            
            var produtosDoPeriodo = App.ListaProdutos.Where(p =>
                p.DataCadastro.Date >= DataInicial.Date &&
                p.DataCadastro.Date <= DataFinal.Date
            ).OrderByDescending(p => p.DataCadastro).ToList();


            ProdutosFiltrados.Clear();
            foreach (var produto in produtosDoPeriodo)
            {
                ProdutosFiltrados.Add(produto);
            }
        }
    }
}