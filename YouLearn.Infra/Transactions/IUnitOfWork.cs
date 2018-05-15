namespace YouLearn.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
