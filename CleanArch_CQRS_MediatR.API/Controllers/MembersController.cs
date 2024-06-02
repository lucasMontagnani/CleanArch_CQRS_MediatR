using CleanArch_CQRS_MediatR.Application.Members.Commands;
using CleanArch_CQRS_MediatR.Application.Members.Queries;
using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Domain.Entities;
using CleanArch_CQRS_MediatR.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArch_CQRS_MediatR.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;

        //public MembersController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _unitOfWork.MemberRepository.GetMembers();
            return Ok(members);
        }
        */
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var query = new GetMembersQuery();
                var members = await _mediator.Send(query);
                return Ok(members);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _unitOfWork.MemberRepository.GetMemberById(id);
            return member != null ? Ok(member) : NotFound("Member not found.");
        }
        */

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var query = new GetMembersByIdQuery { Id = id};
            var member = await _mediator.Send(query);
            return member != null ? Ok(member) : NotFound("Member not found.");
        }

        /*
        [HttpPost]
        public async Task<IActionResult> CreateMember(Member member)
        {
            if (member == null)
            {
                return BadRequest("Invalid member data.");
            }

            var createMember = await _unitOfWork.MemberRepository.AddMember(member);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(GetMember), new { id = createMember.Id }, createMember);
        }
        */

        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberCommand command)
        {
            var createMember = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMember), new { id = createMember.Id }, createMember);
        }

        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> CreateMember(int id, Member updateMember)
        {
            var existingMember = await _unitOfWork.MemberRepository.GetMemberById(id);

            if (existingMember is null)
            {
                return BadRequest("Member not found.");
            }

            existingMember.Update(updateMember.FirstName, updateMember.LastName, updateMember.Gender, updateMember.Email, updateMember.IsActive);
            _unitOfWork.MemberRepository.UpdateMember(existingMember);
            await _unitOfWork.CommitAsync();
            return Ok();
        }
        */

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var updateMember = await _mediator.Send(command);
            return updateMember != null ? Ok(updateMember) : NotFound("Member not found.");
        }

        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var deleteMember = await _unitOfWork.MemberRepository.DeleteMember(id);

            if(deleteMember == null)
            {
                return BadRequest("Member not found.");
            }

            await _unitOfWork.CommitAsync();
            return Ok(deleteMember);
        }
        */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var command = new DeleteMemberCommand { Id = id };
            var deleteMember = await _mediator.Send(command);
            return deleteMember != null ? Ok(deleteMember) : NotFound("Member not found.");
        }
    }
}
