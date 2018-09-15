using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
