using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Ticket_Reservation_System
{
    class MyIdisposed : IDisposable
    {
        public void Dispose()
        {
            DisposedManagedResources();
        }
        protected virtual void DisposedManagedResources()
        {
            MYprintPreviewDialog1.Dispose();
        }
    }
}
