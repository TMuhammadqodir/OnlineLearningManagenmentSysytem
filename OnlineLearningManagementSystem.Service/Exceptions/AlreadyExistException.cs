namespace OnlineLearningManagementSystem.Service.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string message) : base(message) 
    { }

    public AlreadyExistException(string message, Exception exception) : base(message, exception) 
    { }
}
