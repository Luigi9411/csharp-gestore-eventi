using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Event
    {
        private string title;
        private DateTime date;
        private int maximumCapacity;
        private int reservedSeats;
        public Event(string title, DateTime date, int maximumCapacity)
        {
            Title = title;
            Date = date;
            MaximumCapacity = maximumCapacity;
        }

        public string Title
        {
            get { return title; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be left empty.");
                }

                title = value;
            }
        }

        public DateTime Date
        {
            get { return date; }
            private set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("La data deve essere successiva alla giornaliera.");
                }

                date = value;
            }
        }

        public int MaximumCapacity
        {
            get { return maximumCapacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("La capienza deve essere un numero intero positivo.");
                }

                maximumCapacity = value;
            }
        }

        public int ReservedSeats { get; private set;}

        public int PlacesAvailable
        {
            get { return MaximumCapacity - ReservedSeats; }
            private set{ }
        }

        public void BookSeats(int seats)
        {
            EnsureDateIsNotPast();

            if ( maximumCapacity is 0)
            {
                throw new InvalidOperationException("Questo evento non prevede posti, non è possibile prenotare.");
            }

            if (PlacesAvailable < seats)
            {
                throw new InvalidOperationException("Posti disponibili insufficienti.");
            }

            ReservedSeats += seats;
        }

        public void CancelPlaces(int seats)
        {
            EnsureDateIsNotPast();

            if (ReservedSeats < seats)
            {
                throw new InvalidOperationException("Prenotazioni da annullare.");
            }

            ReservedSeats -= seats;
        }


        public override string ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
        }

        private  void EnsureDateIsNotPast()
        {
            if (Date < DateTime.Now)
            {
                throw new InvalidOperationException("Impossibile prenotare, l'evento è passato.");
            }
        }
    }
}
