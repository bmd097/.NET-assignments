using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    public class Program {

        public static Action<object> log = Console.WriteLine;

        public static String[] ShowTheMenuAndTakeInput() {
            log("************** MENU ********************");
            log("***** Q> What do you want? [Comments]");
            log("***** 1. INSERT");
            log("***** 2. SHOW ALL");
            log("***** 3. SELECT WITH ID");
            log("***** 4. UPDATE");
            log("***** 5. REMOVE");
            log("***** 6. Exit");
            log("**** Please provide your response! *****");
            StringBuilder sb = new StringBuilder();
            sb.Append(Console.ReadLine()+"$");
            if (sb.ToString().StartsWith("1") ) {
                log("Ok! Insert the comment!");
                sb.Append(Console.ReadLine());
            } else if (sb.ToString().StartsWith("2")) {
                log("Ok!");
            } else if (sb.ToString().StartsWith("3")) {
                log("Ok! Tell the Id");
                sb.Append(Console.ReadLine());
            } else if (sb.ToString().StartsWith("4")) {
                log("Ok! Tell the id,next line tell the comment");
                sb.Append(Console.ReadLine()+ "$");
                sb.Append(Console.ReadLine());
            } else if (sb.ToString().StartsWith("5")) {
                log("Ok! Tell the Id");
                sb.Append(Console.ReadLine());
            }
            log("");
            char[] chars = "$".ToString().ToCharArray();
            return sb.ToString().Split(chars);
        }

        public static void Main(string[] args) {
            try {
                Action<object> log = Console.WriteLine;
                String connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=WordVoyager;Trusted_Connection=true";
                String queriesPath = "C:\\Users\\biswamohan_dwari\\Desktop\\.NET-assignments\\7-2-2024-ADONET\\ConsoleApp\\ConsoleApp\\queries";
                log("Tell Varient :: DataReaderVarient 1 | DataRowVarient 2");
                int varient = Convert.ToInt32(Console.ReadLine());
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    var queries = new QueriesCollector(queriesPath).Collect();
                    TableCreator.GetInstance()
                        .Connection(connection)
                        .Queries(queries)
                        .StartCreationProcess();
                    while (true) {
                        try {
                            var results = ShowTheMenuAndTakeInput();
                            if (varient == 1)
                                ActionDictionaryProvider.actionMapDataReaderVarient[results[0].Trim()](results, connection);
                            else ActionDictionaryProvider.actionMapDataRowVarient[results[0].Trim()](results, connection);
                        } catch (Exception e) {
                            log(e.Message);
                        }
                    }
                }
            } catch (Exception ex) {
                log(ex.Message);
                Console.Read();
            }
        }
    }
}
