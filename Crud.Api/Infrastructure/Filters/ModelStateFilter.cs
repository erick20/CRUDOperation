using Crud.Common.Helpers;
using Crud.Models.GlobalModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Infrastructure.Filters
{   
    public class ModelStateFilter : IAsyncActionFilter
    {
        public ModelStateFilter()
        {
        }
        private List<ValidationMessageModel> _messages;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) // add ovveride
        {            
            if (!context.ModelState.IsValid)
            {
                _messages = new List<ValidationMessageModel>();
                foreach (String key in context.ModelState.Keys)
                {
                    foreach (ModelError error in context.ModelState[key].Errors)
                    {
                        ValidationMessageModel validationMessage = new ValidationMessageModel
                        {
                            Code = error.ErrorMessage,
                            Key = key.StartsWith("model.") ? key.Replace("model.", String.Empty) : key,
                            Message = error.ErrorMessage,
                        };
                        _messages.Add(validationMessage);
                    }
                }

                ProblemReporter.ReportBadRequest(JsonConvert.SerializeObject(_messages));
            }
            else
            {
                await next();
            }

        }
    }
}
