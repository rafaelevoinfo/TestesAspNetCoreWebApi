using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class LoggingFilter : IActionFilter
{
    private ContextId _contextId;

    public LoggingFilter(ContextId contextId)
    {
        _contextId = contextId;
    }
    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        JsonDocument vaJson = (JsonDocument)filterContext.ActionArguments["ipJson"];
        if (vaJson.RootElement.TryGetProperty("contextId", out JsonElement contextId))
        {
            _contextId.Id = new Guid(contextId.GetString());
        }
        Console.WriteLine($"Before Action {_contextId.Id.ToString()}");


    }

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
        // do something after the action executes
        Console.WriteLine($"After Action {_contextId.Id.ToString()}");
    }
}