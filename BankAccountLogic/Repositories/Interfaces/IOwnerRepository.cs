namespace BankAccountLogic.Repositories.Interfaces
{
    public interface IOwnerRepository : IRepository <Owner>
    {
        Owner GetByPassportNumber(string passportNUmber);
    }
}
