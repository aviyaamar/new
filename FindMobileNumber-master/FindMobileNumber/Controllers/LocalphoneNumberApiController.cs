using BLL;
using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FindMobileNumber.Controllers
{
    public class LocalphoneNumberApiController : ApiController
    {

        HttpResponseMessage _response = new HttpResponseMessage();
        APIResponse _apiResponse = new APIResponse();
        PhoneNumberManager _phoneNumberManager;
        UserManager _userManager;

        public LocalphoneNumberApiController()
        {
            _phoneNumberManager = new PhoneNumberManager();
            _userManager = new UserManager();
        }

        [HttpGet]
        [Route("api/LocalphoneNumberApi/GetAllPhoneNumber")]
        public HttpResponseMessage GetAllPhoneNumber()
        {
            ModelState.Clear();
            //List<PhoneNumber> listPhoneNumber = _phoneNumberManager.GetAllPhoneNymber();
            List<User> listUser = _userManager.GetAllUser();

            if (listUser.Count > 0)
            {

                _apiResponse.Status = true;
                _apiResponse.Message = "Data Found";

                for (int i = 0; i < listUser.Count; i++)
                {
                    listUser[i].PhoneNumber.Users = null;
                    _apiResponse.Data = listUser;
                }
            }
            else
            {
                _apiResponse.Status = true;
                _apiResponse.Message = "Data Found";
                _apiResponse.Data = "";
            }
            _response = Request.CreateResponse(HttpStatusCode.OK, _apiResponse);

            return _response;
        }

        [HttpPost]
        [Route("api/LocalphoneNumberApi/CreatePhoneNumber")]
        public HttpResponseMessage CreatePhoneNumber(User user)
        {
            //user.PhoneNumber.Users = null;
            //if (user.PhoneNumber.Users == null)
            //{
            if (_userManager.Insert(user))
            {
                _apiResponse.Status = true;
                _apiResponse.Message = "Data Insert Successfull";
            }
            else
            {
                _apiResponse.Status = false;
                _apiResponse.Message = "Data Insert Failed.";
            }

            _response = Request.CreateResponse(HttpStatusCode.OK, _apiResponse);

            return _response;
        }
        [HttpGet]
        [Route("api/LocalphoneNumberApi/DeletePhoneNumber")]
        public HttpResponseMessage DeletePhoneNumber([FromUri]int id)
        {
            ModelState.Clear();

            if (id > 0)
            {
                _apiResponse.Status = true;
                _apiResponse.Message = "Data Delete Successfully";
                _userManager.Delete(id);
            }
            else
            {
                _apiResponse.Status = false;
                _apiResponse.Message = "Data Delete Failed.";
            }

            // Write the list to the response body.
            _response = Request.CreateResponse(HttpStatusCode.OK, _apiResponse);

            return _response;
        }
    }
}
