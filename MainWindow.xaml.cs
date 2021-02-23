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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private List<double> numbers = new List<double>();
        private int click = 0;
        private double result = 0;
        private Boolean is_correct = false;




        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            operation(" + ", 1);
            result = numbers.Aggregate((x, y) => x + y);
            resultado.Content = result;


        }

        private void resta_click(object sender, RoutedEventArgs e)
        {
            operation(" - ", 2);
            if (is_correct)
            {
                result = numbers.Aggregate((x, y) => x - y);
                resultado.Content = result;
            }

        }



        private void mul_click(object sender, RoutedEventArgs e)
        {
            operation(" * ", 3);
            if (is_correct)
            {
                result = numbers.Aggregate((x, y) => x * y);
                resultado.Content = result;
            }

        }

        private void div_click(object sender, RoutedEventArgs e)
        {
            operation(" / ", 4);
            if (is_correct)
            {
                result = numbers.Aggregate((x, y) => x / y);
                resultado.Content = result;
            }

        }

        private void clear(object sender, RoutedEventArgs e)
        {

        }


        private void operation(String Symbol, int position)
        {
            is_correct = false;

            try
            {
                if (position != click)
                {
                    Console.WriteLine(click + " | " + position);
                    numbers.RemoveAll(item => item >= 0);
                    numbers.Add(result);
                }
                numbers.Add(Convert.ToDouble(var.Text));
                StringBuilder texto = new StringBuilder();
                numbers.ForEach(number => texto.Append(number + Symbol));
                historial.Content = texto;
                click = position;
                is_correct = true;


            }
            catch
            {
                MessageBox.Show("Solo numeros ni espacios en blanco");
            }
            var.Clear();
        }


    }
}
