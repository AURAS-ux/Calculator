using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result,prevNum;
        Operations selectionOperation;
        public MainWindow()
        {
            result = 0;
            InitializeComponent();
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperaionButtonSelected(object sender, RoutedEventArgs e)
        {

        }

        private void NegativeButton(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() == "0")
            {

            }
            else
            {
                resultLabel.Content = double.TryParse(resultLabel.Content.ToString(), out result);
                resultLabel.Content = (result*-1).ToString();
            }
        }

        private void NumberButton(object sender,RoutedEventArgs e)
        {
            int selectedNum;
            selectedNum = int.Parse((sender as Button).Content.ToString());
            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedNum}";
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedNum}";
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNum;
            if (double.TryParse(resultLabel.Content.ToString(), out newNum)) 
            {
                switch (selectionOperation)
                {
                    case Operations.Add:
                        result = Calculate.Add(prevNum, newNum);
                        break;
                    case Operations.Sub:
                        result = Calculate.Sub(prevNum, newNum);
                        break;
                    case Operations.Mult:
                        result = Calculate.Multiply(prevNum, newNum);
                        break;
                    case Operations.Div:
                        result = Calculate.Divide(prevNum, newNum);
                        break;
                }
            }

            resultLabel.Content = result.ToString();
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains("."))
            {

            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void OperationNumber(object sender,RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(),out prevNum))
            {
                resultLabel.Content = "0";
            }
            if (sender == multiplyButton)
                selectionOperation = Operations.Mult;
            if (sender == divideButton)
                selectionOperation = Operations.Div;
            if (sender == plusButton)
                selectionOperation = Operations.Add;
            if (sender == minusButton)
                selectionOperation = Operations.Sub;

        }
    }


    enum Operations
    {
        Add,
        Sub,
        Mult,
        Div
    }

    public class Calculate
    {
        public static double Add(double n1,double n2)
        {
            return n1+ n2;
        }

        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Cannot divide by 0", "Error in division", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            else return n1 / n2;
        }
    }

}
