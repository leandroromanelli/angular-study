using Newtonsoft.Json;

namespace ChatService.Models;

public partial class DummyData
{
    [JsonIgnore]
    internal int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime UpdatedDateTime { get; set; }
}
