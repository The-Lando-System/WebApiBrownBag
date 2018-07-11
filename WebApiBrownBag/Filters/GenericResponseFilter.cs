using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiBrownBag.Filters
{
	public class GenericResponseFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
				HttpStatusCode.OK,
				new GenericResponse
				{
					Message = "Operation successful",
					StatusCode = HttpStatusCode.OK.ToString(),
					RequestUri = actionExecutedContext.Request.RequestUri.ToString(),
					RequestMethod = actionExecutedContext.Request.Method.ToString()
				}
			);
		}
	}

	public class GenericResponse
	{
		public string Message;
		public string StatusCode;
		public string RequestUri;
		public string RequestMethod;
	}
}