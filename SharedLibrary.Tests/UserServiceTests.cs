using SharedLibrary.Services;
using System;
using Xunit;

namespace SharedLibrary.Tests
{
    public class UserServiceTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("       ", false)]
        [InlineData(null, false)]
        [InlineData("1", false)]
        [InlineData("A", false)]
        [InlineData("12345", false)]
        [InlineData("ABCDE", false)]
        [InlineData("ABAB1", false)]
        [InlineData("ABCD1#", false)]
        [InlineData("12341234", false)]
        [InlineData("ABAB1234", false)]
        [InlineData("ABCDE1ABCDE1", false)]
        [InlineData("123456789012A", false)]
        [InlineData("ABCDEFGHIJ123", false)]
        [InlineData("ba90JhGj11C96VdxtaTfEXF0Q0tKyiRG0wWV6bLqJWehEeTrLRE8QXZSvDYg8y0ktPn9kj0z91unD9RJIZaTXv2nQxnqt4a4LYaL", false)]

        [InlineData("AA1234", true)]
        [InlineData("ABCD1", true)]
        [InlineData("abcd1", true)]
        [InlineData("1234567890AB", true)]
        [InlineData("ABXYZAB1", true)]
        [InlineData("abABc12", true)]
        [InlineData("gt63edcnki", true)]
        [InlineData("1234AB6789", true)]


        public void TestValidatePassword(string password, bool expected)
        {
            var userService = new UserService();
            var result = userService.ValidatePassword(password);
            Assert.Equal(expected, result);
        }
    }
}
