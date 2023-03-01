using AutoMapper;
using BooksLibrary.Application.Command.Books.Commands.Delete;
using BooksLibrary.Application.Command.Books.Commands.RateBook;
using BooksLibrary.Application.Command.Books.Commands.SaveBook;
using BooksLibrary.Application.Command.Books.Commands.SaveReview;
using BooksLibrary.Application.Queries.GetAllBooks;
using BooksLibrary.Application.Queries.GetBookDetails;
using BooksLibrary.Application.Queries.GetTop10;
using BooksLibrary.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BooksLibrary.WebApi.Controllers
{


    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper) => _mapper = mapper;


        [HttpGet("")]

        public async Task<ActionResult<AllBooksVm>> GetAll(string order)
        {

            var query = new GetAllBooksQuery
            {
                Order = order
            };


            var vm = await Mediator.Send(query);
            return Ok(vm);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDetailsQueryVm>> GetBookDetails(uint id)
        {

            var query = new GetBookDetailsQuery
            {
                BookId = id
            };


            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("recommended")]
        public async Task<ActionResult<GetTop10Vm>> GetTop10(string genre)
        {

            var query = new GetTop10Query
            {
                Order = genre
            };


            var vm = await Mediator.Send(query);
            return Ok(vm);
        }



        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<SaveBookCommand>(createBookDto);
            uint v = await Mediator.Send(command);
            return Ok(v);
        }


        [HttpPost("{id}/review")]
        public async Task<ActionResult> SaveReview(uint id, [FromBody] SaveReviewerDto review)
        {

            var saveReviewerDto = new SaveReviewerDto()
            {
                BookId = id,
                Message = review.Message,
                Reviewer = review.Reviewer,

            };


            var command = _mapper.Map<SaveReviewerCommand>(saveReviewerDto);
            int v = await Mediator.Send(command);
            return Ok(v);
        }




        [HttpPost("{id}/rate")]
        public async Task<ActionResult> RateBook(uint id, [FromBody] RateBookDto rate)
        {

            var rateBookDto = new RateBookDto()
            {
                BookId = id,
                Score = rate.Score,
            };


            var command = _mapper.Map<RateBookCommand>(rateBookDto);
            uint v = await Mediator.Send(command);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(uint id, [FromQuery] string secret)
        {

            var DeleteBookCommand = new DeleteBookCommand()
            {
                Key = secret,
                Id = id,
            };


            var command = _mapper.Map<DeleteBookCommand>(DeleteBookCommand);
            await Mediator.Send(command);
    
            return NoContent();

        }
    }
}
