namespace Models.Domain.Models
{
    using Infrastructure.CrossCutting.Helpers;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;

    public class TicketAction : IMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string TicketId { get; set; }
        public string TicketCode { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public string ActionDescription { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TicketAction action &&
                   Id == action.Id &&
                   TicketId == action.TicketId &&
                   TicketCode == action.TicketCode &&
                   Date.IsEqualDateTime(action.Date) &&
                   ActionDescription == action.ActionDescription &&
                   UserId == action.UserId &&
                   UserName == action.UserName;
        }

        public override int GetHashCode()
        {
            int hashCode = 1126506852;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TicketId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ActionDescription);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TicketCode);
            return hashCode;
        }
    }
}
