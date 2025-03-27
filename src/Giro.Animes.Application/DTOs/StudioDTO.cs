using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Studio entity.
    /// </summary>
    public class StudioDTO : BaseDTO<Studio>
    {
        /// <summary>
        /// Studio name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Studio's established date.
        /// </summary>
        public DateTime EstablishedDate { get; private set; }
        /// <summary>
        /// Country where the studio is located.
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// City where the studio is located.
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// Studio's website.
        /// </summary>
        public string Website { get; private set; }
        /// <summary>
        /// Studio's Twitter handle.
        /// </summary>
        public string Twitter { get; private set; }
        /// <summary>
        /// Studio's Instagram handle.
        /// </summary>
        public string Instagram { get; private set; }
        /// <summary>
        /// Studio's logo.
        /// </summary>
        public LogoDTO Logo { get; private set; }

        /// <summary>
        /// Private constructor to initialize StudioDTO with a Studio entity.
        /// </summary>
        /// <param name="studio">Studio entity.</param>
        private StudioDTO(Studio studio) : base(studio)
        {
            Name = studio.Name;
            EstablishedDate = studio.EstablishedDate;
            Country = studio.Country;
            City = studio.City;
            Website = studio.Website;
            Twitter = studio.Twitter;
            Instagram = studio.Instagram;
            Logo = LogoDTO.Create(studio.Logo);
        }

        /// <summary>
        /// Creates a new instance of StudioDTO.
        /// </summary>
        /// <param name="studio">Studio entity.</param>
        /// <returns>New instance of StudioDTO.</returns>
        public static StudioDTO Create(Studio studio)
        {
            return new StudioDTO(studio);
        }
    }
}
