using ChatService.Entities;

namespace ChatService.Dtos
{
    public class UserCreationDto
    {
        public string Name { get; set; }

        internal User ToEntity()
        {
            return new User(Name);
        }
    }
}
