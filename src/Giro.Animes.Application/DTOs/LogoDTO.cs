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
    /// Data Transfer Object for Logo entity.
    /// </summary>
    public class LogoDTO : MediaDTO<Logo>
    {
        /// <summary>
        /// Identifier of the studio to which the logo belongs.
        /// </summary>
        public long StudioId { get; private set; }

        /// <summary>
        /// Constructor to initialize LogoDTO with a Logo entity.
        /// </summary>
        /// <param name="logo">Logo entity.</param>
        private LogoDTO(Logo logo) : base(logo)
        {
            StudioId = logo.StudioId;
        }

        /// <summary>
        /// Creates a new instance of LogoDTO.
        /// </summary>
        /// <param name="url">URL of the logo.</param>
        /// <param name="fileName">File name of the logo.</param>
        /// <param name="extension">File extension of the logo.</param>
        /// <param name="studioId">Identifier of the studio to which the logo belongs.</param>
        /// <returns>New instance of LogoDTO.</returns>
        public static LogoDTO Create(Logo logo)
        {
            return new LogoDTO(logo);
        }
    }
}
