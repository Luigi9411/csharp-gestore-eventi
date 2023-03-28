using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Event
    {
        public string Title {get;set;}

        public string Date { get;set;}

        public int MaximumCapacityOftheEvent { get; private set; }

        public int NumberOfSeatsBooked { get; private set;}
    }
}
