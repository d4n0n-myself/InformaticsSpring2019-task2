using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task2.Web.Filters
{
	public class InternalErrorFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			Console.WriteLine(context.Exception);
			context.Result = new ObjectResult(context.Exception.ToString()) {StatusCode = 500};
		}
	}
}