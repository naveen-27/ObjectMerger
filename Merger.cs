namespace ObjectMerger
{
    public static class MergerReflection
    {
        public static PersonRoot MergeReflection()
        {
            PersonRoot personOne = new PersonRoot
            {
                Person = new Person
                {
                    UniqueId = Guid.NewGuid(),
                    Address = new Address
                    {
                        Street = "One",
                    },
                    Name = "Naveen",
                    Age = 24,
                    Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "C#",
                        YearsOfExperience = 1,
                    },
                    new Skill
                    {
                        Name = "JavaScript",
                        YearsOfExperience = 1,
                    }
                }
                }
            };
            PersonRoot personTwo = new PersonRoot
            {
                Person = new Person
                {
                    UniqueId = Guid.NewGuid(),
                    Age = 40,
                    Address = new Address
                    {
                        Street = "Two",
                    },
                    Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "MachineLearning",
                        YearsOfExperience = 1,
                    }
                }
                }
            };

            Merge(personOne, personTwo);
            return personOne;
        }

        public static void Merge(object? target, object src)
        {
            List<string> complexTypesConsidereAsBase = new List<string> { "list", "guid", "string", "array" };
            var properties = src.GetType().GetProperties().Where(property => property.CanRead && property.CanWrite).ToList();

            foreach (var property in properties)
            {
                var srcPropertyValue = property.GetValue(src, null);
                if (srcPropertyValue == null)
                {
                    continue;
                }

                if (property.PropertyType.IsValueType || complexTypesConsidereAsBase.Exists(type => property.PropertyType.Name.ToLower().Contains(type)))
                {
                    property.SetValue(target, srcPropertyValue);

                }
                else
                {
                    var targetPropertyValue = property.GetValue(target, null);
                    Merge(targetPropertyValue, srcPropertyValue);
                }
            }
        }
    }

    public static class MergerTraditional
    {
        public static PersonRoot MergeTraditional()
        {
            PersonRoot personOne = new PersonRoot
            {
                Person = new Person
                {
                    UniqueId = Guid.NewGuid(),
                    Address = new Address
                    {
                        Street = "One",
                    },
                    Name = "Naveen",
                    Age = 24,
                    Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "C#",
                        YearsOfExperience = 1,
                    },
                    new Skill
                    {
                        Name = "JavaScript",
                        YearsOfExperience = 1,
                    }
                }
                }
            };
            PersonRoot personTwo = new PersonRoot
            {
                Person = new Person
                {
                    UniqueId = Guid.NewGuid(),
                    Age = 40,
                    Address = new Address
                    {
                        Street = "Two",
                    },
                    Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "MachineLearning",
                        YearsOfExperience = 1,
                    }
                }
                }
            };

            personOne.MergeWith(personTwo);
            return personOne;
        }
    }
}
