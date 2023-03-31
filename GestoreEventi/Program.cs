using GestoreEventi;

//Console.WriteLine("Inserisci un nuovo evento:");

//Console.WriteLine("Titolo evento:");
//string title = Console.ReadLine()!;

//Console.WriteLine("Data evento:");
//DateTime date = Convert.ToDateTime(Console.ReadLine());

//Console.WriteLine("Capienza massima:");
//int maximumCapacity = Convert.ToInt32(Console.ReadLine());

//var @event = new Event(title, date, maximumCapacity);

//Console.WriteLine("Vuoi fare prenotazioni? (0 = no, altrimenti specificare numero)");
//int reservations = Convert.ToInt32(Console.ReadLine());

//@event.BookSeats(reservations);

//Console.WriteLine($"Numero dei posti prenotati = {@event.ReservedSeats}.");
//Console.WriteLine($"Numero dei posti disponibili = {@event.PlacesAvailable}.");

//Console.Write("Vuoi disdire dei posti ? (si/no): ");
//string input = Console.ReadLine();

//while (input.ToLower() == "si")
//{
//    Console.Write("Quanti posti vuoi disdire dei posti? ");
//    int seats = int.Parse(Console.ReadLine());

//    try
//    {
//        @event.CancelPlaces(seats);
//        var postiDisponibili = @event.MaximumCapacity - @event.ReservedSeats;
//        Console.WriteLine($"Numero posti disdetti = {seats}");
//        Console.WriteLine($"Numero posti disponibili = {@event.PlacesAvailable}");
//    }
//    catch (ArgumentException exception)
//    {
//        Console.WriteLine(exception.Message);
//    }

//    Console.Write("Quanti posti vuoi disdire dei posti? (si/no): ");
//    input = Console.ReadLine();
//}
//Console.Write("Ok va bene"); 
//Console.ReadLine();


Console.WriteLine("Inserisci il nome del tuo programma Eventi:");
  string events = Console.ReadLine()!;

Console.WriteLine("Indica il numero di eventi da inserire:");
  int numberEvents  = int.Parse(Console.ReadLine());

EventsProgram eventsProgram = new EventsProgram("title");

for (int i = 0; i < numberEvents; i++)
{
    Console.Write("Inserisci il nome dell' evento:");
    string title = Console.ReadLine();

    Console.Write("Inserisci la data dell'evento gg/mm/aaaa: ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write("Inserisci il numero di posti totali: ");
    int maxCapacity = int.Parse(Console.ReadLine());

    Console.WriteLine();

    Event newEvent = new Event(title, date, maxCapacity);
    eventsProgram.AddEvent(newEvent);
   
}

Console.Write("Il numero di eventi nel programma è: ");
Console.WriteLine(eventsProgram.NumberEvents());

Console.WriteLine("Ecco il tuo programma eventi:");
Console.WriteLine(eventsProgram.ToString());

Console.Write("Inserisci la data per sapere quali eventi ci saranno (formato gg/mm/aaaa): ");
DateTime specificDate = DateTime.Parse(Console.ReadLine());

List<Event> eventsInDate = eventsProgram.EventsInDate(specificDate);

if (eventsInDate.Count == 0)
{
    Console.WriteLine("Non ci sono eventi in questa data.");
}
else
{
    Console.WriteLine($"Ecco tutti gli eventi in data {specificDate}:");
    eventsProgram.PrintEvents(eventsInDate);
}

Console.ReadLine();