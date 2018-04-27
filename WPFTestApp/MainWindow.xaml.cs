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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace WPFTestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog;
        public MainWindow()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        public string[] GetStr(string line)
        {
            string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public void ParseText(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                string pattern = @"\w*7e\w*";
                string pat = @"~\w*";
                Regex regex = new Regex(pattern);
                Regex regex1 = new Regex(pat);
                while ((line = sr.ReadLine()) != null)
                {
                    if(regex.IsMatch(line))
                    {
                        string[] res = GetStr(line);
                        int i = 0;
                        while (!regex1.IsMatch(res[i]))
                        {
                            text1.Text += res[i] + " ";
                            i++;
                        }
                    }
                    else
                    {
                        text1.Text += "";
                    }
                }
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                ParseText(path);
            }
        }
    }
}
