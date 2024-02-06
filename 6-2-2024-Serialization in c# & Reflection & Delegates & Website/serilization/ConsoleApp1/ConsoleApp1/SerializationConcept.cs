using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1 {
    public class SerializationConcept {

        public void DemonstrateBinarySerialization() {
            // Binary Formatter
            Person mohan = new Person {
                name = "Mohan",
                age = 23,
                createdAt = DateTime.Now,
                email = "biswamohan_dwari@",
                isMale = true,
            };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("mohan.bin", FileMode.Create)) {
              formatter.Serialize(stream, mohan);
            }
            Thread.Sleep(2000);
            using (FileStream stream = new FileStream("mohan.bin", FileMode.Open)) {
                Person deserializedPerson = (Person)formatter.Deserialize(stream);
                Console.WriteLine($"Name: {deserializedPerson.name}, Age: {deserializedPerson.age}");
            }
        }

        public void DemonstrateXMLSerialization() {
            // XML Serialization
            Person akshara = new Person {
                   name = "Akshara",
                   age = 23,
                   createdAt = DateTime.Now,
                   email = "akshara@",
                   isMale = false,
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream stream = new FileStream("akshara.xml", FileMode.Create)) {
                serializer.Serialize(stream, akshara);
            }
            Thread.Sleep(2000);
            // Deserialization
            using (FileStream stream = new FileStream("akshara.xml", FileMode.Open)) {
                Person deserializedPerson = (Person)serializer.Deserialize(stream);
                Console.WriteLine($"Name: {deserializedPerson.name}, Age: {deserializedPerson.age}");
            }
        }

    }
}
