using Models.Domain.Enums;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Models.Domain.Helpers
{
    public static class EStateExtensions
    {
        private static Dictionary<ETicketState, string> Translations = new Dictionary<ETicketState, string>{
            { ETicketState.Created, "Criado"},
            { ETicketState.Assigned, "Atribuído"},
            { ETicketState.BeingHandled, "Em Tratamento"},
            { ETicketState.Closed, "Fechado"},
        };
        public static string Translation(this ETicketState state) => Translations[state];
    }
}
