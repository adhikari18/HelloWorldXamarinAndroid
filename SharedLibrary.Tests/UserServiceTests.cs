using System;
using Xunit;

namespace SharedLibrary.Tests
{
    public class UserServiceTests
    {
        [Theory]
        [InlineData("1", false)]
        [InlineData("A", false)]
        [InlineData("12345", false)]
        [InlineData("ABCDE", false)]
        [InlineData("ABAB1", false)]
        [InlineData("AA123", false)]
        [InlineData("ABCD1#", false)]
        [InlineData("12341234", false)]
        [InlineData("ABCDE1ABCDE1", false)]
        [InlineData("123456789012A", false)]
        [InlineData("ABCDEFGHIJ123", false)]

        [InlineData("ABCD1", true)]
        [InlineData("1234567890AB", true)]
        [InlineData("ABXYZAB1", true)]
        [InlineData("abABc12", true)]


        public void TestValidatePassword(string password, bool expected)
        {
            var userService = new UserService();
            var result = userService.ValidatePassword(password);
            Assert.Equal(expected, result);

        }
    }
}
