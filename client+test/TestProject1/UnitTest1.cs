using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Sockets;
using System.Net;
namespace CSCS1;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestSendClearDisplayCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testColor = "test_color";
        var expectedCommand = "clear display: " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testColor}\n"));

            // Act
            Program.SendClearDisplayCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendDrawPixelCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testColor = "test_color";
        var expectedCommand = "draw pixel: " + testX0 + ", " + testY0 + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testColor}\n"));

            // Act
            Program.SendDrawPixelCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendDrawLineCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testX1 = 30;
        var testY1 = 40;
        var testColor = "test_color";
        var expectedCommand = "draw line: " + testX0 + ", " + testY0 + ", " + testX1 + ", " + testY1 + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testX1}\n{testY1}\n{testColor}\n"));

            // Act
            Program.SendDrawLineCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть x1: ¬вед≥ть y1: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }


    [TestMethod]
    public void TestSendDrawRectangleCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testW = 30;
        var testH = 40;
        var testColor = "test_color";
        var expectedCommand = "draw rectangle: " + testX0 + ", " + testY0 + ", " + testW + ", " + testH + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testW}\n{testH}\n{testColor}\n"));

            // Act
            Program.SendDrawRectangleCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть ширину: ¬вед≥ть висоту: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendDrawCircleCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testRadius = 30;
        var testColor = "test_color";
        var expectedCommand = "draw circle: " + testX0 + ", " + testY0 + ", " + testRadius + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testRadius}\n{testColor}\n"));

            // Act
            Program.SendDrawCircleCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть рад≥ус: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendFillCircleCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testRadius = 30;
        var testColor = "test_color";
        var expectedCommand = "fill circle: " + testX0 + ", " + testY0 + ", " + testRadius + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testRadius}\n{testColor}\n"));

            // Act
            Program.SendFillCircleCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть рад≥ус: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendDrawRoundedRectangleCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testW = 30;
        var testH = 40;
        var testRadius = 50;
        var testColor = "test_color";
        var expectedCommand = "draw rounded rectangle: " + testX0 + ", " + testY0 + ", " + testW + ", " + testH + ", " + testRadius + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testW}\n{testH}\n{testRadius}\n{testColor}\n"));

            // Act
            Program.SendDrawRoundedRectangleCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть ширину: ¬вед≥ть висоту: ¬вед≥ть рад≥ус: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendFillRoundedRectangleCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testW = 30;
        var testH = 40;
        var testRadius = 50;
        var testColor = "test_color";
        var expectedCommand = "fill rounded rectangle: " + testX0 + ", " + testY0 + ", " + testW + ", " + testH + ", " + testRadius + ", " + testColor;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testW}\n{testH}\n{testRadius}\n{testColor}\n"));

            // Act
            Program.SendFillRoundedRectangleCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть ширину: ¬вед≥ть висоту: ¬вед≥ть рад≥ус: ¬вед≥ть кол≥р:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendDrawTextCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testColor = "test_color";
        var testFontNumber = 2;
        var testLength = 12;
        var testText = "Sample Text";
        var expectedCommand = "draw text: " + testX0 + ", " + testY0 + ", " + testColor + ", " + testFontNumber + ", " + testLength + ", " + testText;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testColor}\n{testFontNumber}\n{testLength}\n{testText}\n"));

            // Act
            Program.SendDrawTextCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть кол≥р: ¬вед≥ть номер шрифту: ¬вед≥ть довжину тексту: ¬вед≥ть текст:  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

    [TestMethod]
    public void TestSendDrawImageCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testX0 = 10;
        var testY0 = 20;
        var testW = 30;
        var testH = 40;
        var testData = "sample_image_data"; // «м≥н≥ть це на реальн≥ дан≥
        var expectedCommand = "draw image: " + testX0 + ", " + testY0 + ", " + testW + ", " + testH + ", " + testData;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testX0}\n{testY0}\n{testW}\n{testH}\n{testData}\n"));

            // Act
            Program.SendDrawImageCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть x0: ¬вед≥ть y0: ¬вед≥ть ширину: ¬вед≥ть висоту: ¬вед≥ть дан≥ (data_length = w * h * sizeof(color)):  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }
    [TestMethod]
    public void TestSendSetOrientationCommand()
    {
        // Arrange
        var udpClient = new UdpClient();
        var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        var testOrientation = 2; // —пробуйте р≥зн≥ значенн€ ор≥Їнтац≥њ
        var expectedCommand = "set orientation: " + testOrientation;

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{testOrientation}\n"));

            // Act
            Program.SendSetOrientationCommand(udpClient, serverEndPoint);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual($"¬вед≥ть ор≥Їнтац≥ю (0=0, 1=90, 2=180, 3=270):  оманда над≥слана на сервер: {expectedCommand}", result);
        }
    }

   

   


}


