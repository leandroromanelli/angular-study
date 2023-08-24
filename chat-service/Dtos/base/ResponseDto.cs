using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public abstract class ResponseDto
    {
        public ResponseDto()
        {
        }

        public ResponseDto(Guid referenceId)
        {
            ReferenceId = referenceId;
        }

        [JsonProperty("referenceId")]
        public Guid ReferenceId { get; set; }
    }
}
