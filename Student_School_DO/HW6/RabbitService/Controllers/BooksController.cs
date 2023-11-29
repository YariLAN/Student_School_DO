﻿using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Request.Book;
using Models.Responce.Book;
using RabbitClient.Publishers.Books;
using RabbitClient.Publishers.Interfaces;

namespace RabbitClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //POST api/<ReaderController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] ICreateMessagePublisher<CreateBookRequest, CreateBookResponce> msgPublisher,
            [FromBody] BookModel request)
        {
            var resp = msgPublisher.SendCreateMessage(new CreateBookRequest { Book = request });

            if (resp is null)
            {
                return BadRequest();
            }

            return Created("/books", resp);
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IGetAllMessagePublisher<GetAllBookResponce, BookModel> msgPublisher)
        {
            var resp = msgPublisher.SendGetAllMessage(new BookModel());

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Books);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromServices] IDeleteMessagePublisher<DeleteBookRequest, DeleteBookResponce> msgPublisher,
            [FromRoute] Guid id)
        {
            DeleteBookRequest request = new DeleteBookRequest { Id = id };

            var resp = msgPublisher.SendDeleteMessage(request);

            if (resp is null)
            {
                return BadRequest();
            }

            return Created($"/books/{resp.Id}", resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByIdMessagePublisher<Guid, Task<GetByIdBookResponce>> msgPublisher,
            [FromRoute] Guid id)
        {
            var resp = await msgPublisher.SendGetByIdMessage(id);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp.Book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromServices] IUpdateMessagePublisher<Guid, BookModel, UpdateBookResponce> msgPublisher,
            [FromRoute] Guid id,
            [FromBody] BookModel request)
        {
            var resp = msgPublisher.SendUpdateMessage(id, request);

            if (resp is null)
            {
                return BadRequest();
            }

            return StatusCode(200, resp);
        }
    }
}
