using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "11111111111";
            command.BarCode = "23142143214231";
            command.PaymentNumber = "123421";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerDocument = "32412412412";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "email@email.com";
            command.Street = "Rua 1";
            command.Number = "231";
            command.Neighborhood = "Bairro legal";
            command.City = "Gotan";
            command.State = "CE";
            command.Country = "BR";
            command.ZipCode = "60521541";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}