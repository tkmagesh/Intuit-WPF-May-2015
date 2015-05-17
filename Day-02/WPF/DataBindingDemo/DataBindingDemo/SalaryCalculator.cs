using System.ComponentModel;
using System.Windows.Input;

namespace DataBindingDemo
{
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


        

        public ICommand CalculateCommand { get; set; }

        public ICommand UpdateCalculatorCommand { get; set; }

        public SalaryCalculator()
        {
        

            //CalculateCommand = new RelayCommand(_ => this.Calculate());
            CalculateCommand = new RelayCommand(_ => Calculate());
            
            UpdateCalculatorCommand = new RelayCommand(_ =>
            {
                this.Basic = 20000;
                this.Hra = 5000;
                this.Da = 3000;
                this.Tax = 25;
            });
        }

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