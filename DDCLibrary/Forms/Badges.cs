using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDCLibrary
{
    public partial class Badges : Form
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Degault constructor
        /// </summary>
        public Badges()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retunr to previous screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtrn_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Home form2 = new Home();
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to shut down the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult promptShutDown = MessageBox.Show("shutting down...", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (promptShutDown == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
//----------------------------------------------------------------------------------------ooo000EndOfFile000ooo--------------------------------------------------------------------------------------