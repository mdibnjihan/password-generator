using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int currentPasswordLength;
        bool symbolRequired;
        Random str = new Random();

        private void passwordGenerator(int passwordLength)
        {
            String charcterString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890|!#$%&/()=?»«@£§€{}.-;'<>_,";
            String randomPassword = "";

            for (int i = 0; i < passwordLength; i++)
            {
                int randomNum = str.Next(0, charcterString.Length);
                randomPassword += charcterString[randomNum];
            }

            if (symbolRequired == true)
            {
                StringBuilder mbuilder = new StringBuilder(randomPassword);
                mbuilder[mbuilder.Length - 1] = '@';
                Generated_Password.Content = mbuilder.ToString();
            }
            else
            {
                Generated_Password.Content = randomPassword;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Password_Length_Slider.Minimum = 8;
            Password_Length_Slider.Maximum = 64;
            passwordGenerator(16);
        }

        private void Copy_Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((string)Generated_Password.Content);
        }

        private void Password_Length_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Slider_Value_Text.Content = Password_Length_Slider.ValueChanged;
            currentPasswordLength = (int)Password_Length_Slider.Value;
            passwordGenerator(currentPasswordLength);
        }

        private void Regenerate_Password_Click(object sender, RoutedEventArgs e)
        {
            currentPasswordLength = (int)Password_Length_Slider.Value;
            passwordGenerator(currentPasswordLength);
        }

        private void Symbol_Required_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (Symbol_Required_Checkbox.IsChecked == true)
            {
                symbolRequired = true;
            }
            else
            {
                symbolRequired = false;
            }
        }
    }
}
