﻿using Giro.Animes.Domain.Constants;
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
    public class Author : EntityBase
    {
        /// <summary>
        /// Nome do autor
        /// </summary>
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
                    isInvalidIf: !Regex.IsMatch(Patterns.Author.NAME, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Name", Message.Validation.Author.INVALID_NAME),
                    ifValid: () => _name = value);

                Validate(
                   isInvalidIf: !Regex.IsMatch(Patterns.Author.NAME_LENGHT, value),
                   ifInvalid: () => ValidationError.Create(GetType().Name, "Name", Message.Validation.Author.INVALID_NAME_LENGHT),
                   ifValid: () => _name = value);
            }
        }
        #endregion

        public string Biography { get; private set; }

        /// <summary>
        /// Pseudonimo do autor
        /// </summary>
        #region PenName
        private string _penName = string.Empty;
        public string PenName
        {
            get { return _penName; }
            set
            {
                Validate(
                    isInvalidIf: (!string.IsNullOrEmpty(value) && !Regex.IsMatch(Patterns.Author.PEN_NAME, value)),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "PenName", Message.Validation.Author.INVALID_PEN_NAME),
                    ifValid: () => _penName = value);

                Validate(
                   isInvalidIf: (!string.IsNullOrEmpty(value) && !Regex.IsMatch(Patterns.Author.PEN_NAME_LENGHT, value)),
                   ifInvalid: () => ValidationError.Create(GetType().Name, "PenName", Message.Validation.Author.INVALID_PEN_NAME_LENGHT),
                   ifValid: () => _penName = value);
            }
        }
        #endregion


        public DateTime? BirthDate { get; private set; }

        public DateTime? DeathDate { get; private set; }

        /// <summary>
        /// Website do autor
        /// </summary>
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
        public Author()
        {
        }

        private Author(string name, string biography, string penName, DateTime? birthDate, DateTime? deathDate, string website, string twitter, string instagram) : base(DateTime.Now)
        {
            Name = name;
            Biography = biography;
            PenName = penName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Website = website;
            Twitter = twitter;
            Instagram = instagram;
        }

        /// <summary>
        /// Cria uma nova instância de autor com os dados informados 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="biography"></param>
        /// <param name="penName"></param>
        /// <param name="birthDate"></param>
        /// <param name="deathDate"></param>
        /// <param name="website"></param>
        /// <param name="twitter"></param>
        /// <param name="instagram"></param>
        /// <returns></returns>
        public static Author Create(string name, string biography, string penName, DateTime? birthDate, DateTime? deathDate, string website, string twitter, string instagram)
            => new Author(name, biography, penName, birthDate, deathDate, website, twitter, instagram);
    }
}
