namespace RES.Services.Interface
{
    public interface ITransation
    {
         void commit();
         void rollback();
         void Dispose();
    }
}
