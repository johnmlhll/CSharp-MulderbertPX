using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Summary - Enum Class setting out initial order billing states
    /// </summary>
    public enum BillingState
    {
        Unbilled,
        Billed,
        Suspended,
        Deleted
    }
}