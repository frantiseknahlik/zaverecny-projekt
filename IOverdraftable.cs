namespace BankApp;

public interface IOverdraftable
{
    decimal OverdraftLimit { get; }
}