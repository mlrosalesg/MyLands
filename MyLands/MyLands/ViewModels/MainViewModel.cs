namespace MyLands.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
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
