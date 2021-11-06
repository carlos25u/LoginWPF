using LoginWPF.BLL;
using LoginWPF.Entidades;
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

namespace LoginWPF.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void consultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (filtroTextBox.Text.Trim().Length > 0)
            {
                switch (filtroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = UsuariosBLL.GetList(e => e.NombreUsuario.ToLower().Contains(filtroTextBox.Text.ToLower()));
                        break;

                    case 1:
                        listado = UsuariosBLL.GetList(e => e.Nombres.ToLower().Contains(filtroTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(c => true);
            }

            DatosDataDrid.ItemsSource = null;
            DatosDataDrid.ItemsSource = listado;
        }
    }
}
