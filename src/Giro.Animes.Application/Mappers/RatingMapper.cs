﻿using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    public static class RatingMapper
    {
        public static RatingDTO Map(this Rating rating)
        {
            RatingDTO ratingDTO = RatingDTO.Create(
                rating.Rate,
                rating.UserId,
                rating.Id,
                rating.CreationDate,
                rating.UpdateDate,
                rating.DeletionDate,
                rating.AnimeId);
            return ratingDTO;
        }

        public static IEnumerable<RatingDTO> Map(this IEnumerable<Rating> ratings)
        {
            IEnumerable<RatingDTO> result = ratings?.Select(Map);
            return result;
        }
    }
}
