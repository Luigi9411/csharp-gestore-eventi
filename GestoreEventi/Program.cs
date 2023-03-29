using GestoreEventi;

Console.WriteLine("Inserisci un nuovo evento:");

Console.WriteLine("Titolo evento:");
string title = Console.ReadLine()!;

Console.WriteLine("Data evento:");
DateTime date = Convert.ToDateTime(Console.ReadLine());

Console.WriteLine("Capienza massima:");
int maximumCapacity = Convert.ToInt32(Console.ReadLine());

var @event = new Event(title, date, maximumCapacity);

Console.WriteLine("Vuoi fare prenotazioni? (0 = no, altrimenti specificare numero)");
int reservations = Convert.ToInt32(Console.ReadLine());

@event.BookSeats(reservations);

Console.WriteLine($"Numero dei posti prenotati = {@event.ReservedSeats}.");
Console.WriteLine($"Numero dei posti disponibili = {@event.PlacesAvailable}.");

Console.Write("Vuoi disdire dei posti ? (si/no): ");
string input = Console.ReadLine();

while (input.ToLower() == "si")
{
    Console.Write("Quanti posti vuoi disdire dei posti? ");
    int seats = int.Parse(Console.ReadLine());

    try
    {
        @event.CancelPlaces(seats);
        var postiDisponibili = @event.MaximumCapacity - @event.ReservedSeats;
        Console.WriteLine($"Numero posti disdetti = {seats}");
        Console.WriteLine($"Numero posti disponibili = {@event.PlacesAvailable}");
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine(exception.Message);
    }

    Console.Write("Quanti posti vuoi disdire dei posti? (si/no): ");
    input = Console.ReadLine();
}
Console.Write("Ok va bene"); 
Console.ReadLine();

