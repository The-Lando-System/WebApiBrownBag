﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiBrownBag.Filters
{
	public class LoggingFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			Debug.WriteLine($"Request Submitted: {actionContext.Request.RequestUri}");
		}

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			Debug.WriteLine($"Status of request [{actionExecutedContext.Request.RequestUri}]: {actionExecutedContext.Response.StatusCode}");
		}

	}
}