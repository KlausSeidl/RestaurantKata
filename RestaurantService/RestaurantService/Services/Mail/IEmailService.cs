namespace RestaurantService.Services.Mail
{
    public interface IEmailService
    {
        void Send(Message message);
    }
}