using Microsoft.Windows.Themes;
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

            if (Pass.Text.Length > 6)
           
            {
                bool en = true;
                bool symbol = false;
                bool number = false;
                for (int i = 0; i < Pass.Text.Length; i++)
                {
                    if (Pass.Text[i] > 'А' && Pass.Text[i] <= 'Я') en = false;
                    if (Pass.Text[i] > '0' && Pass.Text[i] <= '9') number = true;
                    if (Pass.Text[i] == '_' || Pass.Text[i] == '-' || Pass.Text[i] == '!') symbol = true;

                }
                if (!en)
                    MessageBox.Show("Доступна только английская раскладка");
                else if (!symbol)
                    MessageBox.Show("Добавьте один из следующих символов: _ - !");
                else if (!number)
                    MessageBox.Show("Добавьте хотя бы одну цифру");
                if (en && symbol && number)
                {

                }
            }
            else MessageBox.Show("Пароль слишком короткий, минимум 6 символов");

            if (Pass.Text == Pass.Text)
            {
                MessageBox.Show("Пароль загеристрирован");
            }
            else MessageBox.Show("Пароли не совпадают");



            if (user_exist is not null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            var user = new User { Login = login, Password = password, Email = email };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Добро пожаловать!");
            

        }

        private void voitiBut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
           
        }

        private void Pass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
