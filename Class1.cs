using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class CustomCommentAttribute : System.Attribute
    {
        public string Comment { get; }
        public CustomCommentAttribute(string comment)
        {
            Comment = comment;
        }
    }

    public abstract class Animal
    {
        public string Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public eClassificationAnimal WhatAnimal { get; set; }

        public Animal(string name, string country, bool hideFromOtherAnimals)
        {
            Name = name;
            Country = country;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public abstract eClassificationAnimal GetClassificationAnimal();
        public abstract eFavouriteFood GetFavouriteFood();
        public virtual string Message()
        {
            return "It is animal";
        }
        public virtual void Deconstruction() { }
    }

    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [CustomComment("Cow class")]
    public class Cow : Animal
    {
        public Cow(string name, string country, bool hideFromOtherAnimals) :
            base(name, country, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Herbivores;
        }
        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Plants;
        }

        public override eClassificationAnimal GetClassificationAnimal()
        {
            return WhatAnimal;
        }

        public override string Message()
        {
            return "Mooooo";
        }

        [CustomComment("This is a comment for the Lion class.")]
        public class Lion : Animal
        {
            public Lion(string name, string country, bool hideFromOtherAnimals) : base(name, country, hideFromOtherAnimals)
            {
                WhatAnimal = eClassificationAnimal.Carnivores;
            }

            public override eFavouriteFood GetFavouriteFood()
            {
                return eFavouriteFood.Meat;
            }

            public override string Message()
            {
                return "Roar!";
            }

            public override eClassificationAnimal GetClassificationAnimal()
            {
                return WhatAnimal;
            }
        }

        [CustomComment("This is a comment for the Pig class.")]
        public class Pig : Animal
        {
            public Pig(string name, string country, bool hideFromOtherAnimals) : base(name, country, hideFromOtherAnimals)
            {
                WhatAnimal = eClassificationAnimal.Omnivores;
            }

            public override eFavouriteFood GetFavouriteFood()
            {
                return eFavouriteFood.Everything;
            }

            public override string Message()
            {
                return "Oink!";
            }

            public override eClassificationAnimal GetClassificationAnimal()
            {
                return WhatAnimal;
            }
        }
    }


}
