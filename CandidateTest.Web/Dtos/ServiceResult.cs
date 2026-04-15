namespace CandidateTest.Web.Dtos;

public class ServiceResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    public static ServiceResult SuccessResult()
        => new() { Success = true };

    public static ServiceResult Failure(string errorMessage)
        => new() { Success = false, ErrorMessage = errorMessage };
}