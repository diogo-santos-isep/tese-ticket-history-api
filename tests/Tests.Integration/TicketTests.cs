namespace Tests.Integration
{
    using AutoFixture;
    using BLL.Services.Implementations;
    using DAL.Repositories.Implementations;
    using DAL.Repositories.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Domain.Models;
    using MongoDB.Bson;
    using System;
    using System.Linq;
    using Tests.Integration.Helpers;

    [TestClass]
    public class TicketActionTests
    {
        private TicketActionService _service;
        private Fixture fixture = new Fixture();

        public TicketActionTests()
        {
            var repo = new TicketActionRepository(DatabaseConnection.Current.Database);
            this._service = new TicketActionService(repo);
        }

        [TestMethod()]
        public void Create_Success()
        {
            var newTicketAction = this.GenerateNewTicketAction();

            newTicketAction = this._service.Create(newTicketAction);
            Assert.IsFalse(String.IsNullOrEmpty(newTicketAction.Id), "Id came back null or empty");

            var savedTicketAction = this._service.Get(newTicketAction.Id);
            Assert.AreEqual(savedTicketAction, newTicketAction, "TicketActions are different");
        }

        [TestMethod()]
        public void GetSingle_Success()
        {
            var newTicketAction = this.GenerateNewTicketAction();

            newTicketAction = this._service.Create(newTicketAction);

            var savedTicketAction = this._service.Get(newTicketAction.Id);
            Assert.IsNotNull(savedTicketAction, "TicketAction does not exist");
            Assert.AreEqual(savedTicketAction, newTicketAction, "TicketActions are different");
        }

        [TestMethod()]
        public void GetAll_Success()
        {
            var newTicketAction = this.GenerateNewTicketAction();
            var newTicketAction2 = this.GenerateNewTicketAction();

            this._service.Create(newTicketAction);
            this._service.Create(newTicketAction2);

            var ticketActions = this._service.Get();
            Assert.IsTrue(ticketActions.Any(t => t.Id == newTicketAction.Id), $"TicketAction1 does not exist");
            Assert.IsTrue(ticketActions.Any(t => t.Id == newTicketAction.Id), $"TicketAction2 does not exist");
        }

        private TicketAction GenerateNewTicketAction()
        {
            return this.fixture.Build<TicketAction>()
                .Without(t => t.Id)
                .With(t => t.TicketId, ObjectId.GenerateNewId().ToString())
                .With(t => t.UserId, ObjectId.GenerateNewId().ToString())
                .Create();
        }
    }
}
