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
using System.IO;
using Microsoft.Win32;

namespace Encoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789?!()-";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            forDecrypt.Text = api(forEncrypt.Text);
        }
        public string api(string api)

        {
            StringBuilder code = new StringBuilder();

            string a = forEncrypt.Text;
            string b = forKey.Text;
            if (string.IsNullOrWhiteSpace(b))
            {
                MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
               
            }
            
            int key = Convert.ToInt32(b);
            for (int i = 0; i < a.Length; i++)
                for (int e = 0; e < alphabet.Length; e++)
                    if (a[i] == alphabet[e]) code.Append(alphabet[(e + key) % alphabet.Length]);
            forEncrypt.Clear();
            return code.ToString();
        }


        private void forEncrypt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void forDecrypt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }   

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            forEncrypt.Text = uuu(forDecrypt.Text);
        }
        private string uuu(string api)
        {
            StringBuilder code = new StringBuilder();
            string a = forDecrypt.Text;
            string b = forKey.Text;
            if (forDecrypt.Text != null && forDecrypt.Text != "" && forKey.Text != null && forKey.Text != "") ;
            else 
                MessageBox.Show("Не все данные внесены!", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            {
                int key;
                if (string.IsNullOrWhiteSpace(b))
                {
                    key = 0;
                }
                key = Convert.ToInt32(b);

                for (int i = 0; i < a.Length; i++)
                    for (int e = 0; e < alphabet.Length; e++)
                        if (a[i] == alphabet[e]) code.Append(alphabet[(e - key + alphabet.Length) % alphabet.Length]);
                forDecrypt.Clear();
            }
            return code.ToString();
        }

        private void forKey_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void forKey_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "")
              && (!forKey.Text.Contains("")
              && forKey.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        { 
           MessageBoxResult result = MessageBox.Show("Вы точно хотите очистить все поля?", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                forDecrypt.Clear();
                forEncrypt.Clear();
                forKey.Text = "1";
            }
        }

        public void Rnd()
        {
            Random random = new Random();
            int value = random.Next(0, 10);
            forKey.Text = Convert.ToString(value);
        }
        private void loadInEncrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            if (load.ShowDialog() == true)
            load.Filter = "Text file(*.txt)|*.txt";
            {
                forEncrypt.Text = File.ReadAllText(load.FileName);
            }
        }

        private void SaveFromEncrypt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text file(*.txt)|*.txt";
            if(save.ShowDialog() == true)
            {
                File.WriteAllText(save.FileName, forEncrypt.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text file(*.txt)|*.txt";
            if (save.ShowDialog() == true)
            {
                File.WriteAllText(save.FileName, forDecrypt.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            if (load.ShowDialog() == true)
                load.Filter = "Text file(*.txt)|*.txt";
            {
                forDecrypt.Text = File.ReadAllText(load.FileName);
            }
        }
    } 
}

