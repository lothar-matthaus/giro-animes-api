using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public class Studio : EntityBase
    {
        #region Name
        private string _name = string.Empty;

        /// <summary>
        /// Studio name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => Notification.Create(GetType().Name, "Name", string.Format(Message.Validation.General.REQUIRED, "Name")),
                    ifValid: () => _name = value);

                Validate(
                    isInvalidIf: !Regex.IsMatch(value, Patterns.Studio.NAME),
                    ifInvalid: () => Notification.Create(GetType().Name, "Name", Message.Validation.Studio.INVALID_NAME),
                    ifValid: () => _name = value);

                Validate(
                   isInvalidIf: !Regex.IsMatch(value, Patterns.Studio.NAME_LENGHT),
                   ifInvalid: () => Notification.Create(GetType().Name, "Name", Message.Validation.Studio.INVALID_NAME_LENGHT),
                   ifValid: () => _name = value);
            }
        }
        #endregion

        /// <summary>
        /// Studio's established date
        /// </summary>
        public DateTime EstablishedDate { get; set; }

        /// <summary>
        /// Country where the studio is located
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// City where the studio is located
        /// </summary>
        public string City { get; set; }

        #region WebSite
        private string _website = string.Empty;

        /// <summary>
        /// Studio's website
        /// </summary>
        public string Website
        {
            get { return _website; }
            set
            {
                Validate(
                    isInvalidIf: !string.IsNullOrEmpty(value) && !Regex.IsMatch(value, Patterns.General.URL),
                    ifInvalid: () => Notification.Create(GetType().Name, "Website", Message.Validation.General.INVALID_URL),
                    ifValid: () => _website = value);
            }
        }
        #endregion

        /// <summary>
        /// Studio's Twitter
        /// </summary>
        #region Twitter
        private string _twitter;

        public string Twitter
        {
            get { return _twitter; }
            set
            {
                Validate(
                    isInvalidIf: !string.IsNullOrEmpty(value) && !Regex.IsMatch(value, Patterns.General.URL_TWITTER),
                    ifInvalid: () => Notification.Create(GetType().Name, "Twitter", Message.Validation.General.INVALID_URL),
                    ifValid: () => _twitter = value);
            }
        }
        #endregion

        /// <summary>
        /// Studio's Instagram
        /// </summary>
        #region Instagram
        private string _instagram;

        public string Instagram
        {
            get { return _instagram; }
            set
            {
                Validate(
                    isInvalidIf: !string.IsNullOrEmpty(value) && !Regex.IsMatch(value, Patterns.General.URL_INSTAGRAM),
                    ifInvalid: () => Notification.Create(GetType().Name, "Instagram", Message.Validation.General.INVALID_URL),
                    ifValid: () => _instagram = value);
            }
        }
        #endregion

        /// <summary>
        /// Studio's logo
        /// </summary>
        public Logo Logo { get; set; }

        #region Navigation
        /// <summary>
        /// Animes a qual um estúdio animou
        /// </summary>
        public ICollection<Anime> Animes { get; private set; }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Studio() { }

        /// <summary>
        /// Constructor with parameters. Ensure object construction in the Create method
        /// </summary>
        /// <param name="name">Studio name</param>
        /// <param name="establishedDate">Established date</param>
        /// <param name="country">Country</param>
        /// <param name="city">City</param>
        /// <param name="website">Studio's website</param>
        /// <param name="logo">Studio's logo</param>
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
        /// Creates a new instance of Studio object
        /// </summary>
        /// <param name="name">Studio name</param>
        /// <param name="establishedDate">Established date</param>
        /// <param name="country">Country</param>
        /// <param name="city">City</param>
        /// <param name="website">Studio's website</param>
        /// <param name="logo">Studio's logo</param>
        /// <returns>New instance of Studio</returns>
        public static Studio Create(string name, DateTime establishedDate, string country, string city, string website, Logo logo) => new Studio(name, establishedDate, country, city, website, logo);
    }
}
