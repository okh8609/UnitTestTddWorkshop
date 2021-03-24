using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace OnlineStoreBackend.Test.Unit
{
    [TestFixture]
    public class LoginManagerTest
    {
        [Test]
        public void accept_login_when_username_registered_and_password_is_correct()
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            psm.VerifyAccount("usr", "NtuCsie999").Returns(true);

            LoginManager lmgr = new LoginManager(psm);

            // Act
            bool result = lmgr.Login("usr", "NtuCsie999");

            // Assert
            psm.Received().VerifyAccount("usr", "NtuCsie999");
            Assert.True(result);
        }

        [Test]
        public void reject_login_when_username_unregistered_or_password_is_incorrect()
        {
            // Arrange
            IPersistenceManager psm = Substitute.For<IPersistenceManager>();
            psm.VerifyAccount("usr2", "NtuCsie999").Returns(false);

            LoginManager lmgr = new LoginManager(psm);

            // Act
            bool result = lmgr.Login("usr2", "NtuCsie999");

            // Assert
            psm.Received().VerifyAccount("usr2", "NtuCsie999");
            Assert.False(result);
        }
    }
}
