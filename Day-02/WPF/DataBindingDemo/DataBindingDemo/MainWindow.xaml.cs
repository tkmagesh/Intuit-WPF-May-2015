using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SalaryCalculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = (SalaryCalculator)this.DataContext;
        }

       
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            calculator.Calculate();
        }

       
        private void BtnUpdateCalculator_OnClick(object sender, RoutedEventArgs e)
        {
            calculator.Basic = 20000;
            calculator.Hra = 5000;
            calculator.Da = 3000;
            calculator.Tax = 25;
        }
    }

   /* public class SalaryCalculator
    {
        private double _basic;
        private double _hra;
        private double _da;
        private double _tax;

        public event Action<double> BasicChanged;
        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                BasicChanged(value);
            }
        }
        public event Action<double> HraChanged;
        public double Hra
        {
            get { return _hra; }
            set
            {
                _hra = value;
                HraChanged(value);
            }
        }
        public event Action<double> DaChanged;
        public double Da
        {
            get { return _da; }
            set
            {
                _da = value;
                DaChanged(value);
            }
        }
        public event Action<double> TaxChanged;
        public double Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                TaxChanged(value);
            }
        }

        public double Salary { get; set; }

        public event Action<double> SalaryChanged;

        public void Calculate()
        {
            var gross = Basic + Hra + Da;
            var net = gross*((100 - Tax)/100);
            Salary = net;
            SalaryChanged(Salary);
        }
    }*/
    
    public class SalaryCalculator : INotifyPropertyChanged
    {
        private double _basic;
        private double _hra;
        private double _da;
        private double _tax;
        private double _salary;


        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                TriggerChangeEventFor("Basic");
            }
        }

        private void TriggerChangeEventFor(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Hra
        {
            get { return _hra; }
            set
            {
                _hra = value;
                TriggerChangeEventFor("Hra");
            }
        }
        
        public double Da
        {
            get { return _da; }
            set
            {
                _da = value;
                TriggerChangeEventFor("Da");
            }
        }
        
        public double Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                TriggerChangeEventFor("Tax");
            }
        }

        public double Salary
        {
            get { return _salary; }
            private set
            {
                _salary = value;
                TriggerChangeEventFor("Salary");
            }
        }


        public void Calculate()
        {
            var gross = Basic + Hra + Da;
            var net = gross * ((100 - Tax) / 100);
            Salary = net;

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
