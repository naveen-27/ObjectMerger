namespace ObjectMerger
{
    public interface IMergable<T>
    {
        void MergeWith(T? other);
    }

    public class PersonRoot : IMergable<PersonRoot> 
    {
        public Person? Person { get; set; }

        public void MergeWith(PersonRoot? other)
        {
            Person?.MergeWith(other?.Person);
        }
    }

    public class Person : IMergable<Person> 
    {
        public Guid? UniqueId { get; set; }

        public string? Name { get; set; }

        public int? Age { get; set; }

        public Address? Address { get; set; }

        public List<Skill>? Skills { get; set; }

        public void MergeWith(Person? other)
        {
            if (other != null)
            {
                UniqueId = other.UniqueId ?? UniqueId;
                Name = other.Name ?? Name;
                Age = other.Age ?? Age;
                Skills = other.Skills ?? Skills;

                Address?.MergeWith(other.Address);
            }
        }
    }

    public class Skill
    {
        public string? Name { get; set; }

        public int? YearsOfExperience { get; set; }
    }

    public class Address : IMergable<Address>
    {
        public string? Street { get; set; }

        public void MergeWith(Address? other)
        {
            if (other != null)
            {
                Street = other.Street ?? Street;
            }
        }
    }
}
