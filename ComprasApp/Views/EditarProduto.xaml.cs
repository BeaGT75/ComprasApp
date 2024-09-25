using ComprasApp.Models;

namespace ComprasApp.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto produto_anexado = BindingContext as Produto;

			Produto p = new Produto()
			{
				Id = produto_anexado.Id, Descricao = txt_descricao.Text, Preco = Convert.ToDouble(txt_preco.Text), Quantidade = Convert.ToDouble(txt_quantidade.Text),
			};
			await App.Database.Update(p);
			await DisplayAlert("Sucesso", "Atualizado", "Ok");
			await Navigation.PushAsync(new MainPage());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}