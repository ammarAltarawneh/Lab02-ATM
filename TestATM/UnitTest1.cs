namespace TestATM
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ViewBalance()
        {
            Lab02_ATM.Program.Balance = 1000;
            decimal balance = Lab02_ATM.Program.ViewBalance();
            Assert.Equal(1000, balance);
        }

        [Fact]
        public void Test_WithdrawValidAmount()
        {
            Lab02_ATM.Program.Balance = 1000;
            decimal newBalance = Lab02_ATM.Program.Withdraw(400);
            Assert.Equal(600, newBalance);
        }

        [Fact]
        public void Test_WithdrawMoreThanBalance()
        {
            Lab02_ATM.Program.Balance = 1000;
            decimal newBalance = Lab02_ATM.Program.Withdraw(1500);
            Assert.Equal(1000, newBalance);
        }

        [Fact]
        public void Test_WithdrawInvalidAmount()
        {
            Lab02_ATM.Program.Balance = 1000;
            decimal newBalance = Lab02_ATM.Program.Withdraw(-500);
            Assert.Equal(1000, newBalance);
        }

        [Fact]
        public void Test_DepositValidAmount()
        {
            Lab02_ATM.Program.Balance = 1000;
            decimal newBalance = Lab02_ATM.Program.Deposit(400);
            Assert.Equal(1400, newBalance);
        }

        [Fact]
        public void Test_DepositInvalidAmount()
        {
            Lab02_ATM.Program.Balance = 1000;
            decimal newBalance = Lab02_ATM.Program.Deposit(-500);
            Assert.Equal(1000, newBalance);
        }
    }
}