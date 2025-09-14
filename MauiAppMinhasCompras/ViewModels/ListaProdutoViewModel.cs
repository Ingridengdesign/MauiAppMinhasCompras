using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.ViewModels
{
    public partial class ListaProdutoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _searchText;

        public ObservableCollection<Produto> ProdutosFiltrados { get; set; } = new();

        private List<Produto> _todosOsProdutos = new();

        [RelayCommand]
        private async Task IrParaRelatorio()
        {
            await Shell.Current.GoToAsync(nameof(Relatorio));
        }


            [RelayCommand]
        private async Task Remover(Produto produto)
        {
            if (produto == null) return;

            await App.Db.Delete(produto.Id);

            _todosOsProdutos.Remove(produto);
            ProdutosFiltrados.Remove(produto);
        }

        [RelayCommand]
        private async Task Somar()
        {
            double soma = ProdutosFiltrados.Sum(i => i.Total);
            string msg = $"O total é {soma:C}";
            await App.Current.MainPage.DisplayAlert("Total dos Produtos", msg, "OK");
        }

        [RelayCommand]
        private async Task Adicionar()
        {
            await Shell.Current.GoToAsync(nameof(Views.NovoProduto));
        }

        partial void OnSearchTextChanged(string value)
        {
            FiltrarProdutos();
        }

        private void FiltrarProdutos()
        {
            var termoBusca = SearchText?.ToLower() ?? "";

            var produtosEncontrados = string.IsNullOrWhiteSpace(termoBusca)
                ? _todosOsProdutos
                : _todosOsProdutos.Where(p => p.Descricao.ToLower().Contains(termoBusca));

            ProdutosFiltrados.Clear();
            foreach (var p in produtosEncontrados)
            {
                ProdutosFiltrados.Add(p);
            }
        }
    
        public async Task CarregarProdutos()
        {
            _todosOsProdutos = await App.Db.GetAll();
            FiltrarProdutos();
        }
    }
}