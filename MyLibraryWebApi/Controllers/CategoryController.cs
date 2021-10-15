using Microsoft.AspNetCore.Mvc;
using MyFinances.Core.Response;
using MyLibraryWebApi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public DataResponse<IEnumerable<Category>> Get()
        {
            var response = new DataResponse<IEnumerable<Category>>();

            try
            {
                response.Data = _unitOfWork.Category.Get();
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(Category category)
        {
            var response = new DataResponse<int>();

            try
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Complete();
                response.Data = category.Id;
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
                _unitOfWork.Category.Delete(id);
                _unitOfWork.Complete();
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
