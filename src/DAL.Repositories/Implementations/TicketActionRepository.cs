namespace DAL.Repositories.Implementations
{
    using DAL.Repositories.Extensions;
    using DAL.Repositories.Interfaces;
    using Models.Domain.Models;
    using Models.Filters;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class TicketActionRepository : ITicketActionRepository
    {
        private readonly string COLLECTIONNAME = "TicketActions";
        private readonly IMongoCollection<TicketAction> _collection;

        public TicketActionRepository(IMongoDatabase database)
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
        public List<TicketAction> Search(TicketActionFilter filter)
        {
            var filters = filter.BuildFilters();
            var sort = filter.BuildSort<TicketAction>();
            return _collection
                    .Find(filters)
                    .Sort(sort)
                    .Skip((filter.Page - 1) * filter.PageSize)
                    .Limit(filter.PageSize)
                    .ToList();
        }

        public long Count(TicketActionFilter filter)
            =>
                _collection
                    .CountDocuments(filter.BuildFilters());
    }
}
