namespace Tiers.Core;

public class Student
{
    public string Name { get; private set; }
    public int GroupNumber { get; private set; }

    public Student(string name, int groupNumber)
    {
        Name = name;
        GroupNumber = groupNumber;
    }

    protected bool Equals(Student other)
    {
        return Name == other.Name && GroupNumber == other.GroupNumber;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Student)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, GroupNumber);
    }
}