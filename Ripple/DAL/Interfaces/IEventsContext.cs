using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ripple.Models;

namespace Ripple.DAL.Interfaces
{
    public interface IEventsContext
    {
        IEnumerable<Events> GetEvents { get; }
    }
}
