namespace SharedLibrary.Services
{
    public interface IUserDataValidationService
    {
        bool ValidatePassword(string password);
    }
}
