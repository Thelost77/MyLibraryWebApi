using Microsoft.AspNetCore.Mvc;
using MyFinances.Core.Response;
using MyLibraryWebApi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public BookController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public DataResponse<IEnumerable<Book>> Get()
        {
            var response = new DataResponse<IEnumerable<Book>>();

            try
            {
                response.Data = _unitOfWork.Book.Get();
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }

        [HttpGet("{id}")]
        public DataResponse<Book> Get(int id)
        {
            var response = new DataResponse<Book>();

            try
            {
                response.Data = _unitOfWork.Book.Get(id);
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }
        [HttpPost]
        public DataResponse<int> Add(Book book)
        {
            var response = new DataResponse<int>();

            try
            {
                _unitOfWork.Book.Add(book);
                _unitOfWork.Complete();
                response.Data = book.Id;
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }
        [HttpPut]
        public Response Update(Book book)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Book.Update(book);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }
        [HttpDelete]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Book.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }
        [HttpGet("{numberOfRecords}/{pageNumber}")]
        public DataResponse<IEnumerable<Book>> Get(int numberOfRecords, int pageNumber)
        {
            var response = new DataResponse<IEnumerable<Book>>();

            try
            {
                response.Data = _unitOfWork.Book.Get(numberOfRecords, pageNumber);
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }

        [HttpGet("{categoryId}/{Title}/{ifRead}&&{ifOwned}")]
        public DataResponse<IEnumerable<Book>> GetAllBooks(int categoryId = 1, string Title = null, bool ifRead = false, bool ifOwned = false)
        {
            var response = new DataResponse<IEnumerable<Book>>();

            try
            {
                response.Data = _unitOfWork.Book.GetAllBooks(categoryId, Title, ifRead, ifOwned);
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }
    }
}
