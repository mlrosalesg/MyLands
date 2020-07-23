namespace MyLands.ViewModels
{
    using MyLands.Models;
    using System.Collections.Generic;
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
        #endregion

        #region Properties
        public List<Land> LandsList { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            // Only first page is required, the rest will be initiated when needed
            this.Login = new LoginViewModel();
            instance = this;
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
