using Grand.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.ATest
{
    public class ATestPlugin : BasePlugin
    {
        #region Methods
        public override async Task Install()
        {
            await base.Install();
        }

        public override Task Uninstall()
        {
            return base.Uninstall();
        }
   
        #endregion
    }

}
