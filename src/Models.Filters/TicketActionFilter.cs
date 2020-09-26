namespace Models.Filters
{
    using System.Collections.Generic;

    public class TicketActionFilter : Filter
    {
        public string TicketId { get; set; }

        public TicketActionFilter()
        {
            this.SortBy = "Date";
        }
    }
}
