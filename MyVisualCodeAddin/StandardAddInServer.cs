using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Inventor;

namespace Hjalte.OccurrenceBundler
{
    [GuidAttribute("5bcef23e-e85e-4e71-b4bf-27be93e96a11"), ComVisible(true)]
    public class StandardAddInServer : ApplicationAddInServer
    {
        //https://forums.autodesk.com/t5/inventor-ideas/bundle-multiple-instances-of-same-part-in-assembly-tree/idi-p/5643016

        private Application _inventor;
        public void Activate(ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            _inventor = addInSiteObject.Application;
            System.Windows.Forms.MessageBox.Show("Addin Loaded");
        }

        public void Deactivate()
        {
            // Release objects.
            Marshal.ReleaseComObject(_inventor);
            _inventor = null;

            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }
        public object Automation
        {
            get
            {
                // TODO: Add ApplicationAddInServer.Automation getter implementation
                return null;
            }
        }
    }
}