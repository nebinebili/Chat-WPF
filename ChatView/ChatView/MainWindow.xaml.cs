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
using System.Threading;
using System.Net;

namespace ChatView
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

        Image image;
        int count1 = 0;

        List<string> messages = new List<string>
        {
            "Salam","Necesen?"
        };

        private void txB_second_GotFocus(object sender, RoutedEventArgs e)
        {
            txB_second.Visibility = System.Windows.Visibility.Collapsed;
            txB_main.Visibility = System.Windows.Visibility.Visible;
        }

        private void txB_main_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txB_main.Text))
            {
                txB_second.Visibility = System.Windows.Visibility.Visible;
                txB_main.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void message()
        {
            Random rand = new Random();
            int count = rand.Next(1, 5);         
            count1++;
            string sentences = String.Join(" ", Faker.Lorem.Sentences(count));
            Chat_Message chat_Message = new Chat_Message();

            if (count1 > 2)
            {
             chat_Message.txtblock.Text = sentences;

            }
            else
            {
                chat_Message.txtblock.Text = messages[count1 - 1];
            }
            chat_Message.grid_chat.Margin = new Thickness(10, 30, 0, 0);
            chat_Message.border.Background = new SolidColorBrush(Color.FromRgb(41, 40, 40));
            chat_Message.lbl_time.Content = $"{DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute.ToString()}";
            chat_Message.lbl_time.HorizontalAlignment = HorizontalAlignment.Left;
            listbox.Items.Add(chat_Message);
            count = 0;
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            if (txB_main.Text.Length!=0)
            {
                Chat_Message chat_Message = new Chat_Message();
                chat_Message.txtblock.Text = txB_main.Text;
                chat_Message.grid_chat.Margin = new Thickness(400, 20, 0, 0);
                chat_Message.border.Background = new SolidColorBrush(Color.FromRgb(110, 72, 170));
                chat_Message.border.HorizontalAlignment = HorizontalAlignment.Right;
                chat_Message.lbl_time.Content = $"{DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute.ToString()}";
                listbox.Items.Add(chat_Message);
                txB_main.Text = null;
                
              message();          
            }

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            image = new Image();
            image.Width = 300;
            image.Height = 900;
            image.Source = new BitmapImage(new Uri("Images/Profil1.png",UriKind.Relative));
            
            Panel.SetZIndex(image,0);
            image.Margin = new Thickness(0,0,90, 0);
            image.HorizontalAlignment = HorizontalAlignment.Right;
            image.VerticalAlignment = VerticalAlignment.Top;
            
            
            grid_row1.Children.Add(image);
            
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            grid_row1.Children.Remove(image);
        }
    }
}
