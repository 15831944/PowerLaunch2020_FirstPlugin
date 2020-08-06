using System;
using System.Linq;

namespace Parcels
{
    public interface IParcelSummaryWriter
    {
        void Write(ParcelSummary summary, IMessageWriter writer);
    }
}
