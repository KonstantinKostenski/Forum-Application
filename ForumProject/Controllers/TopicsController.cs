using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Topics.Commands.CreateTopic;
using CleanArchitecture.Application.Topics.Commands.DeleteTopic;
using CleanArchitecture.Application.Topics.Commands.UpdateTopic;
using CleanArchitecture.Application.Topics.Queries.GetTopicsWithPagination;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class TopicsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TopicBriefDto>>> GetTopics([FromQuery] GetTopicsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("GetTopicById")]
        public async Task<ActionResult<Topic>> GetTopicById([FromQuery] GetTopicByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTopicCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]UpdateTopicCommand command)
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
            await Mediator.Send(new DeleteTopicCommand(id));

            return NoContent();
        }
    }
}
