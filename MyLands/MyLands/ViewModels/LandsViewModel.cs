namespace MyLands.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
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
        private ObservableCollection<Land> landsCollection;
        private List<Land> landsList;
        private bool isRefreshing;
        private string filter;
        
        #endregion

        #region Properties
        public ObservableCollection<Land> LandsCollection
        {
            get { return this.landsCollection; }
            set { SetValue(ref this.landsCollection, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set 
            { 
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
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

            this.landsList = (List<Land>)response.Result;
            this.LandsCollection = new ObservableCollection<Land>(this.landsList);
            IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert("Conectado!", response.Message, "Accept");
        }
        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.LandsCollection = new ObservableCollection<Land>(this.landsList);
            }
            else
            {
                this.LandsCollection = new ObservableCollection<Land>(this.landsList.Where(l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                                                                                                l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get { return new RelayCommand(LoadLands); }
        }
        public ICommand SearchCommand
        {
            get { return new RelayCommand(Search); }
        }
        #endregion
    }
}
