using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace Lab6th
{
    internal class Program
    {
        static void Main()
        {
            // Create an object and assign values
            Event myEvent = new Event
            {
                EventNumber = 1,
                Location = "Calgary"
            };

            // Serialize the object to a file
            SerializeToFile(myEvent, "event.txt");

            // Deserialize the object from the file and display values
            Event deserializedEvent = DeserializeFromFile("event.txt");
            Console.WriteLine(deserializedEvent.EventNumber);
            Console.WriteLine(deserializedEvent.Location);

            // Write "Hackathon" to the file and read first, middle, and last characters
            ReadFromFile("event.txt", "Hackathon");
        }


        static void SerializeToFile(Event obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filePath, json);
        }

        static Event DeserializeFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Event>(json);
        }

        static void ReadFromFile(string filePath, string word)
        {
            // Write the initial content
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(word);
                writer.Write("Tech Competition");
            }

            // Display the entire content after appending
            Console.WriteLine($"In Word: {File.ReadAllText(filePath)}");

            // Using FileStream to demonstrate the Seek operation
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    // Read the first character
                    fileStream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine($"The First Character is: \"{Convert.ToChar(reader.Read())}\"");

                    // Read the middle character
                    long middlePosition = fileStream.Length / 2;
                    fileStream.Seek(middlePosition, SeekOrigin.Begin);
                    Console.WriteLine($"The Middle Character is: \"{Convert.ToChar(reader.Read())}\"");

                    // Read the last character
                    fileStream.Seek(-1, SeekOrigin.End);
                    Console.WriteLine($"The Last Character is: \"{Convert.ToChar(reader.Read())}\"");
                }
            }
        }

    }
}

   


