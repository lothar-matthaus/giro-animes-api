using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Base
{
    public abstract class BaseDTO<TBase> where TBase : EntityBase
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public DateTime? DeletionDate { get; private set; }

        protected BaseDTO(TBase entityBase)
        {
            Id = entityBase.Id ?? 0;
            CreationDate = entityBase.CreationDate;
            UpdateDate = entityBase.UpdateDate;
            DeletionDate = entityBase.DeletionDate;
        }
    }
}
