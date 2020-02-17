using System.Linq;
using System.Net;
using System.Web.Mvc;
using TodoList.UI.Models;

namespace TodoList.UI.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                var field = filterContext.Controller.ViewData.ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new FieldModel
                {
                    Field = x.Key,
                    Message = x.Value.Errors.Select(y => y.ErrorMessage).ToArray()
                });

                var result = new Result()
                {
                    Error = new ErrorModel()
                    {
                        Fields = field
                    }
                };
                filterContext.Result = new JsonResult { Data = result };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}