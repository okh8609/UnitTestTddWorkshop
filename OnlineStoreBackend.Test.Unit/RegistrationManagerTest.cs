using NSubstitute;
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
        public void QueriesUsernameExistenceWhenValidUsernamePasswordAreRegistered() // 驗證是否有呼叫到.CheckUsernameExists()
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            RegistrationManager regMgr = new RegistrationManager(psm);

            // Act
            regMgr.RegisterAccount("usr", "NtuCsie999");

            // Assert
            psm.Received().CheckUsernameExists("usr");
        }


        [Test]
        public void AcceptsAccountWhenValidUsernamePasswordAreRegisteredAndUsernameDoesNotExist() // 動詞為首：當合法的username、password輸入時，會接受
        {
            // Arrange
            // 安排測試的先決條件
            IPersistenceManager psm = Substitute.For<IPersistenceManager>(); // 使用NSubstitute來模擬出一個已經實作好的object --> fake object
            psm.CheckUsernameExists("usr").Returns(false); // 規定說 當輸入參數為"usr"時，會回傳false (意即"usr"這個使用者不存在，所以可以註冊)

            RegistrationManager regMgr = new RegistrationManager(psm); // 依賴注入 (Dependency injection) --> constructor injection

            // Act
            // 要觸發的動作
            bool result = regMgr.RegisterAccount("usr", "NtuCsie999");

            // Assert
            // 預期會由什麼樣的結果
            Assert.True(result);
        }

        [Test]
        public void AcceptsAndSaveAccountWhenValidUsernamePasswordAreRegisteredAndUsernameDoesNotExist()
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            psm.CheckUsernameExists("usr").Returns(false);

            RegistrationManager regMgr = new RegistrationManager(psm); 

            // Act
            bool result = regMgr.RegisterAccount("usr", "NtuCsie999");

            // Assert
            Assert.True(result);
            psm.Received().SaveAccount("usr", "NtuCsie999");
        }

        [Test]
        public void RejectAndDoesNotSaveAccountWhenValidUsernamePasswordAreRegisteredAndUsernameAlreadyExist() // 動詞為首：當合法的username、password輸入時，會接受
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            psm.CheckUsernameExists("usr").Returns(true);

            RegistrationManager regMgr = new RegistrationManager(psm);

            // Act
            bool result = regMgr.RegisterAccount("usr", "NtuCsie999");

            // Assert
            Assert.False(result);
            psm.DidNotReceiveWithAnyArgs().SaveAccount(default(string), default(string)); // default(string) --> 測試套件的語法 只要是string就好了 不管它是什麼string
        }

        [TestCase("")] // 參數化的測試 (Parameterized Test)
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("12345678901")]
        [TestCase("123456789012345 ")]
        public void RejectsAccountWhenUsernameWithInvalidLengthRegistered(string username)
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            RegistrationManager regMgr = new RegistrationManager(psm);
            // Act
            bool result = regMgr.RegisterAccount(username, "NtuCsie999"); //一次操縱一個變因
            // Assert
            Assert.False(result);
            psm.DidNotReceiveWithAnyArgs().SaveAccount(default(string), default(string));
        }

        [TestCase("user@123")]
        [TestCase("user!456")]
        [TestCase("#str$18&")]
        public void RejectsAccountWhenUsernameWithInvalidCharsRegistered(string username)
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            RegistrationManager regMgr = new RegistrationManager(psm);
            // Act
            bool result = regMgr.RegisterAccount(username, "NtuCsie999");
            // Assert
            Assert.False(result);
            psm.DidNotReceiveWithAnyArgs().SaveAccount(default(string), default(string));
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
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            RegistrationManager regMgr = new RegistrationManager(psm);
            // Act
            bool result = regMgr.RegisterAccount("usr123", password);
            // Assert
            Assert.False(result);
            psm.DidNotReceiveWithAnyArgs().SaveAccount(default(string), default(string));
        }

        [TestCase("user@123")]
        [TestCase("user!456")]
        [TestCase("#str$18&")]
        public void RejectsAccountWhenPasswordWithInvalidCharsRegistered(string password)
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            RegistrationManager regMgr = new RegistrationManager(psm);
            // Act
            bool result = regMgr.RegisterAccount("usr123", password);
            // Assert
            Assert.False(result);
            psm.DidNotReceiveWithAnyArgs().SaveAccount(default(string), default(string));
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
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            RegistrationManager regMgr = new RegistrationManager(psm);
            // Act
            bool result = regMgr.RegisterAccount("usr123", password);
            // Assert
            Assert.False(result);
            psm.DidNotReceiveWithAnyArgs().SaveAccount(default(string), default(string));
        }

    }
}
