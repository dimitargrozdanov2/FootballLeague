using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Models
{
    public interface IEntity
    {
        [Key]
        long Id { get; set; }
    }
}
