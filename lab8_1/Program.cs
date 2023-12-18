using ClassLibrary1;
using System.Xml.Serialization;

namespace SerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Cow("Russia", "Burka", "A friendly cow", false);

            // Сериализация объекта Animal в файл "animal.xml"
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\animal.xml");
            Console.WriteLine("filePath " + filePath);
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, animal);
            }
            Console.WriteLine("Animal object has been serialized to animal.xml");

            // Для просмотра файла "animal.xml" 
            string xmlContent = File.ReadAllText(filePath);
            Console.WriteLine("Contents of animal.xml:");
            Console.WriteLine(xmlContent);
            /*
            using (TextReader reader = new StreamReader(filePath))
            {
                Animal deserializedAnimal = (Animal)serializer.Deserialize(reader);

                Console.WriteLine($"\nDeserialized Animal Object:\nName: {deserializedAnimal.Name}\nCountry: {deserializedAnimal.Country}\nDescription: {deserializedAnimal.WhatAnimal}\nHideFromOtherAnimals: {deserializedAnimal.HideFromOtherAnimals}\n");
                deserializedAnimal.SayHello();
                Console.WriteLine($"Favorite Food: {deserializedAnimal.GetFavouriteFood()}");
            }
            */
        }
    }
}