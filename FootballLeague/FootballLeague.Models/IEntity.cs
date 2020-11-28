using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Models
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
