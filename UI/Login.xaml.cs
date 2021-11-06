using LoginWPF.BLL;
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

namespace LoginWPF.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow principal = new MainWindow();
        public Login()
        {
            InitializeComponent();

        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ingresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.Validar(nombreUsuarioTextBox.Text, clavePasswordBox.Password);

            if (paso)
            {
                this.Close();
                principal.Show();
            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                clavePasswordBox.Clear();
                nombreUsuarioTextBox.Focus();
            }
        }
    }
}
