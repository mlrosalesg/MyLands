namespace MyLands.ViewModels
{
    using MyLands.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    public class MainViewModel
    {

        #region ViewModels
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
        #endregion

        #region Properties
        public List<Land> LandsList { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            // Only first page is required, the rest will be initiated when needed
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel {Icon="ic_settings", PageName="MyProfilePage", Title="My Profile" });
            this.Menus.Add(new MenuItemViewModel { Icon = "ic_insert_chart", PageName = "StatisticsPage", Title = "Statistics" });
            this.Menus.Add(new MenuItemViewModel { Icon = "ic_exit_to_app", PageName = "LoginPage", Title = "Logout" });
        } 
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            return instance;
        }
        #endregion
    }
}
