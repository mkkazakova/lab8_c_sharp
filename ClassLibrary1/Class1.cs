using System.Xml.Serialization;

namespace ClassLibrary1
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommentAtt : Attribute
    {
        public string Comment { get; set; }

        public CommentAtt(string comment)
        {
            Comment = comment;
        }
    }

    public enum eAnimalClassification
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

    [Serializable]
    [XmlInclude(typeof(Cow))]
    [XmlInclude(typeof(Lion))]
    [XmlInclude(typeof(Pig))]
    [XmlRoot("Animal")]

    [CommentAtt("Абстрактный класс для объектов, представляющих животных")]
    public abstract class Animal
    {
        private eAnimalClassification classification;

        // Properties
        [XmlElement("Country")]
        public string Country { get; set; }

        [XmlElement("HideFromOtherAnimals")]
        public bool HideFromOtherAnimals { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("WhatAnimal")]
        public string WhatAnimal { get; set; }


        // Methods
        public Animal(string country, string name, string whatanimal, bool hideFromOtherAnimals)
        {
            Country = country;
            Name = name;
            WhatAnimal = whatanimal;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public void Deconstruct(out string out_country, out string out_name, out string out_whatanimal, out bool out_hide)
        {
            out_country = Country;
            out_name = Name;
            out_whatanimal = WhatAnimal;
            out_hide = HideFromOtherAnimals;
        }
        public abstract eAnimalClassification GetAnimalClassification();
        public abstract eFavouriteFood GetFavouriteFood();
        public abstract void SayHello();
    }

    [CommentAtt("Класс описания коровы")]
    public class Cow : Animal
    {
        public Cow() : base(string.Empty, string.Empty, string.Empty, false)
        {
        }
        public Cow(string country, string name, string whatanimal, bool hideFromOtherAnimals) :
            base(country, name, whatanimal, hideFromOtherAnimals)
        {
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Plants;
        }
        public override eAnimalClassification GetAnimalClassification()
        {
            return eAnimalClassification.Herbivores;
        }

        public override void SayHello()
        {
            Console.WriteLine("Moo\n");
        }
    }

    [CommentAtt("Класс описания льва")]
    public class Lion : Animal
    {
        public Lion() : base(string.Empty, string.Empty, string.Empty, false)
        {
        }
        public Lion(string country, string name, string whatanimal, bool hideFromOtherAnimals) :
            base(country, name, whatanimal, hideFromOtherAnimals)
        {
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Meat;
        }
        public override eAnimalClassification GetAnimalClassification()
        {
            return eAnimalClassification.Carnivores;
        }

        public override void SayHello()
        {
            Console.WriteLine("Roar\n");
        }
    }

    [CommentAtt("Класс описания свиньи")]
    public class Pig : Animal
    {
        public Pig() : base(string.Empty, string.Empty, string.Empty, false)
        {
        }
        public Pig(string country, string name, string whatanimal, bool hideFromOtherAnimals) :
            base(country, name, whatanimal, hideFromOtherAnimals)
        {
        }

        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Everything;
        }
        public override eAnimalClassification GetAnimalClassification()
        {
            return eAnimalClassification.Omnivores;
        }

        public override void SayHello()
        {
            Console.WriteLine("Oink\n");
        }
    }
}