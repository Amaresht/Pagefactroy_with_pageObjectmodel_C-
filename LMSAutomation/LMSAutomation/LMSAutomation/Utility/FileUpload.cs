using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSAutomation.Utility
{
    class FileUpload
    {
        public static void UploadFile(string image) {
            System.Threading.Thread.Sleep(3000);
            SendKeys.SendWait(image);
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait(@"{Enter}");
        }
    }
}
