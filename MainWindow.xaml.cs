using System.Linq;
using System.Windows;
using WpfApp1.Windows;

namespace WpfApp1
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

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var password = pass.Text;
            var context = new AppDbContext();
            var user_exist = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user_exist != null)
            {
                MessageBox.Show("Неправильный  логин или пароль");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт");
        }

        private void ToReg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
