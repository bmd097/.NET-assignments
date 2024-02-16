using ArticleDb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleDb {
    public sealed class WordVoyagerDb {
        private static WordVoyagerDb instance;
        private static object lockObj = new object();
        private static string connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=WordVoyager;Trusted_Connection=true";
        private SqlConnection sqlConnection;
        private WordVoyagerDb() {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("connected");
        }

        public static WordVoyagerDb GetInstance() {
            if (instance == null) {
                lock (lockObj) {
                    if (instance == null) {
                        instance = new WordVoyagerDb();
                    }
                }
            }
            return instance;
        }

        public List<Article> GetArticles(int page, int limit) {
            List<Article> articles = new List<Article>();
            string query = "SELECT * FROM Article ORDER BY PublishedDate DESC OFFSET @Page ROWS FETCH NEXT @Limit ROWS ONLY";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                command.Parameters.AddWithValue("@Page", page * limit);
                command.Parameters.AddWithValue("@Limit", limit);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Article article = new Article {
                            ArticleId = Convert.ToInt32(reader["ArticleId"]),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            PublishedDate = reader["PublishedDate"].ToString(),
                            LastModifiedDate = reader["LastModifiedDate"].ToString(),
                            AuthorId = reader["AuthorId"].ToString(),
                            CategoryId = reader["CategoryId"].ToString()
                        };
                        articles.Add(article);
                    }
                }
            }
            return articles;
        }

        public List<User> GetUsers() {
            List<User> users = new List<User>();
            string query = "SELECT * FROM [User]";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        User user = new User {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString()
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public List<Article> GetArticles(string titleLike) {
            List<Article> articles = new List<Article>();
            string query = "SELECT * FROM Article WHERE Title LIKE @TitleLike";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                command.Parameters.AddWithValue("@TitleLike", $"%{titleLike}%");
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Article article = new Article {
                            ArticleId = Convert.ToInt32(reader["ArticleId"]),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            PublishedDate = reader["PublishedDate"].ToString(),
                            LastModifiedDate = reader["LastModifiedDate"].ToString(),
                            AuthorId = reader["AuthorId"].ToString(),
                            CategoryId = reader["CategoryId"].ToString()
                        };
                        articles.Add(article);
                    }
                }
            }
            return articles;
        }

        public bool AddArticle(Article article) {
            string query = "INSERT INTO Article (Title, Content, PublishedDate, LastModifiedDate, AuthorId, CategoryId) VALUES (@Title, @Content, @PublishedDate, @LastModifiedDate, @AuthorId, @CategoryId)";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                command.Parameters.AddWithValue("@Title", article.Title);
                command.Parameters.AddWithValue("@Content", article.Content);
                command.Parameters.AddWithValue("@PublishedDate", article.PublishedDate);
                command.Parameters.AddWithValue("@LastModifiedDate", article.LastModifiedDate);
                command.Parameters.AddWithValue("@AuthorId", article.AuthorId);
                command.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<Category> GetCategories() {
            List<Category> categories = new List<Category>();
            string query = "SELECT * FROM Category";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Category category = new Category {
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public Article GetArticleById(int articleId) {
            Article article = null;
            string query = "SELECT * FROM Article WHERE ArticleId = @ArticleId";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                command.Parameters.AddWithValue("@ArticleId", articleId);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        article = new Article {
                            ArticleId = Convert.ToInt32(reader["ArticleId"]),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            PublishedDate = reader["PublishedDate"].ToString(),
                            LastModifiedDate = reader["LastModifiedDate"].ToString(),
                            AuthorId = reader["AuthorId"].ToString(),
                            CategoryId = reader["CategoryId"].ToString()
                        };
                    }
                }
            }
            return article;
        }

        public bool DeleteArticleById(int articleId) {
            string query = "DELETE FROM Article WHERE ArticleId = @ArticleId";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                command.Parameters.AddWithValue("@ArticleId", articleId);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool EditArticle(Article article) {
            string query = "UPDATE Article SET Title = @Title, Content = @Content, LastModifiedDate = @LastModifiedDate, AuthorId = @AuthorId, CategoryId = @CategoryId WHERE ArticleId = @ArticleId";
            using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                command.Parameters.AddWithValue("@Title", article.Title);
                command.Parameters.AddWithValue("@Content", article.Content);
                command.Parameters.AddWithValue("@LastModifiedDate", article.LastModifiedDate);
                command.Parameters.AddWithValue("@AuthorId", article.AuthorId);
                command.Parameters.AddWithValue("@CategoryId", article.CategoryId);
                command.Parameters.AddWithValue("@ArticleId", article.ArticleId);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
