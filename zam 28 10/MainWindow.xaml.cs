using System;
using System.Windows;

namespace zam_28_10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                ResultTextBlock.Text = "Ошибка: Введите число!";
                return;
            }
            if (!int.TryParse(input, out int number))
            {
                ResultTextBlock.Text = "Ошибка: Некорректный ввод!";
                return;
            }
            if (number < 0)
            {
                ResultTextBlock.Text = "Ошибка: Число должно быть положительным!";
                return;
            }

            try
            {
                long factorial = CalculateFactorial(number);
                ResultTextBlock.Text = $"Факториал: {factorial}";
            }
            catch (OverflowException)
            {
                ResultTextBlock.Text = "Ошибка: Переполнение!";
            }
        }

        private long CalculateFactorial(int n)
        {
            long result = 1;
            checked
            {
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            }
            return result;
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text == "Введите число")
            {
                InputTextBox.Text = "";
            }
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                InputTextBox.Text = "Введите число";
            }
        }
    }
}