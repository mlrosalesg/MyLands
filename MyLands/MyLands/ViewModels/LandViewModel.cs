namespace MyLands.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        #region Properties
        public Land Land { get; set; }
        public ObservableCollection<Currency> Currencies { get; set; }
        public ObservableCollection<Language> Languages { get; set; }
        public Translations Translations { get; set; }

        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }
        #endregion

        #region Attributes
        private ObservableCollection<Border> borders;
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            // Assign selected land to land property
            this.Land = land;
            // Load Borders
            this.LoadBorders();
            // Load other info
            this.LoadInfo();
  
        }
        #endregion

        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.Where(l => l.Alpha3Code == border).FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border { Code = border, Name = land.Name });
                }
            }

        }
        private void LoadInfo()
        {
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Land.Languages);
        }
        #endregion

    }
}
