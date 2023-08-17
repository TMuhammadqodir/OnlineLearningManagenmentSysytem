namespace OnlineLearningManagementSystem.Service.Exceptions;

partial class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) 
    { }

    public NotFoundException(string massage, Exception exception): base(massage, exception)
    { }
}
