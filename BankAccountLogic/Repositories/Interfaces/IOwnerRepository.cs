namespace BankAccountLogic.Repositories.Interfaces
{
    interface IOwnerRepository : IRepository <Owner>
    {
        Owner GetByPassportNumber(string passportNUmber);
    }
}
