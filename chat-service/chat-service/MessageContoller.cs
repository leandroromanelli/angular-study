using Microsoft.AspNetCore.Mvc;

namespace chat_service
{
    [Route("message")]
    [ApiController]
    public class MessageContoller : ControllerBase
    {
        private readonly ChatContext _chatContext;

        public MessageContoller(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            var messages = _chatContext.Messages.ToList();
            return Ok(messages);
        }
    }
}
