
namespace HospitalManagement.API.Helpers
{
    public static class JwtExtension
    {

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Allow-Origin", "*"); // CORS 
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");

        }   
    }
}
