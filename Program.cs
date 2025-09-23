// Program for assignment module 1

/*

1. Create a indefinite loop until user types 'exit'.
2. Each iteration will take user input and save it to an array.
3. Each like of the array will be appended to a file.

*/
using System.Reflection.Metadata.Ecma335;

string file = "characterData.txt";

while (true)
{
    Console.Clear();
    Console.WriteLine("Select An Option: ");
    Console.WriteLine(""" 
    1. Append Character Data
    2. Display Character Data
    3. Exit
    """);
    string? choice = Console.ReadLine();
    if (choice == "3")
        break;
    switch (choice)
    {
        case "1":
            Console.Clear();
            StreamWriter sw = new(file, true); // 'true' enables append mode
            appendCharacter(file, sw);
            break;
        case "2":
            Console.Clear();
            StreamReader sr = new StreamReader(file);
            readFile(file, sr);
            break;
    }

    // +++++++++++++++++ Functions +++++++++++++++++ //

    // Store Inputs to file.
    static void appendCharacter(string file, StreamWriter sw)
    {
        Character character = new Character();

        Console.Write("Character Name: ");
        character.Name = Console.ReadLine() ?? "";

        Console.Write("Relationship to Mario: ");
        character.Relationship = Console.ReadLine() ?? "";

        Console.Write("Id Number: ");
        UInt64.TryParse(Console.ReadLine(), out UInt64 id);
        character.Id = id;

        sw.WriteLine($"{character.Id},{character.Name},{character.Relationship}");

        string? choice;
        do
        {
            Console.Write("Add another? (Y/N): ");
            choice = Console.ReadLine()?.ToUpper();
            if (choice == "Y")
            {
                appendCharacter(file, sw);
            }
            else if (choice == "N")
            {
                sw.Close();
                break;
            }
            else
            {
                Console.WriteLine("Sorry, wrong input.");
            }
        } while (choice != "N");
    }
    // Read file
    static void readFile(string file, StreamReader sr)
    {
        if (File.Exists(file))
        {
            using (sr)
            {
                string? line;
                while ((line = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
        }
        else { Console.WriteLine("No data file found."); }

        Console.Write("\nBack to Menu: ");
        Console.ReadLine();
    }
}