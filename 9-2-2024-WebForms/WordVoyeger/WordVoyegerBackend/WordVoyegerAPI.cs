using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WordVoyegerBackend {
    public sealed class WordVoyegerAPI {

        SqlConnection connection;
        private static WordVoyegerAPI instance;
        private static object locker = new object();

        private WordVoyegerAPI() {
            String connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=WordVoyager;Trusted_Connection=true";
            connection = new SqlConnection(connectionString);
            connection.Open(); 
            SetConnection(connection);
        }

        public static WordVoyegerAPI GetInstance() {
            if(instance == null) {
                lock(locker) {
                    if(instance == null) {
                        instance = new WordVoyegerAPI();
                    }
                }
            } 
            return instance; 
        }

        public void SetConnection(SqlConnection connection) {
            this.connection = connection;
        }

        private string GetPasswordHash(string password) {
            using (SHA256 sha256Hash = SHA256.Create()) {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool SignUp(String userName, String email, String password) {
            try {
                Console.WriteLine(userName+ " " + email + " "+password);
                using (SqlCommand command = new SqlCommand("INSERT INTO [User] (Username, Email, PasswordHash, RegistrationDate) VALUES (@Username, @Email, @PasswordHash, @RegistrationDate)", connection)) {
                    command.Parameters.AddWithValue("@Username", userName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", GetPasswordHash(password));
                    command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0) {
                        return true;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return false;
        }

        public bool SignIn(String email,String password,out User user) {
            user = null;
            try {
                using (SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email AND PasswordHash = @PasswordHash", connection)) {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", GetPasswordHash(password));
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            user = new User {
                                id = (int)reader["UserId"],
                                name = (string)reader["Username"],
                                email = (string)reader["Email"]
                            };
                            return true;
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return false;
        }

        public List<Article> FetchArticlesByCategoryId(int categoryId) {
            Dictionary<int, string> tags = new Dictionary<int, string>();
            List<Article> articles = new List<Article>();
            using (SqlCommand command = new SqlCommand("FetchArticlesByCategoryId", connection)) {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", categoryId); 
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Article article = new Article();
                        article.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        article.Title = reader.GetString(reader.GetOrdinal("Title"));
                        article.content = reader.GetString(reader.GetOrdinal("content"));
                        article.publishedDate = reader.GetDateTime(reader.GetOrdinal("publishedDate"));
                        article.lastUpdatedDate = reader.GetDateTime(reader.GetOrdinal("lastUpdatedDate"));
                        article.authorName = reader.GetString(reader.GetOrdinal("authorName"));
                        article.authorEmail = reader.GetString(reader.GetOrdinal("authorEmail"));
                        article.categoryId = reader.GetInt32(reader.GetOrdinal("categoryId"));
                        articles.Add(article);
                    }
                }
                foreach(var article in articles) {
                    article.tags = FetchTagsByArticleId(article.Id, tags);
                }
            }
            return articles;
        }

        private List<string> FetchTagsByArticleId(int articleId, Dictionary<int, string> tagDictionary) {
            List<string> tags = new List<string>();
            using (SqlCommand command = new SqlCommand("SELECT TagId FROM ArticleTag WHERE ArticleId = @ArticleId", connection)) {
                command.Parameters.AddWithValue("@ArticleId", articleId);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        int tagId = reader.GetInt32(reader.GetOrdinal("TagId"));
                        if (tagDictionary.ContainsKey(tagId)) {
                            string tagName = tagDictionary[tagId];
                            tags.Add(tagName);
                        }
                    }
                }
            }
            return tags;
        }

        public List<Category> FetchCategories() {
            List<Category> categories = new List<Category>();
            string query = "SELECT CategoryId, Name, Description FROM Category";
            using (SqlCommand command = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Category category = new Category();
                        category.id = reader.GetInt32(0);
                        category.name = reader.GetString(1);
                        category.description = reader.GetString(2);
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public List<Comment> FetchCommentsByArticleId(int articleId) {
            List<Comment> comments = new List<Comment>();
            using (SqlCommand command = new SqlCommand("FetchCommentsByArticleId", connection)) {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ArticleId", articleId);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Comment comment = new Comment();
                        comment.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        comment.content = reader.GetString(reader.GetOrdinal("content"));
                        comment.createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt"));
                        comment.userName = reader.GetString(reader.GetOrdinal("userName"));
                        comment.userEmail = reader.GetString(reader.GetOrdinal("userEmail"));
                        comment.userId = reader.GetInt32(reader.GetOrdinal("userId"));
                        comments.Add(comment);
                    }
                }
            }
            return comments;
        }   

        public bool AddComment(int articleId,Comment comment) {
            try {
                string insertCommentQuery = "INSERT INTO Comment (ArticleId, UserId, Content, CommentDate) VALUES (@ArticleId, @UserId, @Content, @CommentDate)";
                using (SqlCommand insertCommentCommand = new SqlCommand(insertCommentQuery, connection)) {
                    insertCommentCommand.Parameters.AddWithValue("@ArticleId", articleId);
                    insertCommentCommand.Parameters.AddWithValue("@UserId", comment.userId);
                    insertCommentCommand.Parameters.AddWithValue("@Content", comment.content);
                    insertCommentCommand.Parameters.AddWithValue("@CommentDate", DateTime.Now);
                    int affected = insertCommentCommand.ExecuteNonQuery();
                    if(affected > 0) {
                        return true;
                    }
                }
                return true;
            } catch (Exception) { }
            return false;
        }

        public Dictionary<int,String> FetchAllTags() {
            Dictionary<int,string> dict = new Dictionary<int, string>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Tag", connection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Tag tag = new Tag();
                        tag.TagId = reader.GetInt32(reader.GetOrdinal("TagId"));
                        tag.Name = reader.GetString(reader.GetOrdinal("Name"));
                        dict[tag.TagId] = tag.Name;
                    }
                }
            }
            return dict;
        }

    }
}
