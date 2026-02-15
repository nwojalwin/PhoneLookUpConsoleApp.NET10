#region Contact
public class Contact
{
    public Contact(string name, string number)
    {
        Name = name;
        Number = number;

    }

    public string Name { get; set; }
    public string Number { get; set; }
}
#endregion

#region PhoneBook
public class PhoneBook
{
    public string Owner;
    public string OwnerNumber;
    private List<Contact> Contacts = new();

    public PhoneBook(string owner, string ownerNumber)
    {
        Owner = owner;
        OwnerNumber = ownerNumber;
    }

    public PhoneBook(string owner, string ownerNumber, List<Contact> contactBook) : this(owner, ownerNumber)
    {
        Contacts = contactBook ?? new();
    }

    public void AddContact(Contact person)
    {
        Contacts.Add(person);
    }

    public void ShowAllContacts()
    {
        foreach (var contact in Contacts)
        {
            Console.WriteLine($"{contact.Name}: {contact.Number}");
        }
    }
    public void WhoIsCalling(string number)
    {

        var contact = Contacts.FirstOrDefault(x => x.Number == number);
        if (contact == null)
        {
            Console.WriteLine("Unknown Number");
        }
        else
        {
            Console.WriteLine($"{contact.Name} is calling");
        }
    }

    public void FindNumberFor(string name)
    {
        var contact = Contacts.FirstOrDefault(x => x.Name == name);
        if (contact == null)
        {
            Console.WriteLine("Unknown Contact");
        }
        else
        {
            Console.WriteLine($"{contact.Name} number is: {contact.Number}");
        }

    }
}
#endregion

#region Program
    public class Program
    {
        public static void Main()
        {
        //v1
        #region
        //PhoneBook myPhoneBook = new PhoneBook("Natalia", "606 909 606");
        //Console.WriteLine($"Phone owner: {myPhoneBook.Owner}");
        //Console.WriteLine($"Phone owner's number: {myPhoneBook.OwnerNumber}");

        //// Dodawanie kontaktów
        //myPhoneBook.AddContact(new Contact("Marta", "555 666 777"));
        //myPhoneBook.AddContact(new Contact("Ania", "666 888 999"));
        //myPhoneBook.AddContact(new Contact("Bartek", "555 555 555"));

        //// Wyświetlanie kontaktów
        //myPhoneBook.ShowAllContacts();

        //// Znalezienie numeru dla kontaktu
        //myPhoneBook.FindNumberFor("Ania");

        //// Sprawdzenie, kto dzwoni
        //myPhoneBook.WhoIsCalling("555 215 555");
        #endregion

        Console.WriteLine("Phone LookUp App");
        Console.WriteLine("Select action: ");
        Console.WriteLine("1 - Add contact");
        Console.WriteLine("2 - Display all contacts");
        Console.WriteLine("3 - Display contact by number");
        Console.WriteLine("4 - Search contact number by name");
        Console.WriteLine("x - Edit");
        var userInput = Console.ReadLine();
        var phoneBook = new PhoneBook("User", "");

        while(true)
        {
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Insert number:");
                    var number = Console.ReadLine();
                    Console.WriteLine("Insert name:");
                    var name = Console.ReadLine();
                    Contact contact = new Contact(name, number);
                    phoneBook.AddContact(contact);
                    break;
                case "2":
                    phoneBook.ShowAllContacts();
                    break;
                case "3":
                    Console.WriteLine("Write searching number:");
                    var searchingNumber = Console.ReadLine();
                    phoneBook.WhoIsCalling(searchingNumber);
                    break;
                case "4":
                    Console.WriteLine("Write contact's name:");
                    var searchingName = Console.ReadLine();
                    phoneBook.FindNumberFor(searchingName);
                    break;
                case "x":
                    return;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            Console.WriteLine("Select action:");
            userInput = Console.ReadLine();
        }
    }
}
#endregion

