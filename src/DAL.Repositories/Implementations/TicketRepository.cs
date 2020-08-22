namespace DAL.Repositories.Implementations
{
    using DAL.Repositories.Interfaces;
    using Models.Domain.Models;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class TicketRepository : ITicketActionRepository
    {
        private readonly string COLLECTIONNAME = "TicketActions";
        private readonly IMongoCollection<TicketAction> _collection;

        public TicketRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<TicketAction>(COLLECTIONNAME);
        }
        public TicketAction Create(TicketAction model)
        {
            _collection.InsertOne(model);
            return model;
        }

        public List<TicketAction> Get() =>
            _collection.Find(book => true).ToList();

        public TicketAction Get(string id) =>
            _collection.Find<TicketAction>(book => book.Id == id).FirstOrDefault();
    }
}
