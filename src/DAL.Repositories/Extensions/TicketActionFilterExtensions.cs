namespace DAL.Repositories.Extensions
{
    using Models.Domain.Models;
    using Models.Filters;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    public static class TicketActionNoteFilterExtensions
    {
        public static FilterDefinition<TicketAction> BuildFilters(this TicketActionFilter filter)
        {
            var arr = new List<FilterDefinition<TicketAction>>();
            if (!String.IsNullOrEmpty(filter.TicketId))
                arr.Add(Builders<TicketAction>.Filter.Eq(x => x.TicketId, filter.TicketId));
            if (arr.Count == 0)
                arr.Add(Builders<TicketAction>.Filter.Empty);
            return Builders<TicketAction>.Filter.And(arr);
        }

        public static SortDefinition<T> BuildSort<T>(this Filter filter)
        {
            return filter.SortAscending ? Builders<T>.Sort.Ascending(filter.SortBy) : Builders<T>.Sort.Descending(filter.SortBy);
        }
    }
}
