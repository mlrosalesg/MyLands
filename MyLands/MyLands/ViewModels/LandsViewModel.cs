namespace MyLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Views;
    using Services;
    using Xamarin.Forms;
    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<LandItemViewModel> landsCollection;
        private List<Land> landsList;
        private bool isRefreshing;
        private string filter;
        
        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> LandsCollection
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
            this.LandsCollection = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            IsRefreshing = false;
            //await Application.Current.MainPage.DisplayAlert("Conectado!", response.Message, "Accept");
        }
        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.LandsCollection = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else
            {
                this.LandsCollection = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                                                                                                l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return this.landsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
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
    public class LandItemViewModel : Land
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get { return new RelayCommand(SelectLand); }
        }

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }

        #endregion
    }
}
