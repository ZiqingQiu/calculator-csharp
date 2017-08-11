using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Name: Tom Tsiliopoulos
 * Date: August 3, 2017
 * Description: Calculator Demo Project
 * Version: 1.2 - Fixed bug in CalculatorButton_Click 
 */

namespace COMP123_S2017_Lesson12B2
{
    public partial class CalculatorForm : Form
    {
        // PRIVATE INSTANCE VARIABLES


        // PUBLIC PROPERTIES



        // CONSTRUCTORS

        /// <summary>
        /// This is the main constructor for the CalculatorForm class
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is an event handler for the "FormClosing" event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Handle digits 0-9 and decimals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
  
        }

        /// <summary>
        /// Handle operators add, substract, times, divide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperatorButton_Click(object sender, EventArgs e)
        {



        }


        /// <summary>
        /// Handle Clear, backspace
        /// </summary>
        private void InputChangeButton_Click()
        { 
        }


        /// <summary>
        /// This is the private _clear method. It resets / clears the calculator.
        /// </summary>
        private void _clear()
        {
            ResultTextBox.Text = "0";
        }

        /// <summary>
        /// This is the event handler for the "Load" event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            this._clear();
        }
    }
}
