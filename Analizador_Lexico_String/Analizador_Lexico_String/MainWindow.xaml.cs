using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Analizador_Lexico_String
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            analizarTexto();
        }

        public string texto, itemTexto,itemResultado;

       

        public void analizarTexto()
        {

            

           string[] textoSeparado;

            texto = entrada.Text;
           
            textoSeparado = new string[texto.Length];

            textoSeparado = texto.Split(' ');

            

            string letras = @"([a-z]|[A-Z])+";
            //  string pat = @"\s";

            string[] expresionesRegulares = new string[4];

            expresionesRegulares[0] = @"(\s)";
            expresionesRegulares[1] = @"([a-z]|[A-Z])+";
            expresionesRegulares[2] = @"([0-9])+";
            expresionesRegulares[3] = @"Q.";

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:

                        analizador(expresionesRegulares[0], "Espacio");
                        break;
                    case 1:

                        analizador(expresionesRegulares[1], "Letras");
                        break;
                    case 2:

                        analizador(expresionesRegulares[2], "Numeros");
                        break;
                    case 3:

                        analizador(expresionesRegulares[3], "Moneda");
                        break;
                    default:
                        break;

                        
                }
            }

        }

        public void analizador(string letras, string tipo) {
            Regex r = new Regex(letras, RegexOptions.IgnoreCase);
            Match m = r.Match(texto);

            while (m.Success)
            {
                string impimir;
                impimir = "---> '" + m.Value + "' es "+tipo+"\n";
                resultadoT.Text = resultadoT.Text += impimir;
                m = m.NextMatch();

            }
        }
    }
}
