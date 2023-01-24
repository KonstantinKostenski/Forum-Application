using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Replies.Commands.CreateReply;
using CleanArchitecture.Application.Replies.Commands.DeleteReply;
using CleanArchitecture.Application.Replies.Commands.UpdateReply;
using CleanArchitecture.Application.Sections.Commands.CreateSection;
using CleanArchitecture.Application.Sections.Commands.DeleteSection;
using CleanArchitecture.Application.Sections.Commands.UpdateSection;
using CleanArchitecture.Application.Sections.Queries.GetSectionsWithPagination;
using CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class SectionsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SectionBriefDto>>> GetSections([FromQuery] GetSections query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSectionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSectionCommand command)
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
            await Mediator.Send(new DeleteSectionCommand(id));

            return NoContent();
        }
    }
}
