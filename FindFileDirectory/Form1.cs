using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFileDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\", "*.jpg");

            System.Diagnostics.Debug.Print(files[0]);

        }
    }
}
