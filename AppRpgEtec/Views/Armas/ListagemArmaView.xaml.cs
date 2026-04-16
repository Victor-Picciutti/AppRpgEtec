using AppRpgEtec.ViewModels.Armas;


namespace AppRpgEtec.Views.Armas;

public partial class ListagemViewArma : ContentPage
{
    ListagemArmaViewModel viewModel;
    public ListagemViewArma()
    {
        InitializeComponent();

        viewModel = new ListagemArmaViewModel();
        BindingContext = viewModel;
        Title = "Armas - App Rpg Etec";
    }

}