using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Models;

[Table("PublicMessages")]
public class PublicMessage : Message {
    public ICollection<Channel> Channels { get; set; } = new List<Channel>();

}