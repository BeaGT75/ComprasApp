using System.Collections.ObjectModel;
using ComprasApp.Models;

namespace ComprasApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Produto> lista_produtos = new();

        public MainPage()
        {
            InitializeComponent();
            lst_produtos.ItemsSource = lista_produtos;
        }


        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {

        }

        private async void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.NovoProduto());
        }

        protected async override void OnAppearing()
        {
            //if (lista_produtos.Count == 0)
            //{
                List<Produto> tmp = await App.Database.GetAll();
                foreach (Produto p in tmp) 
                {
                lista_produtos.Add(p);
                }
            //}
        }

        private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;
            lista_produtos.Clear();

            List<Produto> tmp = await App.Database.Search(q);
            foreach (Produto p in tmp)
            {
                lista_produtos.Add(p);
            }
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e) 
        {
            Produto? p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p
            });
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem selecionado = sender as MenuItem;
                Produto p =
                    selecionado.BindingContext as Produto;

                bool confirm = await DisplayAlert("Tem Certeza?", "Remover Produto?", "Sim", "Não");

                if (confirm)
                {
                    await App.Database.Delete(p.Id);
                    await DisplayAlert("Sucesso!", "Produto Removido", "Ok");
                    lista_produtos.Remove(p);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }
    }

}
