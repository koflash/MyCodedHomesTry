﻿using Elmah;
using System.Web.Mvc;

namespace WebApplication2.2Filters
{
    public class ElmahFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log only handled exceptions, because all other will be caught by ELMAH anyway.
            if (context.ExceptionHandled)
            {
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
            }
        }
    }
}