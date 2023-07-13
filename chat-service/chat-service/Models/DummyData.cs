using Newtonsoft.Json;

namespace ChatService.Models;

public class DummyData : BaseModel
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
