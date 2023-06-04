namespace MyWebServer.Http
{
    public class HttpContentType
    {
        public const string PlainText = "text/plain; charset=UTF-8";
        public const string Html = "text/html; charset=UTF-8";
        public const string FormUrlEncoded = "application/x-www-form-urlencoded";

        public static string GetByFileExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case "css":
                    return "text/css";
                case "js":
                    return "application/javascript";
                case "jpg":
                case "jpeg":
                    return "image/jpeg";
                case "png":
                    return "image/png";
                default:
                    return PlainText;
            }
        }
    }
}
