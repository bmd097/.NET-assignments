using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WordVoyegerBackend;

namespace WordVoyeger {
    public sealed class AuthDetails {

        private static AuthDetails authDetails;
        public bool viewLogInView {  get; set; }
        public User user;
        public delegate void CallbackWhenLoggedIn();
        public event CallbackWhenLoggedIn OnLoggedIn;
        private WordVoyegerAPI api;
        public bool isLoggedIn {  get; set; } 
        private static String connectionString = "Server=EPINHYDW098E\\SQLEXPRESS;Database=WordVoyager;Trusted_Connection=true";

        private static object authDetailsLock = new object();

        private AuthDetails() {
            api = WordVoyegerAPI.GetInstance();
            viewLogInView = true;
            isLoggedIn = false;
        } 

        public static AuthDetails GetInstance() { 
            if(authDetails == null) {
                lock (authDetailsLock) {
                    if(authDetails == null) 
                        authDetails = new AuthDetails();
                }  
            }
            return authDetails;
        }

        public bool LogIn(string email, string password) {
            if(api.SignIn(email, password,out user)) {
                AppState.GetInstance().Init();
                isLoggedIn = true;
                OnLoggedIn();
                return true;
            }
            return false;
        }

        public bool SignUp(String name,String email,String password) {
            return api.SignUp(name, email, password);
        }

        public void Logout() {
            user = null;
            isLoggedIn =false;
        }

    }
}