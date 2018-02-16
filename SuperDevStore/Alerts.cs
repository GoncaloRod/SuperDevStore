using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperDevStore
{
    public class Alerts
    {
        #region Singloton
        private static Alerts instance;

        public static Alerts Instance
        {
            get
            {
                if (instance == null) instance = new Alerts();

                return instance;
            }
        }
        #endregion

        public List<string> successMessages;

        public List<string> errorMessages;

        public void ClearMessages()
        {
            successMessages.Clear();
            errorMessages.Clear();
        }
    }
}