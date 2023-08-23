namespace CBSD.Framework.Domain.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
