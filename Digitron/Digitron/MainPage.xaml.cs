using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;

namespace Digitron
{
    public partial class MainPage : ContentPage
    {
        double firstNum;
        double secondNum;
        string operation = string.Empty;
        int trigger = 0;
        bool calculated = false;
        private List<double> inputArray = new List<double>();
        private List<string> operators = new List<string>();

        public MainPage()
        {
            InitializeComponent();
        }

        public static double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
        public void  DigitAsync (object sender, EventArgs args) {
            string value = (sender as Button).Text;
            if (value == "C")
            {
                this.Input.Text = this.Result.Text = "";

            }

            else
            {
                this.Input.Text += value;
                Calculate();
            }
        }

        public void Operator (object sender, EventArgs args)  {
            operation = (sender as Button).Text;
            if (operation == "√")
            {
                string temp = Math.Round(Math.Sqrt(Double.Parse(this.Result.Text)), 5).ToString();
                this.Result.Text = temp;
                this.Input.Text = temp;
            }
            else this.Input.Text += operation;
        }

        public void Calculate (object sender = null, EventArgs args = null)
        {
            string oper = String.Empty;
            if (sender != null) oper = (sender as Button).Text;
            if (oper == "=")
            {
                this.Input.Text = (Evaluate(this.Input.Text)).ToString();
                this.Result.Text = "";
            }
            else this.Result.Text = (Evaluate(this.Input.Text)).ToString();
        }
    }
}
