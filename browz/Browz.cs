using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using browz.DataModel;
using browz.Forms;

namespace browz
{
    public static class Browz
    {
        private static CollectionsDatabase _database = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartPage());

            if (_database != null)
            {
                Application.Run(new CollectionBrowser(_database));
            }
        }

        public static CollectionsDatabase Database
        {
            get { return _database; }
            set { _database = value; }
        }
    }
}
