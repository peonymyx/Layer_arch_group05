using Backend.CoreLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class TagController
    {
        [ApiController]
        [Route("api/tags")]
        public class TagController : ControllerBase
        {
            private readonly TagService _tagService;

            public TagController(TagService tagService)
            {
                _tagService = tagService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
            {
                var tags = await _tagService.GetAllTagsAsync();
                return Ok(tags);
            }

            [HttpPost]
            public async Task<IActionResult> CreateTag(Tag tag)
            {
                await _tagService.AddTagAsync(tag);
                return CreatedAtAction(nameof(GetAllTags), tag);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTag(int id)
            {
                await _tagService.DeleteTagAsync(id);
                return NoContent();
            }
        }
    }
}
