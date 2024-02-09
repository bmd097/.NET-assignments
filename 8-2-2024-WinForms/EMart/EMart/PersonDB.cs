using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EMart {
    internal class PersonDB {
        /*public List<Person> list = new List<Person> {
            new Person(1,"Mohan","mohan@","1234",DateTime.Now),
            new Person(2,"Akshara","akshara@","1234",DateTime.Now)
        };
        public Person GetPerson(String email,String password) {
            var person = list.Find(p=>p.email == email && p.password == password);
            if(person != null) 
                person.lastLogIn = DateTime.Now;
            return person;
        }*/

        private String connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=EKART;Trusted_Connection=true";
        private List<Person> persons = new List<Person>();

        public PersonDB() {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FetchPersons", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var person = new Person (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetDateTime(4)
                            );
                            persons.Add(person);
                        }
                    }
                }
            }
        }

        public Person GetPerson(String email, String password) {
            var person = persons.Find(p => p.email == email && p.password == password);
            if (person != null)
                person.lastLogIn = DateTime.Now;
            return person;
        }

    }
}
