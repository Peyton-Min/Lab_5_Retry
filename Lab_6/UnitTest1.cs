using Lab_5_Attempt_2.Data;
using Lab_5_Attempt_2.Services;
//Code Source: https://chatgpt.com/share/673b8ef3-2d58-8002-937e-608e196f023e

namespace Lab_6
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void TestAddBookExists()
        {
            // Arrange
            var type = typeof(BookServices); // Get the type of the BookServices class

            // Act
            var method = type.GetMethod("AddBook",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "AddBook method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestEditBookExists()
        {
            // Arrange
            var type = typeof(BookServices); 

            // Act
            var method = type.GetMethod("EditBook",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "EditBook method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestReadBooksExist()
        {
            // Arrange
            var type = typeof(BookServices);

            // Act
            var method = type.GetMethod("ReadBooks",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "ReadBooks method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestDeleteBookExist()
        {
            // Arrange
            var type = typeof(BookServices);

            // Act
            var method = type.GetMethod("DeleteBook",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "DeleteBook method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestReadUsersExist()
        {
            // Arrange
            var type = typeof(UserServices);

            // Act
            var method = type.GetMethod("ReadUsers",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "ReadUsers method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestAddUserExist()
        {
            // Arrange
            var type = typeof(UserServices);

            // Act
            var method = type.GetMethod("AddUser",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "AddUser method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestEditUserExist()
        {
            // Arrange
            var type = typeof(UserServices);

            // Act
            var method = type.GetMethod("EditUser",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "EditUser method does not exist in the BookServices class.");
        }

        [TestMethod]
        public void TestDeleteUserExist()
        {
            // Arrange
            var type = typeof(UserServices);

            // Act
            var method = type.GetMethod("DeleteUser",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.IsNotNull(method, "DeleteUser method does not exist in the BookServices class.");
        }
    }
}