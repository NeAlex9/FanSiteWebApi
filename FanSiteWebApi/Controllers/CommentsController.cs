using AutoMapper;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using FanSiteWebApi.Model.Comment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanSiteWebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMediaService _mediaService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(config => config.AddProfile(new MapperProfile())));

        public CommentsController(ICommentService commentService, IMediaService mediaService, IUserService userService, ITokenService tokenService)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _mediaService = mediaService ?? throw new ArgumentNullException(nameof(mediaService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpGet]
        public IAsyncEnumerable<Comment> GetCommentsByMediaId([FromQuery]int mediaId) =>
            _commentService.GetCommentsByMediaIdAsync(mediaId);

        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment([FromBody] CommentToCreate commentToCreate)
        {
            var jwt = HttpContext.Request.Cookies["jwt"];
            if (!_tokenService.ValidateToken(jwt))
            {
                return Unauthorized();
            }

            ArgumentNullException.ThrowIfNull(nameof(commentToCreate));
            var comment = _mapper.Map<Comment>(commentToCreate);
            var media = await _mediaService.GetMediaById(comment.MediaId);
            if (media is null)
            {
                return NotFound();
            }

            if (media.Id != comment.MediaId)
            {
                return BadRequest();
            }

            var user = await _userService.GetUserByIdAsync(comment.UserId);
            if (user is null)
            {
                return NotFound();
            }

            if (user.Id != comment.UserId)
            {
                return BadRequest();
            }

            comment.PublicationDate = DateTime.Now;
            var (commentId , _, _) = await _commentService.CreateCommentAsync(comment);
            if (commentId == 0)
            {
                return NoContent();
            }

            comment.Id = commentId;
            return new ObjectResult(comment) { StatusCode = StatusCodes.Status201Created };

        }
    }
}
