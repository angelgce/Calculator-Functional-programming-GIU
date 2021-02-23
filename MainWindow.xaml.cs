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

    public partial class MainWindow : Window

    {
        private List<double> list_numbers = new List<double>(); //Array of numbers 
        private int my_operation_id = 0; //the id of the operation im doing
        private double math_result = 0; // the result of my arithmetic operation
        private Boolean is_correct = false; // this boolean will tell me if the input value is correct

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sum_Click(object sender, RoutedEventArgs e)

        {
            Operations(" + ", 1);//pasing the symbol and id of sum
            if (is_correct)//if there's not a wrong entry, then...
            {
                math_result = list_numbers.Aggregate((x, y) => x + y); //math_result will be equals to the this Functional Operation -> Method Reduce (Aggregate)
                                                                       //this Method request two parameters (a Collection, and the math operation ) this is Lambda format
                label_result.Content = math_result;//writing the result on the label
                                                   
            }
            //it is the same for the others buttons, the changes are only in the symbol and in the functional operation
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            Operations(" - ", 2);
            if (is_correct)
            {
                math_result = list_numbers.Aggregate((x, y) => x - y);
                label_result.Content = math_result;
            }

        }

        private void Milt_Click(object sender, RoutedEventArgs e)
        {
            Operations(" * ", 3);
            if (is_correct)
            {
                math_result = list_numbers.Aggregate((x, y) => x * y);
                label_result.Content = math_result;
            }

        }
        private void Div_Click(object sender, RoutedEventArgs e)
        {
            Operations(" / ", 4);
            if (is_correct)
            {
                math_result = list_numbers.Aggregate((x, y) => x / y);
                label_result.Content = math_result;
            }

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            //this method will return everything by default
            list_numbers.RemoveAll(item => item >= 0 || item<=0);//removing all the values of the List<double>
            label_result.Content = 0;
            history.Content = "";
            my_operation_id = 0;
            math_result = 0;

        }


        /// <summary>
        /// this method will upadate the information labels of the main frame
        /// </summary>
        /// <param name="Symbol">Put the symbol of the arithmetic operation</param> 
        /// <param name="id_operation">Select the id of the operation to perform ID-> [1 sum][2 subs][3 mul][4 div]</param>
        private void Operations(String Symbol, int id_operation)
        {
            is_correct = false; //returning to false
            try
            {
                if (id_operation != my_operation_id)//if is a new operation
                {
                    history.Content = "";//cleanig the history values
                    list_numbers.RemoveAll(item => item >= 0 || item <= 0);//cleaning the list
                    list_numbers.Add(math_result);//restoring the value of the last added number (mat_result allways save it)
                }
                list_numbers.Add(Convert.ToDouble(input.Text));//adding the new input number to the List<double>
                StringBuilder string_value = new StringBuilder();//Creating a StringBuilder to get values from the list
                list_numbers.ForEach(number => string_value.Append(number + Symbol));//using a functional forEach and Append method to write all values to the String
                history.Content = string_value; //writting the StringBuilder on the Label(history)
                my_operation_id = id_operation;//changing the value of the operation that Im doing(my_operation_id) with the value received from the parameter (id_operation)
                is_correct = true;//making this true because everything worked fine

            }
            catch
            {
                MessageBox.Show("numbers and no blanks");//to catch possible input errors
            }
            input.Clear(); // cleaning the textbox(input)
        }


    }
}
