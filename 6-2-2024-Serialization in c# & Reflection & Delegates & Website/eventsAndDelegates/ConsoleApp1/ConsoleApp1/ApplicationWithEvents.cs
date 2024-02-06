using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public class ApplicationWithEvents {

        public delegate void OnClickCallback(object sender, EventArgs e);
        public delegate void OnDblClickCallback(object sender, EventArgs e);

        public event OnClickCallback OnClickEvent;
        public event OnDblClickCallback OnDblClickEvent;

        public void Run() {
            Thread.Sleep(2000);
            OnClickEvent("Application", EventArgs.Empty);
            Thread.Sleep(2000);
            OnClickEvent("Application", EventArgs.Empty);
            Thread.Sleep(2000);
            OnDblClickEvent("Application-1", EventArgs.Empty);
            Thread.Sleep(2000);
            OnDblClickEvent("Application-1", EventArgs.Empty);
        }

    }
}
