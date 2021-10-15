using Microsoft.AspNetCore.Mvc;
using MyFinances.Core.Response;
using MyLibraryWebApi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryWebApi.Controllers
{
    public class UserController : Controller
    {

        private readonly UnitOfWork _unitOfWork;
        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public DataResponse<string> Add(User user)
        {
            var response = new DataResponse<string>();

            try
            {
                _unitOfWork.User.Add(user);
                _unitOfWork.Complete();
                response.Data = user.Id;
            }
            catch (Exception e)
            {
                //logowanie do pliku
                response.Errors.Add(new Error(e.Source, e.Message));
            }

            return response;
        }
        [HttpGet("{id}")]
        public DataResponse<User> Get(string id)
        {
            var response = new DataResponse<User>();

            try
            {
                response.Data = _unitOfWork.User.Get(id);
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
