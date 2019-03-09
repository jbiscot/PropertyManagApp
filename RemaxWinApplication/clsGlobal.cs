using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace RemaxWinApplication
{
    static class clsGlobal
    {
        public static int EmpAccessLevel;
        public static int EmpLoggedRef;

        public static OleDbConnection myCon;
        public static DataSet mySet;

        public static OleDbCommand myCmdEmployee;
        public static OleDbDataReader myReaderEmployee;
        public static DataTable tbEmployees;
        public static OleDbDataAdapter adpEmployees;

        public static OleDbCommand myCmdProperty;
        public static OleDbDataReader myReaderProperty;
        public static DataTable tbProperties;
        public static OleDbDataAdapter adpProperties;

        public static OleDbCommand myCmdClient;
        public static OleDbDataReader myReaderClient;
        public static DataTable tbClients;
        public static OleDbDataAdapter adpClients;
    }
}
