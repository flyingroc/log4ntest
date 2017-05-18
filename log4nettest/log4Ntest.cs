using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace log4nettest
{
    public partial class log4Ntest : Form
    {
        public log4Ntest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
            if (log.IsDebugEnabled)
            {
                log.Debug("hello");
            }
            */
            LogHelper.WriteLog(string.Format("当前的时间{0}", DateTime.Now.ToString()));
        }
    }
}
