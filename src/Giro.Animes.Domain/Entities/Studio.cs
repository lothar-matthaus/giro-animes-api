using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class Studio : EntityBase
    {
        #region Name
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Name", string.Format(Message.Validation.General.REQUIRED, "Name")),
                    ifValid: () => _name = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Studio.NAME, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Name", Message.Validation.Studio.INVALID_NAME),
                    ifValid: () => _name = value);

                Validate(
                   isInvalidIf: !Regex.IsMatch(Patterns.Studio.NAME_LENGHT, value),
                   ifInvalid: () => ValidationError.Create(GetType().Name, "Name", Message.Validation.Studio.INVALID_NAME_LENGHT),
                   ifValid: () => _name = value);
            }
        }
        #endregion

        public DateTime EstablishedDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        #region WebSite

        private string _website = string.Empty;
        public string Website
        {
            get { return _website; }
            set
            {
                Validate(
                    isInvalidIf: (!string.IsNullOrEmpty(value) && !Regex.IsMatch(Patterns.General.URL, value)),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Website", Message.Validation.General.INVALID_URL),
                    ifValid: () => _website = value);
            }
        }
        #endregion

        /// <summary>
        /// Twitter do autor
        /// </summary>
        #region Twitter
        private string _twitter;

        public string Twitter
        {
            get { return _twitter; }
            set
            {
                Validate(
                    isInvalidIf: (!string.IsNullOrEmpty(value) && !Regex.IsMatch(Patterns.General.URL_TWITTER, value)),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Twitter", Message.Validation.General.INVALID_URL),
                    ifValid: () => _twitter = value);
            }
        }
        #endregion

        #region Instagram
        private string _instagram;

        public string Instagram
        {
            get { return _instagram; }
            set
            {
                Validate(
                    isInvalidIf: (!string.IsNullOrEmpty(value) && !Regex.IsMatch(Patterns.General.URL_INSTAGRAM, value)),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Instagram", Message.Validation.General.INVALID_URL),
                    ifValid: () => _instagram = value);
            }
        }
        #endregion

        /// <summary>
        /// Construtor padrão 
        /// </summary>
        public Logo Logo { get; set; }

        public Studio() { }

        /// <summary>
        /// Construtor com parâmetros. Garanta a construção do objeto no método Create
        /// </summary>
        /// <param name="name"></param>
        /// <param name="establishedDate"></param>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="website"></param>
        /// <param name="logo"></param>
        private Studio(string name, DateTime establishedDate, string country, string city, string website, Logo logo)
        {
            Name = name;
            EstablishedDate = establishedDate;
            Country = country;
            City = city;
            Website = website;
            Logo = logo;
        }

        /// <summary>
        /// Cria uma nova instância de objeto do tipo Studio
        /// </summary>
        /// <param name="name"></param>
        /// <param name="establishedDate"></param>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="website"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        public static Studio Create(string name, DateTime establishedDate, string country, string city, string website, Logo logo) => new Studio(name, establishedDate, country, city, website, logo);
    }
}
