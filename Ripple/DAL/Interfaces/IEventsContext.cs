using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ripple.Models;

namespace Ripple.DAL.Interfaces
{
    /// <summary>
    /// A simple interface for our data context.
    /// </summary>
    public interface IEventsContext
    {
        IEnumerable<Events> GetEvents { get; }
    }
}
