namespace Calculator;

public partial class MainPage : ContentPage
{
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string currentOperator = ""; // + - * / =
    private bool isFirstNumberAfterOperator = true;
    public MainPage()
    {
        InitializeComponent();
    }


    private void OnNumberPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;

        if (pressedButton != null)
        {
            if (isFirstNumberAfterOperator)
            {
                Display.Text = pressedButton.Text;
                isFirstNumberAfterOperator = false;
            }
            else
            {
                Display.Text = Display.Text + pressedButton.Text;
            }
        }
        
    }

    private void OnOperatorPressed(object? sender, EventArgs e)
    {
        Button pressedButton = sender as Button;

        string op = pressedButton.Text;

        if (op == "x²" || op == "√")
        {
            double value = Double.Parse(Display.Text);
            double result;
            if (op == "x²")
                result = value * value;
            else
                result = Math.Sqrt(value);

            if (currentOperator == "")
            {
                if (op == "x²")
                    HistoryDisplay.Text = $"{value}²";
                else
                    HistoryDisplay.Text = $"√{value}";
            }
            else
            {
                string secondText;
                if (op == "x²")
                {
                    secondText = $"{value}²";
                }
                else
                {
                    secondText = $"√{value}";
                }
                HistoryDisplay.Text = $"{firstNumber}{currentOperator}{secondText}";
            }

            Display.Text = result.ToString();

            if (currentOperator == "")
            {
                firstNumber = result;
                isFirstNumberAfterOperator = true;
            }
            else
            {
                isFirstNumberAfterOperator = false;
            }
            return;
        }

        if (isFirstNumberAfterOperator)
        {
            currentOperator = pressedButton.Text;
            return;
        }
        
        isFirstNumberAfterOperator = true;
        if (currentOperator == "")
        {
            currentOperator = pressedButton.Text;
            firstNumber = Double.Parse(Display.Text);
          
        }
        else
        {
            
            secondNumber = Double.Parse(Display.Text);
            double result=0;
            switch (currentOperator)
            {
                case "+" :   result = firstNumber + secondNumber; break;
                case "-" :   result = firstNumber - secondNumber; break;
                case "*" :   result = firstNumber * secondNumber; break;
                case "/" :   result = firstNumber / secondNumber; break;
                
                
            }

            string expression = $"{firstNumber} {currentOperator} {secondNumber}";
            if (pressedButton!.Text == "=")
            {
                HistoryDisplay.Text = expression + " =";
            }
            else
            {
                HistoryDisplay.Text = expression;
            }

            Display.Text = result.ToString();
            currentOperator = pressedButton.Text;
            if(pressedButton.Text == "=") currentOperator = "";
            firstNumber = result;
            
        }
    }
    private void OnClearAllPressed(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentOperator = "";
        isFirstNumberAfterOperator = true;
        Display.Text = "0";
        HistoryDisplay.Text = "";
    }
    private void OnClearEntryPressed(object sender, EventArgs e)
    {
        Display.Text = "0";
        isFirstNumberAfterOperator = true;
        if (currentOperator == "" )
        {
            firstNumber = 0;
            secondNumber = 0;
            HistoryDisplay.Text= "0";
        }
        else
        {
            secondNumber = 0;
            HistoryDisplay.Text= $"{firstNumber}{currentOperator}";
        }
    }
}