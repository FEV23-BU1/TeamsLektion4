namespace TeamsLektion4;

/*

1. Skapa användare
   - Endast som `Admin`
2. Logga in som användare
3. Logga ut som användare
4. Skapa klasser och koppla användare
   - Som `Admin` eller `Lärare`
5. Skapa kurser och koppla till klasser
   - Som `Admin` eller `Lärare`
6. Lägga in betyg för klass, studerande och kurs
   - Som `Admin` eller `Lärare`
7. Se betyg som användare
   - Egna betyg om man är inloggad som `Studerande`
   - Alla betyg om man är inloggad som `Admin` eller `Lärare`
8. Meddela andra användare
   - Med två olika system: email & internt

Användartyper:
- Admin
   - Det finns endast ett Admin konto
- Lärare
- Studerande

*/

class Program
{
    static void Main(string[] args)
    {
        IdGenerator idGenerator = new CountingGenerator();
        SchoolApplication app = new SchoolApplication(
         idGenerator,
         new LocalUserService(idGenerator),
         new LocalGroupService(),
         new LocalCourseService()
         );

         app.Start();
    }
}

// Vi måste på något sätt spara all information som finns i hela programmet. Det är vad denna klass är till för. 
// Den håller all information (alla användare, alla kurser, alla klasser, alla betyg och så vidare).
public class SchoolApplication
{
    // Det skall endast finnas en admin i hela programmet och därför lägger vi den som variabel här.
    // Det blir enkelt att komma åt den då.
    // TODO: Vi vill dock att den ska ligga i "UserService" eftersom den tillhör det systemet.
    private Administrator _admin;

    // Vi måste på något sätt hantera och spara användare. Det är vad "IUserService" är till för.
    // Vi har alltså en egen struktur för att spara och hantera användare.
    // Anledningen till att det är en egen struktur (och ett interface) är för att vi enkelt
    // kan bygga ut det då. Vi kan kan byta mellan databaser, filer, test saker och annat.
    // Är en Singleton.
    private IUserService _userService;

    // Vi måste på något sätt hantera och spara klasser (grupper). Det är vad "IGroupService" är till för.
    // Vi har alltså en egen struktur för att spara och hantera klasser (grupper).
    // Anledningen till att det är en egen struktur (och ett interface) är för att vi enkelt
    // kan bygga ut det då. Vi kan kan byta mellan databaser, filer, test saker och annat.
    // Är en Singleton.
    private IGroupService _groupService;

    // Vi måste på något sätt hantera och spara kurser. Det är vad "ICourseService" är till för.
    // Vi har alltså en egen struktur för att spara och hantera kurser.
    // Anledningen till att det är en egen struktur (och ett interface) är för att vi enkelt
    // kan bygga ut det då. Vi kan kan byta mellan databaser, filer, test saker och annat.
    // Är en Singleton.
    private ICourseService _courseService;

    // En constructor för att enkelt kunna lägga in värden för alla services.
    public SchoolApplication(IdGenerator idGenerator, IUserService userService, IGroupService groupService, ICourseService courseService)
    {
        // Hårdkoda admin användaren eftersom den endast skall finnas en instans.
        // Detta kallas för "Singleton" eftersom det endast finns en instans.
        this._admin = new Administrator(idGenerator);
        this._userService = userService;
        this._groupService = groupService;
        this._courseService = courseService;
    }

    // Metoden som skall starta igång hela programmet.
    public void Start() {
        this._userService.Register("Adam", "Olofsson", "adam@olofsson.se", "pass123", UserType.Student);
        this._userService.Register("Ironman", "", "ironman@stark.com", "pass123", UserType.Teacher);
        this._userService.Register("Fredrik", "Andersson", "fredrik@andersson.se", "pass123", UserType.Student);

        User? loggedIn = this._userService.Login("adam@olofsson.se", "pass123");
        if (loggedIn != null) {
            Console.WriteLine(loggedIn.FirstName);
        }
    }
}
