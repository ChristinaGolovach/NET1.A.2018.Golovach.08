namespace BankAccountLogic.NumberGenerator
{
    interface INumberGenerator<out T>
    {
        T GenerateNumber(int numberLength);
    }
}
