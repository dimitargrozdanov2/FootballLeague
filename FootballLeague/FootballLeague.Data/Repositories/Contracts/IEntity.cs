using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FootballLeague.Data.Repositories.Contracts
{
    public interface IEntity
    {
    }

    public interface IEntity<TPrimaryKey> : IEntity
    {

        [Key]
        [JsonIgnore]
        TPrimaryKey Id { get; set; }
    }
}
