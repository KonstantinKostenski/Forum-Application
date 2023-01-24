using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Replies.Commands.CreateReply;
using CleanArchitecture.Application.Replies.Commands.DeleteReply;
using CleanArchitecture.Application.Replies.Commands.UpdateReply;
using CleanArchitecture.Application.Replies.Queries.GetRepliesWithPagination;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class RepliesController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetRepliesByTopic")]
        public async Task<ActionResult<PaginatedList<ReplyBiefDto>>> GetRepliesByTopic([FromQuery] GetRepliesByTopicWithPaginationQuery command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateReplyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateReplyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteReplyCommand(id));

            return NoContent();
        }
    }
}
