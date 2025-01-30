namespace DefiningClasses;

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public Person() : this("No name", 1) {}
    
    public Person(int age) : this("No name",age) {}
    public Person(string name,int age)
    {
        Name = name;
        Age = age;
    }
}