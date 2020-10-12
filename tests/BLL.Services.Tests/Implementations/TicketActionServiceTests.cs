using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using DAL.Repositories.Interfaces;
using AutoFixture;
using Models.Domain.Models;
using Models.Filters;

namespace BLL.Services.Implementations.Tests
{
    [TestClass()]
    public class TicketActionServiceTests
    {
        private Mock<ITicketActionRepository> repoMock;
        private TicketActionService target;
        private Fixture fixture = new Fixture();

        public TicketActionServiceTests()
        {
            this.repoMock = new Mock<ITicketActionRepository>();
            this.target = new TicketActionService(repoMock.Object);
        }

        [TestMethod()]
        public void Create_Success()
        {
            var newTicketAction = this.GenerateNewTicketAction();

            this.target.Create(newTicketAction);

            this.repoMock.Verify(x => x.Create(newTicketAction), Times.Once, "Create não foi chamado");
        }

        [TestMethod()]
        public void Search_Success()
        {
            var filter = this.fixture.Create<TicketActionFilter>();
            this.target.Search(filter);

            this.repoMock.Verify(x => x.Search(filter), Times.Once, "Search não foi chamado");
            this.repoMock.Verify(x => x.Count(filter), Times.Once, "Count não foi chamado");
        }

        [TestMethod()]
        public void Get_Success()
        {
            var id = fixture.Create<string>();
            this.target.Get(id);
            this.repoMock.Verify(x => x.Get(id), Times.Once, "Get não foi chamado");
        }

        [TestMethod()]
        public void GetAll_Success()
        {
            this.target.Get();
            this.repoMock.Verify(x => x.Get(), Times.Once, "Get não foi chamado");
        }
        private TicketAction GenerateNewTicketAction()
        {
            return this.fixture.Build<TicketAction>()
                .Without(t => t.Id)
                .Create();
        }
    }
}