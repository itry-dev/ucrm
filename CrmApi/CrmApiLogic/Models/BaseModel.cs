using System;
using System.ComponentModel.DataAnnotations;

namespace CrmApiLogic.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public bool Deleted { get; set; }

    }
}
