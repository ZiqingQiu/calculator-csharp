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
        List<String> _inputRecord;   //record every input from calculator, show in HistoryText
        List<String> _currentInput;   //record current input digits, show in ResultText
        Double latestResult;  //record latestResult before currentInput followed by a operator

        // PUBLIC PROPERTIES

        // CONSTRUCTORS

        /// <summary>
        /// This is the main constructor for the CalculatorForm class
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();

            _inputRecord = new List<String>();
            _currentInput = new List<String>();
            latestResult = 0;

        }

        /// <summary>
        /// This is the method show HistoryText
        /// </summary>
        private void ShowHistoryText()
        {
            HistoryTextBox.Text = "";
            foreach (String inputS in _inputRecord)
            {
                HistoryTextBox.Text += inputS;
            }
        }

        /// <summary>
        /// This is the method show ResultText
        /// </summary>
        private void ShowResultText()
        {
            ResultTextBox.Text = "";
            foreach (String inputS in _currentInput)
            {
                ResultTextBox.Text += inputS;
            }
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
            Button calculatorButton = sender as Button; // downcasting

            //HistoryTextBox: all do nothing

            //ResultTextBox:
            //      1-9 attach string, if 1 element and 0, replace it
            if ((_currentInput.Count == 1) && (_currentInput[0] == "0"))
            {
                _currentInput[0] = calculatorButton.Text;
            }
            else
            {
                _currentInput.Add(calculatorButton.Text);
            }
            ShowResultText();
            //logicview: nothing

        }

        /// <summary>
        /// Handle digit 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            Button calculatorButton = sender as Button; // downcasting
            //HistoryTextBox: all do nothing
            //ResultTextBox:
            //      0 if not first attach, else keep "0"
            if ((_currentInput.Count == 1) && (_currentInput[0] == "0"))
            {
                _currentInput[0] = calculatorButton.Text;
            }
            else
            {
                _currentInput.Add(calculatorButton.Text);
            }
            ShowResultText();
            //logicview: nothing

        }

        /// <summary>
        /// Handle decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecimalButton_Click(object sender, EventArgs e)
        {
            Button calculatorButton = sender as Button; // downcasting
            //HistoryTextBox: all do nothing
            //ResultTextBox:
            //      . if not first attach, else attach "0."
            if (_currentInput.Count == 0)
            {
                _currentInput.Add("0");
                _currentInput.Add(".");
            }
            else
            {
                _currentInput.Add(calculatorButton.Text);
            }
            ShowResultText();
            //logicview: nothing

        }
        /// <summary>
        /// Handle operators +-X/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button OperatorButton = sender as Button; // downcasting
            //HistoryTextBox: 
            //  if previous is digit, then attach the operator
            //  if previous is operator, then replace the operator  
            //  if previous is null, then add 0 operator 
            if (_inputRecord.Count == 0) //null
            {
                _inputRecord.Add("0 ");
                _inputRecord.Add(OperatorButton.Text + " ");
            }
            else if (_inputRecord[_inputRecord.Count - 1] == "")  //last input is operator
            {
            }


            //ResultTextBox: clear result text, show latest result

            //logicview: calculate latest result
        }


        /// <summary>
        /// Handle Clear
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: clear string
            _inputRecord.Clear();

            //ResultTextBox: show 0
            _currentInput.Clear();
            latestResult = 0;
            _currentInput.Add(Convert.ToString(latestResult));
            ShowResultText();
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
        /// This is the event handler for the "Load" event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            _inputRecord.Clear();
            latestResult = 0;
            _currentInput.Add(Convert.ToString(latestResult));
            ShowResultText();
        }
    }
}
