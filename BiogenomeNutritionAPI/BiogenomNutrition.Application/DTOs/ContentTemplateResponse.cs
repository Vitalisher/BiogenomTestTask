namespace BiogenomNutrition.Application.DTOs
{
    public class ContentTemplateResponse
    {
        public string Content { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public ContentTemplateResponse(string content, bool isSuccess, string errorMessage = null)
        {
            Content = content;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}