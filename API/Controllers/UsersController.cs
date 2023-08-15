using System.Security.Claims;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _repository.GetUsersAsync();

        var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(usersToReturn);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user =  await _repository.GetUserByUsernameAsync(username);

        return _mapper.Map<MemberDto>(user);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto) 
    {
        // get username based on token value
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _repository.GetUserByUsernameAsync(username);

        if(user == null) return NotFound("User not found!!");

        _mapper.Map(memberUpdateDto, user);

        if (await _repository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update user");
    }
}
