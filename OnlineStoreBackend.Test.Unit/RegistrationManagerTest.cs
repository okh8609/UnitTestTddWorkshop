using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBackend.Test.Unit
{
    [TestFixture]
    public class RegistrationManagerTest
    {
        [Test]
        public void AcceptsAccountWhenValidUsernamePasswordAreRegistered() // 動詞為首：當合法的username、password輸入時，會接受
        {
            // Arrange
            // 安排測試的先決條件
            RegistrationManager regMgr = new RegistrationManager();

            // Act
            // 要觸發的動作
            bool result = regMgr.RegisterAccount("usr", "NtuCsie999");

            // Assert
            // 預期會由什麼樣的結果
            Assert.True(result);
        }

        [TestCase("")] // 參數化的測試 (Parameterized Test)
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("12345678901")]
        [TestCase("123456789012345 ")]
        public void RejectsAccountWhenUsernameWithInvalidLengthRegistered(string username)
        {
            // Arrange
            RegistrationManager regMgr = new RegistrationManager();
            // Act
            bool result = regMgr.RegisterAccount(username, "NtuCsie999"); //一次操縱一個變因
            // Assert
            Assert.False(result);
        }

        [TestCase("user@123")]
        [TestCase("user!456")]
        [TestCase("#str$18&")]
        public void RejectsAccountWhenUsernameWithInvalidCharsRegistered(string username)
        {
            // Arrange
            RegistrationManager regMgr = new RegistrationManager();
            // Act
            bool result = regMgr.RegisterAccount(username, "NtuCsie999");
            // Assert
            Assert.False(result);
        }

        [TestCase("")]
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("123")]
        [TestCase("1234")]
        [TestCase("12345")]
        [TestCase("12345678901")]
        [TestCase("123456789012345 ")]
        public void RejectsAccountWhenPasswordWithInvalidLengthRegistered(string password)
        {
            // Arrange
            RegistrationManager regMgr = new RegistrationManager();
            // Act
            bool result = regMgr.RegisterAccount("usr123", password);
            // Assert
            Assert.False(result);
        }

        [TestCase("user@123")]
        [TestCase("user!456")]
        [TestCase("#str$18&")]
        public void RejectsAccountWhenPasswordWithInvalidCharsRegistered(string password)
        {
            // Arrange
            RegistrationManager regMgr = new RegistrationManager();
            // Act
            bool result = regMgr.RegisterAccount("usr123", password);
            // Assert
            Assert.False(result);
        }

        [TestCase("taipei101")]
        [TestCase("TAIPEI101")]
        [TestCase("taipeiZZZ")]
        [TestCase("000000000")]
        [TestCase("aaaaaaaaa")]
        [TestCase("AAAAAAAAA")]
        public void RejectsAccountWhenPasswordWithInvalidCaseRegistered(string password)
        {
            // Arrange
            RegistrationManager regMgr = new RegistrationManager();
            // Act
            bool result = regMgr.RegisterAccount("usr123", password);
            // Assert
            Assert.False(result);
        }
    }
}
