using System.Collections;

namespace EnumeratorPractice;

class Person{
    public Person(string name, int age){
        Name = name;
        Age = age;
    }

    public string Name {get; set;}
    public int Age {get; set;}
}

class PersonEnumarable : IEnumerable
{
    private readonly Person[] _people;

    public PersonEnumarable(Person[] people){

        _people = new Person[people.Length];

        for (int i = 0; i < people.Length; i++)
        {
            _people[i] = people[i];
        }
    }
    public PersonEnumerator GetEnumerator()
    {
        return new PersonEnumerator(_people);
    }

    IEnumerator IEnumerable.GetEnumerator(){
        return (IEnumerator)GetEnumerator();
    }
}

class PersonEnumerator : IEnumerator
{
    public PersonEnumerator(Person[] people){
        _people = people;
    }
    private readonly Person[] _people;
    private int _index = -1;

    public Person Current{
        get{
            return _people[_index];
        }
    }
    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _index++;
        return _index < _people.Length;

    }

    public void Reset()
    {
        _index = -1;
    }
}

class Program{
    static void Main(){
        var p = new Person[3]{
            new Person("Alpha",1),
            new Person("Beta",2),
            new Person("Gamma",3)
        };

        var pen = new PersonEnumarable(p);

        foreach (var item in pen)
        {
            Console.WriteLine($"The persons name is {item.Name} and is {item.Age} years old.");
        }
    }
}
