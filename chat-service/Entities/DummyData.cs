using Newtonsoft.Json;

namespace ChatService.Entities;

public class DummyData : EntityBase
{
    public DummyData() : base()
    {

    }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("emailId")]
    public string EmailId { get; set; }
    
    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }
    
    [JsonProperty("updatedDateTime")]
    public DateTime UpdatedDateTime { get; set; }
}
