---
author: Lektion 4
---

# Teams lektion 4

Hej och välkommen!

## Agenda

1. Svar på frågor
2. Repetition
3. Genomgång av OOP övning 1 & 3
4. Redovisning av övningar
5. Projektbygge

---

# Fråga

Varför behövs `base` i `Administrator` men inte i `Manager`?

```c#
public class Manager : Employee
{
    public Manager(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public void PutEmployeeAtRegister()
    {
        Console.WriteLine("Put employee at register");
    }
}

public class Administrator : Manager
{
    public Administrator(string name, int id)
        : base(name, id)
    {
        this.Name = name;
        this.Id = id;
    }
}
```

---

# Fråga

I vilken ordning skall man göra övningarna?

---

# Fråga

När passar det bättre att använda `switch` istället för `if`?

---

# Fråga

När passar det bättre att använda `enum` istället för `klass`?

---

# Fråga

Ge fler verkliga exempel på när man skulle använda OOP kod. Varför är det bättre att göra så i varje fall?

## 1. Command parser

Det kräver oftast flera olika typer av argument och kommandon.

## 2. Databas hantering

Det kräver oftast testning.

## 3. Business-lager

1. Det behöver testning
2. Det behöver kunna byggas ut
3. Passar bra med `dependency injection`

---

# Fråga

Hur kopplas backend och frontend ihop till en färdig sida? Förklara övergripande.

---

# Fråga

Är det generellt bra att ha en basklass för allt när man fokuserar på OOP, även om man har olika kategorier av klasser?

---

# Fråga

Kan du visa fler exempel på get och set properties?

---

# Projektbygge - Skolsystem

*En liten version av omniway*

Följande funktionalitet skall ingå. Möjlighet att:

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
