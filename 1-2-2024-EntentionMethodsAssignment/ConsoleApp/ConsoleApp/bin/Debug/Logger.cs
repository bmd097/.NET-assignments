using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    /// <summary>
    /// This class is used for Logging purposes.
    /// </summary>
    partial class Logger {
        /// <summary>
        /// Before any Insertion print this log
        /// </summary>
        /// <param name="message">This is the message to display in log.</param>
        partial void LogBeforeInsertion(String message);
        /// <summary>
        /// After any Insertion print this log
        /// </summary>
        /// <param name="message">This is the message to display in log.</param>
        partial void LogAfterInsertion(String message);
        /// <summary>
        /// Before any Deletion print this log
        /// </summary>
        /// <param name="message">This is the message to display in log.</param>
        partial void LogBeforeDeletion(String message);

        partial void LogAfterInsertion(String message) {
            Console.WriteLine(message);
        }

        public void Run() {
            LogBeforeInsertion(null);
            LogAfterInsertion("Inserted a row!");
            LogBeforeDeletion(null);
        }
    }

}
