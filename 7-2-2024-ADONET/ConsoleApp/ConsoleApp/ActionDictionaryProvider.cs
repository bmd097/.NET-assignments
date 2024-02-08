using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    public class ActionDictionaryProvider {

        public static Action<object> log = Console.WriteLine;

        public static readonly Dictionary<string, Action<string[], SqlConnection>> actionMapDataReaderVarient =
                    new Dictionary<string, Action<string[], SqlConnection>>() {
            {
                "1",
                (result,connection) => {
                    // INSERT
                    string content = result[1].Trim();
                    DateTime commentDate = DateTime.Now;
                    string insertQuery = "INSERT INTO Comment (ArticleId, UserId, Content, CommentDate) VALUES (@ArticleId, @UserId, @Content, @CommentDate)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection)) {
                        command.Parameters.AddWithValue("@ArticleId", 1);
                        command.Parameters.AddWithValue("@UserId", 1);
                        command.Parameters.AddWithValue("@Content", content);
                        command.Parameters.AddWithValue("@CommentDate", commentDate);
                        var res = command.ExecuteNonQuery();
                        if (res == 1) log("Added the comment!");
                        else log("Nope not added!");
                        log("");
                    }
                }
            },
            {
                "2",
                (result,connection) => {
                    // SHOW ALL
                    string selectQuery = "SELECT * FROM Comment";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection)) {
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                int commentId = reader.GetInt32(0);
                                int articleId = reader.GetInt32(1);
                                int userId = reader.GetInt32(2);
                                string content = reader.GetString(3);
                                DateTime commentDate = reader.GetDateTime(4);
                                Console.WriteLine($"CommentId: {commentId}, ArticleId: {articleId}, UserId: {userId}, Content: {content}, CommentDate: {commentDate}");
                            }
                            log("");
                        }
                    }
                }
            },
            {
                "3",
                (result,connection) => {
                    // SELECT WITH ID
                    int commentId = Convert.ToInt32(result[1]);
                    string selectQuery = "SELECT * FROM Comment WHERE CommentId = @CommentId";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection)) {
                        command.Parameters.AddWithValue("@CommentId", commentId);
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                int articleId = reader.GetInt32(1);
                                int userId = reader.GetInt32(2);
                                string content = reader.GetString(3);
                                DateTime commentDate = reader.GetDateTime(4);
                                Console.WriteLine($"CommentId: {commentId}, ArticleId: {articleId}, UserId: {userId}, Content: {content}, CommentDate: {commentDate}");
                            }
                            log("");
                        }
                    }
                }
            },
            {
                "4",
                (result,connection) => {
                    // UPDATE
                    int commentId = Convert.ToInt32(result[1]);
                    string content = result[2];
                    string updateQuery = "UPDATE Comment SET Content = @Content WHERE CommentId = @CommentId";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection)) {
                        command.Parameters.AddWithValue("@Content", content);
                        command.Parameters.AddWithValue("@CommentId", commentId);
                        var res = command.ExecuteNonQuery();
                        if (res == 1) log("Added the comment!");
                        else log("Nope not added!");
                        log("");
                    }
                }
            },
            {
                "5",
                (result,connection) => {
                    // REMOVE
                    int commentId = Convert.ToInt32(result[1]);
                    string deleteQuery = "DELETE FROM Comment WHERE CommentId = @CommentId";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection)) {
                        command.Parameters.AddWithValue("@CommentId", commentId);
                        var res = command.ExecuteNonQuery();
                        if (res == 1) log("Added the comment!");
                        else log("Nope not added!");
                        log("");
                    }
                }
            },
            {
                "6",
                (result,connection) => {
                    log("Turning off System Now!");
                    Environment.Exit(0);
                }
            }
        };

        public static readonly Dictionary<string, Action<string[], SqlConnection>> actionMapDataRowVarient =
                    new Dictionary<string, Action<string[], SqlConnection>>() {
            {
                "1",
                (result,connection) => {
                    // INSERT
                    string content = result[1].Trim();
                    DateTime commentDate = DateTime.Now;
                    string insertQuery = "INSERT INTO Comment (ArticleId, UserId, Content, CommentDate) VALUES (@ArticleId, @UserId, @Content, @CommentDate)";
                    using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                        adapter.InsertCommand = new SqlCommand(insertQuery, connection);
                        adapter.InsertCommand.Parameters.AddWithValue("@ArticleId", 1);
                        adapter.InsertCommand.Parameters.AddWithValue("@UserId", 1);
                        adapter.InsertCommand.Parameters.AddWithValue("@Content", content);
                        adapter.InsertCommand.Parameters.AddWithValue("@CommentDate", commentDate);
                        var res = adapter.InsertCommand.ExecuteNonQuery();
                        if (res == 1) log("Added the comment!");
                        else log("Nope not added!");
                        log("");
                    }
                }
            },
            {
                "2",
                (result,connection) => {
                    // SHOW ALL
                    string selectQuery = "SELECT * FROM Comment";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection)) {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        foreach (DataRow row in ds.Tables[0].Rows) {
                            int commentId = Convert.ToInt32(row["CommentId"]);
                            int articleId = Convert.ToInt32(row["ArticleId"]);
                            int userId = Convert.ToInt32(row["UserId"]);
                            string content = row["Content"].ToString();
                            DateTime commentDate = Convert.ToDateTime(row["CommentDate"]);
                            Console.WriteLine($"CommentId: {commentId}, ArticleId: {articleId}, UserId: {userId}, Content: {content}, CommentDate: {commentDate}");
                        }
                        log("");
                    }
                }
            },
            {
                "3",
                (result,connection) => {
                    // SELECT WITH ID
                    int commentId = Convert.ToInt32(result[1]);
                    string selectQuery = "SELECT * FROM Comment WHERE CommentId = @CommentId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                        adapter.SelectCommand = new SqlCommand(selectQuery, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@CommentId", commentId);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        foreach (DataRow row in ds.Tables[0].Rows) {
                            int articleId = Convert.ToInt32(row["ArticleId"]);
                            int userId = Convert.ToInt32(row["UserId"]);
                            string content = row["Content"].ToString();
                            DateTime commentDate = Convert.ToDateTime(row["CommentDate"]);
                            Console.WriteLine($"CommentId: {commentId}, ArticleId: {articleId}, UserId: {userId}, Content: {content}, CommentDate: {commentDate}");
                        }
                        log("");
                    }
                    }
                },
            {
                "4",
                (result,connection) => {
                    // UPDATE
                    int commentId = Convert.ToInt32(result[1]);
                    string content = result[2];
                    string updateQuery = "UPDATE Comment SET Content = @Content WHERE CommentId = @CommentId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                        adapter.UpdateCommand = new SqlCommand(updateQuery, connection);
                        adapter.UpdateCommand.Parameters.AddWithValue("@Content", content);
                        adapter.UpdateCommand.Parameters.AddWithValue("@CommentId", commentId);
                        var res = adapter.UpdateCommand.ExecuteNonQuery();
                        if (res == 1) log("Added the comment!");
                        else log("Nope not added!");
                        log("");
                    }
                }
            },
            {
                "5",
                (result,connection) => {
                    // REMOVE
                    int commentId = Convert.ToInt32(result[1]);
                    string deleteQuery = "DELETE FROM Comment WHERE CommentId = @CommentId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                        adapter.DeleteCommand = new SqlCommand(deleteQuery, connection);
                        adapter.DeleteCommand.Parameters.AddWithValue("@CommentId", commentId);
                        var res = adapter.DeleteCommand.ExecuteNonQuery();
                        if (res == 1) log("Added the comment!");
                        else log("Nope not added!");
                        log("");
                    }
                }
            },
            {
                "6",
                (result,connection) => {
                    log("Turning off System Now!");
                    Environment.Exit(0);
                }
            }
        };

    }
}
