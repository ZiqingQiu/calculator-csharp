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
        string _lastOperator;
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

        private bool IsLastInputOperator()
        {
            if (_inputRecord.Count == 0)
            {
                return false;
            }

            for(int i = (_inputRecord.Count - 1); i > 0; i--)
            {
                if (_inputRecord[i] == "(" || _inputRecord[i] == ")")
                {
                    continue;
                }
                else if (_inputRecord[i] == "+" || _inputRecord[i] == "-" || _inputRecord[i] == "x" || _inputRecord[i] == "÷")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool IsCurrentInputHasDecimal()
        {
            if (_currentInput.Count == 0)
            {
                return false;
            }

            for (int i = (_currentInput.Count - 1); i > 0; i--)
            {
                if (_currentInput[i] == ".")
                {
                    return true;
                }
            }
            return false;
        }

        //trim last zeros if decimal detected
        private string TrimCurrentInput()
        {
            if (IsCurrentInputHasDecimal())
            {
                for (int i = (_currentInput.Count - 1); i > 0; i--)
                {
                    if (_currentInput[i] == "0")
                    {
                        _currentInput.RemoveAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            string cuurentEntireInputString = String.Join("", _currentInput.ToArray());
            return cuurentEntireInputString;
        }

        private void UpDateLatestResult(double change, string operatortype)
        {
            switch (operatortype)
            {
                case "+":
                    latestResult += change;
                break;
                case "-":
                    latestResult -= change;
                break;
                case "x":
                    latestResult *= change;
                break;
                case "÷":
                    latestResult /= change;
                break;
                default:
                Debug.Write("Invalid Operatortype!");
                break;
            }

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
                if (!IsCurrentInputHasDecimal())
                {
                    _currentInput.Add(calculatorButton.Text);
                }
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
            TrimCurrentInput();
            string cuurentEntireInputString = String.Join("", _currentInput.ToArray());

            //HistoryTextBox: 
            //  if previous is digit or null, then add _currentInput + operator 
            //  if IsLastInputOperator, replace the operator  
            if (IsLastInputOperator() && (_currentInput.Count == 0))  
            {
                //replace it
                _inputRecord[_inputRecord.Count - 1] = OperatorButton.Text;
                if (OperatorButton.Text == "x" || OperatorButton.Text == "÷")  //add ()
                {
                    _inputRecord.Insert(0, "(");
                    _inputRecord.Insert(_inputRecord.Count - 1, ")"); ;
                }
            }
            else
            {
                //HistoryTextBox: 
                _inputRecord.Add(cuurentEntireInputString);
                //  add operator
                if (OperatorButton.Text == "x" || OperatorButton.Text == "÷")  //add ()
                {
                    _inputRecord.Insert(0, "(");
                    _inputRecord.Add(")");
                }
                _inputRecord.Add(OperatorButton.Text);
                //logicview: calculate latest result
                UpDateLatestResult(Convert.ToDouble(cuurentEntireInputString), _lastOperator);                

                //ResultTextBox: show latest result
                _currentInput.Clear();
                _currentInput.Add(Convert.ToString(this.latestResult));
                ShowResultText();
                _currentInput.Clear(); //clear for next input
            }
            _lastOperator = OperatorButton.Text;
            ShowHistoryText();
        }


        /// <summary>
        /// Handle Clear
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: clear string
            _inputRecord.Clear();
            _lastOperator = "+";
            ShowHistoryText();
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
            if (_currentInput.Count > 1)
            {
                _currentInput.RemoveAt((_currentInput.Count - 1));
            }
            else 
            {
                _currentInput[0] = "0";
            }
            ShowResultText();
            //logicview: do nothing
        }

        /// <summary>
        /// Handle Equal
        /// </summary>
        private void EqualButton_Click(object sender, EventArgs e)
        {
            //HistoryTextBox: clear history
            _inputRecord.Clear();
            ShowHistoryText();

            //logicview
            //  if previous is number, do result lastoper curreninput
            //  if previous is operator, do result lastoper result
            if (IsLastInputOperator())
            {
                UpDateLatestResult(Convert.ToDouble(this.latestResult), _lastOperator);
            }
            else 
            {
                string cuurentEntireInputString = String.Join("", _currentInput.ToArray());
                UpDateLatestResult(Convert.ToDouble(cuurentEntireInputString), _lastOperator);
            }

            //ResultTextBox: show latest result
            _currentInput.Clear();
            _currentInput.Add(Convert.ToString(latestResult));
            ShowResultText();
        }

        /// <summary>
        /// This is the event handler for the "Load" event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            _inputRecord.Clear();
            _lastOperator = "+";


            latestResult = 0;
            _currentInput.Add(Convert.ToString(latestResult));
            ShowResultText();
        }
    }
}
