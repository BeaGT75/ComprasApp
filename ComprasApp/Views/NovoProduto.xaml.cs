using ComprasApp.Models;

namespace ComprasApp.Views;

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
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text, Quantidade = Convert.ToDouble(txt_quantidade.Text), Preco = Convert.ToDouble(txt_preco.Text)
			};
			await App.Database.Insert(p);
			await DisplayAlert("Sucesso!", "Produto Inserido", "Ok");
			await Navigation.PushAsync(new MainPage());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}