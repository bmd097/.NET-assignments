using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService {
    public partial class Service1 : ServiceBase {

        private Timer timer;
        private int intervalInMinutes = 5; // Set the interval in minutes
        private string emailRecipient = "bmd097@gmail.com"; // Set the recipient email address
        private string emailSubject = ".NET Time";
        private string emailSender = "bmd097@gmail.com"; // Set the sender email address
        private string emailPassword = "uferjbujhsfjwmhf"; // Set the sender email password

        public Service1() {
            InitializeComponent();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e) {
            SendEmail();
        }

        protected override void OnStart(string[] args) {
            timer = new Timer();
            timer.Interval = intervalInMinutes * 60 * 1000; // Convert minutes to milliseconds
            timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
            timer.Start();
        }

        protected override void OnStop() {
            timer.Stop();
            timer.Dispose();
        }

        private void SendEmail() {
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)) {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(emailSender, emailPassword);

                using (MailMessage mailMessage = new MailMessage(
                    emailSender, 
                    emailRecipient, 
                    emailSubject, 
                    $"{DateTime.Now.ToString()} Right now!"
                )) {
                    smtpClient.Send(mailMessage);
                }
            }
        }
        // sc create EmailService binPath= "C:\path\to\your\project\output\EmailService.exe"
        // sc create EmailService binPath = "C:\Users\biswamohan_dwari\Desktop\.NET-assignments\23-2-2024 - Windows Services\WindowsService\WindowsService\bin\Debug\WindowsService.exe"
        // sc start EmailService

        // sc delete EmailService
        // sc stop EmailService
    }
}
