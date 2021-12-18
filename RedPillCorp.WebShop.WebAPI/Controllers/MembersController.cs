using Microsoft.AspNetCore.Mvc;
using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedPillCorp.WebShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMemberService _service;


        public MembersController(IMemberService service)
        {
            _service = service;
        }

        // GET: api/<MemberController>
        [HttpGet]
        public ActionResult<List<Member>> Get()
        {
            return _service.ReadAll();
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            Member member = _service.ReadMemberById(id);
            return member.Name;
        }

        // POST api/<MemberController>
        [HttpPost]
        public void Post(Member member)
        {
            _service.CreateMember(member);
        }

        // PUT api/<MemberController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteMember(id);
        }
    }
}
