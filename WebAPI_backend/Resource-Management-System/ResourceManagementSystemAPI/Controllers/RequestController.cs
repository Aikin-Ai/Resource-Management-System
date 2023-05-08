﻿using BysinessServices.Interfaces;
using BysinessServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResourceManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/request
        [HttpGet]
        public async Task<IEnumerable<RequestModel>> Get()
        {
            return await _requestService.GetAllAsync();
        }

        //GET: api/request/user/5
        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(RequestModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<RequestModel>> GetRequestByUserId(int id)
        {
            return await _requestService.GetByUserId(id);
        }

        // GET: api/request/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _requestService.GetByIdAsync(id);
            return request == null ? NotFound() : Ok(request);
        }

        // POST: api/request
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(RequestModel request)
        {
            var createdRequest = await _requestService.AddAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = createdRequest.Id }, createdRequest);
        }

        // DELETE: api/request/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var requestToDelete = await _requestService.GetByIdAsync(id);
            if (requestToDelete == null) return NotFound();

            await _requestService.DeleteAsync(id);

            return NoContent();
        }

        // DELETE: api/request/deny/5
        [HttpDelete("deny/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deny(int id)
        {
            var requestToDelete = await _requestService.GetByIdAsync(id);
            if (requestToDelete == null) return NotFound();

            await _requestService.DeleteAsync(id);

            return NoContent();
        }

        // POST: api/request/confirm/5
        [HttpPut("confirm/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Confirm(int id)
        {
            var request = await _requestService.GetByIdAsync(id);
            if (request == null) return NotFound();

            await _requestService.ConfirmRequest(request);

            return NoContent();
        }
    }
}
