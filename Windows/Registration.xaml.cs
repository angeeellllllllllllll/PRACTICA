using System.Linq;
using System.Windows;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var password = Pass.Text;
            var email = mail.Text;
            var context = new AppDbContext();
            var user_exist = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user_exist is not null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            var user = new User { Login = login, Password = password };
            context.Users.Add(user);
            context.SaveChanges();

            MessageBox.Show("Добро пожаловать!");

        }
    }
}
