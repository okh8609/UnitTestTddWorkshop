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
    }
}
