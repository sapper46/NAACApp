namespace PortalApi.Services
{
    public abstract class BaseService
    {
        protected void ValidateNotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        protected void ValidateStringNotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName);
        }

        protected void HandleException(Exception ex, string operation)
        {
            // Log exception here in production
            throw new InvalidOperationException($"Error in {operation}: {ex.Message}", ex);
        }
    }
}