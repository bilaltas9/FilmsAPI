namespace Films.Business.Abstract
{
    public interface IRabbitMqService
    {
        void SendMessageToQueue(string queMessage);
        void DeclareQue();
    }
}
