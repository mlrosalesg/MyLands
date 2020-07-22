namespace MyLands.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using Xamarin.Forms;
    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Land> landsList;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<Land> LandsList
        {
            get { return this.landsList; }
            set { SetValue(ref this.landsList, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string TestProp { get; set; }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            TestProp = "Hola Lula";

            // Start the api service
            this.apiService = new ApiService();
            // Load Lands
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if(!connection.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                //Return to previous page if there is no connection
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Land>("https://restcountries.eu", "/rest", "/v2/all");

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                //Return to previous page if there is no connection
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var list = (List<Land>)response.Result;
            this.LandsList = new ObservableCollection<Land>(list);
            IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert("Conectado!", response.Message, "Accept");
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get { return new RelayCommand(LoadLands); }
        }
        #endregion
    }
}
