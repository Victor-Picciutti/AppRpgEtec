using AppRpgEtec.Models;
using AppRpgEtec.Services.Armas;
using AppRpgEtec.Services.Personagens;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Views.Armas;
using AppRpgEtec.Views.Usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Armas
{
    public class ListagemArmaViewModel : BaseViewModel
    {
        private ArmasServices aService;

        public ICommand DirecionarParaArmasCommand { get; set; }

        public ListagemArmaViewModel()
        {
            aService = new ArmasServices();
            InicializarCommands();
            Armas = new ObservableCollection<Arma>();

            _ = ObterArmas();
        }
        public void InicializarCommands()
        {
            DirecionarParaArmasCommand = new Command(async () => await DirecionarParaArmas());
        }
        public ObservableCollection<Arma> Armas { get; set; }

        public async Task ObterArmas()
        {
            try //Junto com o cacth evitara que erros fechem o aplicativo
            {
                Armas = await aService.GetArmasAsync();
                OnPropertyChanged(nameof(Armas));//Informara a View que houve carregamento
            }
            catch (Exception ex)
            {
                //Captará o erro para exibir em tela
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public static async Task DirecionarParaArmas()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ListagemViewArma());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informacção", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
