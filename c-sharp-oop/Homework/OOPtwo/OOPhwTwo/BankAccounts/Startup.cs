using System;
using BankAccounts.AccountTypes;

namespace BankAccounts
{
    public class Startup
    {
        static void Main()
        {
            var indvCustomer = new Individual("Gosho Doshev");
            var compCustomer = new Company("Gosho Enterprises");

            Console.WriteLine("DEPOSIT TESTS");
            var myDeposit = new Deposit(indvCustomer, 3000, 4.3);
            Console.WriteLine($"The deposit rate for 6 months and 3000 Balance is: {myDeposit.CalculateInterestRate(6)}");
            myDeposit.WithdrawFunds(2500);
            Console.WriteLine($"The deposit rate for 6 months and 500 Balance is: {myDeposit.CalculateInterestRate(6)}");
            Console.WriteLine($"My funds now: {myDeposit.Balance}");
            Console.WriteLine("Deposit 1500");
            myDeposit.DepositFunds(1500);
            Console.WriteLine($"My funds now: {myDeposit.Balance}");
            Console.WriteLine("Withdraw 500");
            myDeposit.WithdrawFunds(500);
            Console.WriteLine($"My funds now: {myDeposit.Balance}");


            Console.WriteLine("\nLOAN TESTS");
            var compLoan = new Loan(compCustomer, 831678, 3.1);
            Console.WriteLine($"Company Load: Loan rate for 1 month -> {compLoan.CalculateInterestRate(1)}, and for 6 months -> {compLoan.CalculateInterestRate(6)}");
            var idvLoan = new Loan(indvCustomer, 1311, 2.1);
            Console.WriteLine($"Individual Load: Loan rate for 2 months -> {idvLoan.CalculateInterestRate(2)}, and for 6 months -> {idvLoan.CalculateInterestRate(6)}");



            Console.WriteLine("\nMORTGAGE TESTS");
            var compMortgage = new Mortgage(compCustomer, 21871, 1.2);
            var idvMortgage = new Mortgage(indvCustomer, 1232, 4.1);
            Console.WriteLine($"Company Mortgage: Mortgage rate for 11 months -> {compMortgage.CalculateInterestRate(11)}, and for 18 months -> {compMortgage.CalculateInterestRate(18)}");
            Console.WriteLine($"Individual Mortgage: Mortgage rate for 4 months -> {idvMortgage.CalculateInterestRate(2)}, and for 12 months -> {idvMortgage.CalculateInterestRate(6)}");


        }
    }
}
