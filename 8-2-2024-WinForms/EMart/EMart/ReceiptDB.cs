using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart {
    internal class ReceiptDB {

        public void SaveToDB(String details, int price) {
            String connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=EKART;Trusted_Connection=true";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[InsertIntoReceipt]", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Details", details));
                    command.Parameters.Add(new SqlParameter("@Price", price));
                    command.Parameters.Add(new SqlParameter("@CreatedAt", DateTime.Now));

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string[]> ShowAllReceipts() {
            List<string[]> strings = new List<string[]>();
            string connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=EKART;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                string query = "SELECT Id, Details, Price, CreatedAt FROM Receipt";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            int id = reader.GetInt32(0);
                            string details = reader.GetString(1);
                            int price = reader.GetInt32(2);
                            DateTime createdAt = reader.GetDateTime(3);
                            strings.Add(new string[] { id.ToString(),details.ToString(),price.ToString(),createdAt.ToString() });

                            // Assuming you want to add each record to the DataGridView
                            // dataGridViewReceipts.Rows.Add(id, details, price, createdAt);
                        }
                    }
                }
            }

            return strings;
        }


    }
}
