using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalculator
{
    public partial class MainWindow : Window
    {
        private string currentEntry = "";
        private double firstNumber, secondNumber;
        private string operatorUsed;
        public MainWindow()
        {
            InitializeComponent();
        }

       private void OnDigitClicked (object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            currentEntry += button.Content.ToString();
            Result.Text = currentEntry;
        }

        private void OnOperatorClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = Convert.ToDouble(currentEntry);
            operatorUsed = button.Content.ToString();
            currentEntry = "";
        }

        private void OnEqualClicked(object sender, RoutedEventArgs e)
        {
            secondNumber = Convert.ToDouble(currentEntry);

            double result = operatorUsed
                switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
                _ => 0
            };
            Result.Text = result.ToString();
            currentEntry = result.ToString();
        }

        private void OnClearClicked(object sender, RoutedEventArgs e)
        {
            currentEntry = "";
            firstNumber = secondNumber = 0;
            Result.Text = "0";
        }
    }
}