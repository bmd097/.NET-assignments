﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1 {
    public class Program {

        static void Main(string[] args) {
            
            SerializationConcept serializationConcept = new SerializationConcept();
            serializationConcept.DemonstrateBinarySerialization();
            serializationConcept.DemonstrateXMLSerialization();

            Console.ReadLine();
        }
    }
}