using RomertalKonvertering;

bool exit = false;
do
{
    Console.WriteLine("Muligheder: ");
    string options =
        " (1) Romertal til deciamltal\n" +
        " (2) Deciamltal til romertal\n" +
        " (3) Gå ud\n";
    Console.Write(options);

    int option;
    try
    {
        option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                string? romanNumeralStr = Convert.ToString(Console.ReadLine());
                RomanNumeral rn = new(romanNumeralStr);
                Console.WriteLine("Her er svaret: {0}", rn.IntegerValue);
                exit = false;
                break;
            case 2:
                int number = Convert.ToInt32(Console.ReadLine());
                rn = new RomanNumeral(number);
                Console.WriteLine("Her er svaret: {0}", rn.RomanNumeralStr);
                exit = false;
                break;
            case 3:
                Console.WriteLine("Lukker");
                exit = true;
                break;
            default:
                Console.WriteLine("Ugyldigt svar. Prøv igen");
                exit = false;
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
} while (!exit);
