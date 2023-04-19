namespace PhoneBook
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello from the PhoneBook app");
            Console.WriteLine("****************************");

            Console.WriteLine("1 Add contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 Display all contacts");
            Console.WriteLine("4 Search contacts");
            Console.WriteLine("5 Remove contact by phone number");
            Console.WriteLine("To exit insert 'x'");

            var userInput = Console.ReadLine();
            var phoneBook = new PhoneBook();

            while (true)
            {
                switch (userInput)
                {
                    case "1":

                        Console.WriteLine("Insert number");
                        var number = int.Parse(Console.ReadLine());
                        if (!ValidateNumber(number)){
                            Console.WriteLine("Number should have min 9 symbols");
                            break;
                        }
                        Console.WriteLine("Insert name");
                        var name = Console.ReadLine();
                        if (!ValidateName(name))
                        {
                            Console.WriteLine("Name should have min 3 chars");
                            break;
                        }

                        var newContact = new Contact(name, number);

                        phoneBook.AddContact(newContact);

                        break;
                    case "2":

                        Console.WriteLine("Insert number");
                        var numberToSearch = int.Parse(Console.ReadLine());

                        phoneBook.DisplayContact(numberToSearch);

                        break;
                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;
                    case "4":
                        Console.WriteLine("Insert search phrase");
                        var searchPhrase = Console.ReadLine();

                        phoneBook.DisplayMatchingContacts(searchPhrase);
                        break;
                    case "5":
                        Console.WriteLine("Insert number to remove");
                        var namberToRemove = int.Parse(Console.ReadLine());
                        if (!ValidateNumber(namberToRemove))
                        {
                            Console.WriteLine("Number should have min 9 symbols");
                            break;
                        }
                        phoneBook.RemoveContactByNumber(namberToRemove);
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
                Console.WriteLine("Select operation");
                userInput = Console.ReadLine();
            }

        }
        private static bool ValidateNumber(int number)
        {
            return number < 9 ? false : true;
        }
        private static bool ValidateName(string name)
        {
            return name.Length < 3 ? false : true;
        }
    }
}