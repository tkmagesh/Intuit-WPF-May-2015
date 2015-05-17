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
using System.Windows.Shapes;

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Window
    {
        private Employees context;
        public EmployeeList()
        {
            InitializeComponent();
            context = (Employees) this.DataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newEmployee = new Employee() {FirstName = TxtFirstName.Text, LastName = TxtLastName.Text};
            context.EmpList.Add(newEmployee);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            var currentEmployee = (Employee) ((Button) sender).DataContext;
            MessageBox.Show(currentEmployee.FirstName);
        }
    }
}
