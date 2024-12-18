namespace Phonebook;
class Program
{
    const int PageSize = 2;
    static void Main()
    {
        List<Contact> contacts = Prepare().OrderBy(c => c.Name).ThenBy(c => c.LastName).ToList();

        while (true)
        {
            try
            {
                int input = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.Clear();

                if (input > Math.Round((decimal)(contacts.Count / PageSize), 1, MidpointRounding.AwayFromZero)) { throw new ArithmeticException(); }
                var page = contacts.Skip((input - 1) * PageSize).Take(PageSize);
                foreach (Contact contact in page) { Console.WriteLine($"{contact.Name} {contact.LastName} ({contact.Email}): {contact.PhoneNumber}"); }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
    static List<Contact> Prepare() => new()
        {
            new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
            new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
            new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
            new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
            new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
            new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
        };
}