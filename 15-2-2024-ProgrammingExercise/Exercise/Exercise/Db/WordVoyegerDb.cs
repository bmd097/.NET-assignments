using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Exercise.Db {
    public sealed class WordVoyegerDb {

        private static WordVoyegerDb instance;
        private static object lockObj = new object();
        private static string connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=WordVoyager;Trusted_Connection=true";

        private SqlConnection sqlConnection;
        private WordVoyegerDb() {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("connected");
        }

        public static WordVoyegerDb GetInstance() {
            if(instance == null) {
                lock(lockObj) {
                    if(instance == null) {
                        instance = new WordVoyegerDb();
                    }
                }
            }
            return instance;
        }

        public List<ArticleDTO> GetArticles(int pageNo,int limit) {
            // exec GetAllArticles @PageNumber = 2,@RowsPerPage = 3;
            List<ArticleDTO> list = new List<ArticleDTO>();
            try {
                using (SqlCommand sqlCommand = new SqlCommand("GetAllArticles",sqlConnection)) {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PageNumber", pageNo);
                    sqlCommand.Parameters.AddWithValue("@RowsPerPage", limit);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                        while (reader.Read()) {
                            ArticleDTO articleDTO = new ArticleDTO();
                            articleDTO.Title = reader.GetString(1);
                            articleDTO.ArticleId = reader.GetInt32(0);
                            articleDTO.Content = reader.GetString(2); ;
                            articleDTO.PublishedDate = reader.GetDateTime(3); ;
                            articleDTO.Category = reader.GetString(6);
                            articleDTO.Author = reader.GetString(5);
                            articleDTO.LastModifiedDate = reader.GetDateTime(4);
                            list.Add(articleDTO);
                        }
                    }
                }
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

    }
}