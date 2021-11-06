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

namespace LoginWPF.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }

        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;
        }

        private bool Validar()
        {
            String mensajeValidacion = "";

            if (Utilidades.ToInt(UsuarioIdTextBox.Text) == 0)
            {
                UsuarioIdTextBox.Focus();
                mensajeValidacion = "El ID no puede estar vacio ni igual a 0";
            }

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                NombresTextBox.Focus();
                mensajeValidacion = "El campo nombre no puede estar vacia";
            }

            if (string.IsNullOrWhiteSpace(ApellidosTextBox.Text))
            {
                ApellidosTextBox.Focus();
                mensajeValidacion = "El apellido no puede estar vacio";
            }

            if (string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
            {
                NombreUsuarioTextBox.Focus();
                mensajeValidacion = "El Nombre Usuario no puede estar vacio";
            }

            if (clavePasswordBox.Password.Length == 0 )
            {
                clavePasswordBox.Focus();
                mensajeValidacion = "clave no puede estar vacio";
            }

            if (ConfirmarClavePasswordBox.Password.Length == 0)
            {
                ConfirmarClavePasswordBox.Focus();
                mensajeValidacion = "Confirmar Clave no puede estar vacio";
            }

            if (ConfirmarClavePasswordBox.Password != clavePasswordBox.Password)
            {
                ConfirmarClavePasswordBox.Focus();
                mensajeValidacion = "La clave no coinciden";
            }

            if(mensajeValidacion.Length > 0)
            {
                MessageBox.Show(mensajeValidacion, "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

                return mensajeValidacion.Length == 0;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuario = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (usuario != null)
            {
                this.usuarios = usuario;
            }
            else
            {
                this.usuarios = new Usuarios();
            }
            this.DataContext = this.usuarios;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(usuarios);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
