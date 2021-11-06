using LoginWPF.UI.Consultas;
using LoginWPF.UI.Registros;
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

namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new rUsuarios().Show();
        }

        private void ConsultasUsuarios_Click(object sender, RoutedEventArgs e)
        {
            new cUsuarios().Show();
        }

    }
}
