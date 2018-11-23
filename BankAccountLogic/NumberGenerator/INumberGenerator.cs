namespace BankAccountLogic.NumberGenerator
{
    public interface INumberGenerator<out T>
    {
        T GenerateNumber(int numberLength = 10);
    }
}
