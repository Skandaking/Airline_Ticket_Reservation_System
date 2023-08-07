using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Ticket_Reservation_System
{
    class Var
    {
        /*these global variables are once declaired to prevent us from declairing them any time we want to call a method
          from the classes. this helps to reduce memory overload*/
        public static Users use = new Users();
        public static Reservations reserve = new Reservations();
        public static DatabaseConnection dataconn = new DatabaseConnection();
        public static flightSchedules fs = new flightSchedules();
        public static Passengers pass = new Passengers();
        public static Aircraft ac = new Aircraft();
        public static Email mail = new Email();
        public static Printing print = new Printing();
        public static LoadingEmail le = new LoadingEmail();
        public static ToolTip btnToolTip = new ToolTip();
        public static Login log = new Login();
        public static Main_Form mf = new Main_Form();
        public static Reservation_View rv = new Reservation_View();
        public static Loading_Email Email = new Loading_Email();
        public static Help_details help = new Help_details();
        public static Help_Form hf = new Help_Form();
    }
}
