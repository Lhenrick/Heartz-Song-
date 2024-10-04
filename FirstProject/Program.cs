//Hertz Songs 
string welcomeMessage = "Welcome to the Hertz Songs";

//List<string> bandsList = new List<string> { "Guns", "The Beatles", "U2"};

Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>();
registeredBands.Add("Linkin Park", new List<int> { 10, 8, 6, 5 });
registeredBands.Add("Rolling Stones", new List<int>());

void DisplayLogo()
{
Console.WriteLine(@"
██╗░░██╗███████╗██████╗░████████╗███████╗  ░██████╗░█████╗░███╗░░██╗░██████╗░░██████╗
██║░░██║██╔════╝██╔══██╗╚══██╔══╝╚════██║  ██╔════╝██╔══██╗████╗░██║██╔════╝░██╔════╝
███████║█████╗░░██████╔╝░░░██║░░░░░███╔═╝  ╚█████╗░██║░░██║██╔██╗██║██║░░██╗░╚█████╗░
██╔══██║██╔══╝░░██╔══██╗░░░██║░░░██╔══╝░░  ░╚═══██╗██║░░██║██║╚████║██║░░╚██╗░╚═══██╗
██║░░██║███████╗██║░░██║░░░██║░░░███████╗  ██████╔╝╚█████╔╝██║░╚███║╚██████╔╝██████╔╝
╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝  ╚═════╝░░╚════╝░╚═╝░░╚══╝░╚═════╝░╚═════╝░
");
    Console.WriteLine(welcomeMessage);
}

void DisplayMenuOptions()
{
    DisplayLogo();
    Console.WriteLine("\nType 1 to register a band");
    Console.WriteLine("Type 2 to display all bands");
    Console.WriteLine("Type 3 to review a band");
    Console.WriteLine("Type 4 to display the average of a band");
    Console.WriteLine("Type -1 to exit a band");

    Console.Write("\n Type your option:");
    string chosenOption = Console.ReadLine()!;
    int chosenOptionNumber = int.Parse(chosenOption);
    
    switch (chosenOptionNumber)
    {
        case 1: RegisterBand(); 
            break;
        case 2:
            DisplayRegisteredBands();
            break;
        case 3:
            reviewBand();
            break;
        case 4:
            DisplayAverage();
            break;
        case -1:
            Console.WriteLine("Bye bye :D ");
            break;

        default: Console.WriteLine("Invalid option");
            break;
    }

}

void RegisterBand()
{
    Console.Clear();
    DisplayOptionTitle("Bands Registration");
    Console.Write("Type the name of the band you want to register: ");
    string bandName = Console.ReadLine()!;
    registeredBands.Add(bandName, new List<int>());
    Console.WriteLine($"The band {bandName} Was successfully registered");
    Thread.Sleep(4000);
    Console.Clear();
    DisplayMenuOptions();

}

void DisplayRegisteredBands()
{
    Console.Clear();
    DisplayOptionTitle("Displaying all registered bands");

    
    foreach(string band in registeredBands.Keys)
    {
        Console.Write($"Band: {band}\n");
    }
    Console.WriteLine("\nPress any key to go back to Menu");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();


}

void DisplayOptionTitle(string title)
{
    int lettersQuantity = title.Length;
    string asterisk = string.Empty.PadLeft(lettersQuantity, '*');
    Console.WriteLine(asterisk);
    Console.WriteLine(title);
    Console.WriteLine(asterisk);
}

void reviewBand()
{

    Console.Clear();
    DisplayOptionTitle("Review Band");
    Console.Write("Type the name of the band you want to review: ");
    string bandName = Console.ReadLine()!;
    if (registeredBands.ContainsKey(bandName))
    {
        Console.Write($"Rate the band {bandName} from 0 to 10");
        int rate = int.Parse(Console.ReadLine()!);
        registeredBands[bandName].Add(rate);
        Console.WriteLine($"You rated the band {bandName} to {rate}");
        Thread.Sleep(2000);
        Console.Clear();
        DisplayMenuOptions();
    } else
    {
        Console.WriteLine($"\nThe band {bandName} was not found");
        Console.WriteLine("Press any key to go back to the main menu...");
        Console.ReadKey();
        Console.Clear();
        DisplayMenuOptions();

    }
}

void DisplayAverage()
{
    Console.Clear();
;    DisplayOptionTitle("Rates Averages");
    Console.WriteLine("Type the name of the band you want to see the average rate");
    string bandName =  Console.ReadLine()!;
    if(registeredBands.ContainsKey(bandName)){

        List<int> bandRates = registeredBands[bandName];
        Console.WriteLine($"\nThe average rate of the band {bandName} is {bandRates.Average()}");
        Console.WriteLine("Press any key to go back to the main menu...");
        Console.ReadKey();
        Console.Clear();
        DisplayMenuOptions();

    }
    else
    {
        Console.WriteLine($"\nThe band {bandName} was not found");
        Console.WriteLine("Press any key to go back to the main menu...");
        Console.ReadKey();
        Console.Clear();
        DisplayMenuOptions();

    }
}

DisplayMenuOptions();



