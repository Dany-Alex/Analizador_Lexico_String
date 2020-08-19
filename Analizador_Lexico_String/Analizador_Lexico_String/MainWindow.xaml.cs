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

      

       

        public void analizarTexto()
        {

            string texto; 

           string[] textoSeparado;

            texto = entrada.Text;
           
            textoSeparado = new string[texto.Length];

            textoSeparado = texto.Split();
          
            foreach (string s in textoSeparado)
            {

                Console.WriteLine("{0} ", s);
            }


            string[] expresionesRegulares = new string[7];

            expresionesRegulares[0] = @"(\s)"; // espacios
          //  expresionesRegulares[1] = @"([a-z]|[A-Z])+([a-z]|[A-Z])*"; //textos
            expresionesRegulares[1] = @"^[a-z|A-Z]+([a-z|A-Z])*([a-z|A-Z])*$"; //textos
            expresionesRegulares[2] = @"^([0-9])+([0-9])*$"; //numeros
            expresionesRegulares[3] = @"(^\d+(\.)+\d+$)"; //doubles
            expresionesRegulares[4] = @"(^Q\.\d+(\.)+\d+$)";   //moneda
            expresionesRegulares[5] = @"([0-9])(\.)+";
            expresionesRegulares[6] = @"(\.)+([0-9])+";
            for(int j = 0; j < textoSeparado.Length; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            analizador(expresionesRegulares[4], textoSeparado[j], "Moneda");
                            
                        break;
                        case 1:

                            analizador(expresionesRegulares[1], textoSeparado[j], "Texto");
                            break;
                        case 2:
                            analizador(expresionesRegulares[3], textoSeparado[j], "Double");
                            
                            break;
                        case 3:
                            analizador(expresionesRegulares[2], textoSeparado[j], "Numero");
                            
                            break;
                        case 4:

                            analizador(expresionesRegulares[0], textoSeparado[j], "Espacio");
                            break;
                        case 5:

                            analizador(expresionesRegulares[5], textoSeparado[j], "NO");
                            break;
                        case 6:

                            analizador(expresionesRegulares[6], textoSeparado[j], "NO");
                            break;
                        default:
                            break;


                    }
                }

            }


        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="expresionRegular">recibe una cadena con una expresion regular</param>
       /// <param name="cadena">recibe la cadena de texto que sera comparada con la expresion regular</param>
       /// <param name="tipo">recibe una cadena con el tipo para concatenarla segun el tipo de expresion regular EJ: Texto, Moneda, Numer, etc..</param>
        public void analizador(string expresionRegular,String cadena, string tipo) {
            Regex r = new Regex(expresionRegular, RegexOptions.IgnoreCase);
            Match m = r.Match(cadena);

            while (m.Success)
            {
                string impimir;
                impimir= "---> '" + m.Value + " es " + tipo+ "\n";
                
                resultadoT.Text = resultadoT.Text += impimir;
               m = m.NextMatch();

            }
        }
    }
}
