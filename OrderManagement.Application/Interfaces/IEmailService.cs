
namespace OrderManagement.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendOrderAcceptedConfirmationEmailAsync();
    }
}
