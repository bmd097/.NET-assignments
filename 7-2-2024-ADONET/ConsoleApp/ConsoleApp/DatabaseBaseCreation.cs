using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    public sealed class TableCreator {
        private static object lockPoint = new object();
        private static TableCreator databaseCreation = null;
        private IEnumerable<string> queries;
        private SqlConnection connection;
        private TableCreator() {}
        public static TableCreator GetInstance() {
            if (databaseCreation == null) {
                lock (lockPoint) {
                    if(databaseCreation == null) {
                        databaseCreation = new TableCreator();
                    }
                }
            } 
            return databaseCreation;
        }
        public TableCreator Connection(SqlConnection connection) {
            this.connection = connection;
            return this;
        }
        public TableCreator Queries(IEnumerable<string> queries) {
            this.queries = queries;
            return this;
        }
        public void StartCreationProcess() {
            foreach (var query in queries) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    try {
                        command.ExecuteNonQuery();
                    } catch (SqlException ex) {
                        // Check if the error is due to the table already existing
                        if (ex.Number == 2714 || ex.Number == 2716) {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                }
            }
        }
    }
}
