using Microsoft.AspNetCore.Mvc.Filters;

namespace Dz_20._01.Infrastucture
{
    public class UniqueUsersCountFilterAttribute : Attribute, IActionFilter
    {
        private static readonly Dictionary<string, bool> UniqueUsers = new Dictionary<string, bool>();
        private const string path = "usersCount.txt";
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            if (!request.Cookies.TryGetValue("UserId", out var userId))
            {
                userId = Guid.NewGuid().ToString();
                response.Cookies.Append("UserId", userId, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            }

            if (UniqueUsers.TryAdd(userId, true))
                UpdateUsersCountFile();
        }

        private void UpdateUsersCountFile()
        {
            File.WriteAllText(path, UniqueUsers.Count.ToString());
        }

        public static int GetUniqueUserCount()
        {
            return UniqueUsers.Count;
        }
    }
}
