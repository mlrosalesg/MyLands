namespace MyLands.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json; 
    public class Currency
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
    }

    public class Language
    {
        [JsonProperty(PropertyName = "iso639_1")] 
        public string Iso6391 { get; set; }
        [JsonProperty(PropertyName = "iso639_2")] 
        public string Iso6392 { get; set; }
        [JsonProperty(PropertyName = "name")] 
        public string Name { get; set; }
        [JsonProperty(PropertyName = "nativeName")] 
        public string NativeName { get; set; }

    }

    public class Translations
    {
        [JsonProperty(PropertyName = "de")]
        public string German { get; set; }
        [JsonProperty(PropertyName = "es")]
        public string Spanish { get; set; }
        [JsonProperty(PropertyName = "fr")]
        public string French { get; set; }
        [JsonProperty(PropertyName = "ja")]
        public string Japanese { get; set; }
        [JsonProperty(PropertyName = "it")]
        public string Italian { get; set; }
        [JsonProperty(PropertyName = "br")]
        public string Brazilian { get; set; }
        [JsonProperty(PropertyName = "pt")]
        public string Portuguese { get; set; }
        [JsonProperty(PropertyName = "nl")]
        public string Dutch { get; set; }
        [JsonProperty(PropertyName = "hr")]
        public string Croatian { get; set; }
        [JsonProperty(PropertyName = "fa")]
        public string Danish { get; set; }

    }

    public class RegionalBloc
    {
        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Land
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "topLevelDomain")]
        public List<string> TopLevelDomain { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonProperty(PropertyName = "alpha3Code")]
        public string Alpha3Code { get; set; }

        [JsonProperty(PropertyName = "callingCodes")]
        public List<string> CallingCodes { get; set; }

        [JsonProperty(PropertyName = "capital")]
        public string Capital { get; set; }

        [JsonProperty(PropertyName = "altSpellings")]
        public List<string> AltSpellings { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "subregion")]
        public string Subregion { get; set; }

        [JsonProperty(PropertyName = "population")]
        public int Population { get; set; }

        [JsonProperty(PropertyName = "latlng")]
        public List<double> Latlng { get; set; }

        [JsonProperty(PropertyName = "demonym")]
        public string Demonym { get; set; }

        [JsonProperty(PropertyName = "area")]
        public double? Area { get; set; }

        [JsonProperty(PropertyName = "gini")]
        public double? Gini { get; set; }

        [JsonProperty(PropertyName = "timezones")]
        public List<string> Timezones { get; set; }

        [JsonProperty(PropertyName = "borders")]
        public List<string> Borders { get; set; }

        [JsonProperty(PropertyName = "nativeName")]
        public string NativeName { get; set; }

        [JsonProperty(PropertyName = "numericCode")]
        public string NumericCode { get; set; }

        [JsonProperty(PropertyName = "currencies")]
        public List<Currency> Currencies { get; set; }

        [JsonProperty(PropertyName = "languages")]
        public List<Language> Languages { get; set; }

        [JsonProperty(PropertyName = "translations")]
        public Translations Translations { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public string Flag { get; set; }

        [JsonProperty(PropertyName = "regionalBlocs")]
        public List<RegionalBloc> RegionalBlocs { get; set; }

        [JsonProperty(PropertyName = "cioc")]
        public string Cioc { get; set; }

    }

    public class Border
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

}
