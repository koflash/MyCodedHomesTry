﻿using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class ErrorInputModel
    {
        public string ErrorText { get; set; }
        public string Url { get; set; }
        public int? LineNumber { get; set; }

        public override string ToString()
        {
            return string.Format("ErrorText: {0}, Url: {1}, Line Number: {2}",
                this.ErrorText,
                this.Url,
                (this.LineNumber.HasValue ?
                this.LineNumber.Value.ToString() : "Unknown"));
        }
    }

    public class ClientErrorException : Exception
    {
        public ClientErrorException(string message) : base(message) { }
    }
      
    public class ErrorController: ApiController
    {
        public HttpResponseMessage Post(ErrorInputModel errorMessage)
        {
            ClientErrorException ex =
                new ClientErrorException(errorMessage.ToString());

            ErrorSignal signal = ErrorSignal.FromCurrentContext();
            signal.Raise(ex);

            return Request.CreateResponse(
                HttpStatusCode.OK, "{success:true}");
        }
    }
}
