using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EMart {

    public class ProductsDB {

        public Product this[ int index] {
            get {
                foreach( var item in products ) {
                    if (item.id == index) return item;
                }
                return null;
            }
        }

        /*
        private static List<T> DeserializeJsonArray<T>(string json) {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        private static List<T> DeserializeJsonArrayFromFile<T>(string filePath) {
            string json = File.ReadAllText(filePath);
            return DeserializeJsonArray<T>(json);
        }

        public ProductsDB() {
            string filePath = "C:\\Users\\biswamohan_dwari\\Desktop\\.NET-assignments\\8-2-2024-WinForms\\EMart\\EMart\\items.json";
            products.AddRange(DeserializeJsonArrayFromFile<Product>(filePath));
            
        }

        private List<Product> products = new List<Product>();

        */
        private String connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=EKART;Trusted_Connection=true";
        private List<Product> products = new List<Product>();


        public ProductsDB() {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FetchProducts", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var product = new Product {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                qty = reader.GetInt32(3),
                                price = reader.GetInt32(4)
                            };
                            products.Add(product);
                        }
                    }
                }
            }
        }

        public void SetQuantitiesInDB(Dictionary<int, int> productQuantities) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction()) {
                    try {
                        foreach (var kvp in productQuantities) {
                            int productId = kvp.Key;
                            int quantityToSet = kvp.Value;
                            using (SqlCommand updateCommand = new SqlCommand("UPDATE Product SET qty = @NewQuantity WHERE id = @ProductId", connection, transaction)) {
                                updateCommand.Parameters.AddWithValue("@NewQuantity", quantityToSet);
                                updateCommand.Parameters.AddWithValue("@ProductId", productId);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    } catch (Exception ex) {
                        transaction.Rollback();
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
