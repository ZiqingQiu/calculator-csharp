using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Name: Tom Tsiliopoulos
 * Date: August 8, 2017
 * Description: This is the SplashForm class
 * Version: 0.4 - Created a Public Property as an Alias to Program.calculatorForm
 */

namespace COMP123_S2017_Lesson12B2
{
    public partial class SplashForm : Form
    {
        // PUBLIC PROPERTIES
        public CalculatorForm CalculatorForm {

            get
            {
                return Program.calculatorForm;
            }

        }

        // CONSTRUCTORS ++++++++++++++++++++++++++++++++++++++++++++++++

        /// <summary>
        /// This is the main constructor for the SplashForm
        /// </summary>
        public SplashForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the "Tick"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashFormTimer_Tick(object sender, EventArgs e)
        {

            this.CalculatorForm.Show();

            this.Hide();

            SplashFormTimer.Enabled = false; // turn timer off
        }
    }
}
