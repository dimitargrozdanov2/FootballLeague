using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Models
{
    public interface IEntity
    {
        [Key]
        Guid Id { get; set; }
    }
}
