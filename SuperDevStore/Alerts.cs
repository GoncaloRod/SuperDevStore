using System.Collections.Generic;

namespace SuperDevStore
{
    public class Alerts
    {
        public static List<string> successMessages = new List<string>();

        public static List<string> errorMessages = new List<string>();

        public static void ClearMessages()
        {
            successMessages.Clear();
            errorMessages.Clear();
        }
    }
}