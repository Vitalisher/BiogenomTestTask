namespace BiogenomNutrition.Application.DTOs;

public class ContentTemplateResponse
{
    public string Content { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;

    public ContentTemplateResponse(string? content, bool isSuccess, string? errorMessage = null)
    {
        Content = content ?? string.Empty;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage ?? string.Empty;
    }
}