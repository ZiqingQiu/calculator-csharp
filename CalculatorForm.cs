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
        /// Handle digits 1-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: all do nothing
            //ResultTextBox:
            //      1-9 attach string, if 1 element and 0, replace it
            //      0 if not first attach, otherwise keep "0"
            //      . if not first attach, otherwise attach "0."

            //logicview: nothing

        }

        /// <summary>
        /// Handle digit 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: all do nothing
            //ResultTextBox:
            //      0 if not first attach, else keep "0"

            //logicview: nothing

        }

        /// <summary>
        /// Handle decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecimalButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: all do nothing
            //ResultTextBox:
            //      . if not first attach, else attach "0."

            //logicview: nothing

        }
        /// <summary>
        /// Handle operators +-X/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: 
            //  if previous is digit, then attach the operator
            //  if previous is operator, then replace the operator  

            //ResultTextBox: show latest result

            //logicview: calculate latest result
        }


        /// <summary>
        /// Handle Clear
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: clear string
            //ResultTextBox: show 0
            //logicview: result set to 0
        }


        /// <summary>
        /// Handle BackSpace
        /// </summary>
        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: do nothing
            //ResultTextBox: clear last digit, if empty show 0
            //logicview: do nothing
        }

        /// <summary>
        /// Handle Equal
        /// </summary>
        private void EqualButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: clear history
            //ResultTextBox: show latest result
            //logicview
            //  if previous is number, do result lastoper curreninput
            //  if previous is operator, do result lastoper result
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
