using FluentValidation;
using GerenciadorTurmas.Api.Common.CustomValidation;

namespace GerenciadorTurmas.Api.Common
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var validators = context.RequestServices.GetServices<IValidator>();

            foreach (var validator in validators)
            {
                var type = validator.GetType();

                var entityType = type.BaseType?.GetGenericArguments()[0];

                if (entityType != null)
                {
                    var request = await context.Request.ReadFromJsonAsync(entityType);

                    if (request != null && entityType.IsAssignableFrom(request.GetType()))
                    {
                        var validationResult = await validator.ValidateAsync(new ValidationContext<object>(request));

                        if (!validationResult.IsValid)
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;

                            await context.Response.WriteAsJsonAsync(validationResult.Errors.ToCustomValidationFailure());

                            return;
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
