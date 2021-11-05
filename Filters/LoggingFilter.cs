using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class LoggingFilter : IActionFilter
    {
    private ContextId _contextId;

    public LoggingFilter(ContextId contextId)
        {
            _contextId = contextId;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // do something before the action executes
            Console.WriteLine($"Before Action {_contextId.Id.ToString()}");            
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // do something after the action executes
           Console.WriteLine($"After Action {_contextId.Id.ToString()}");
        }
    }