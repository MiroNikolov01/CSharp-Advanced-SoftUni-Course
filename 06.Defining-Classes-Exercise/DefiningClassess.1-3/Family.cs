namespace DefiningClasses;

public class Family
{
    public readonly List<Person> FamilyMembers = new List<Person>();

    public void AddMember(Person person)
    {
        FamilyMembers.Add(person);
    }

    public Person ReturnOldestMember() => FamilyMembers.OrderByDescending(x => x.Age).First();
    
}