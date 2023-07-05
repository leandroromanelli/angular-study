using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace chat_service.Models;

public partial class DummyData
{
    [JsonIgnore]
    internal int Id { get; set; }

    public string Name { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime UpdatedDateTime { get; set; }
}
