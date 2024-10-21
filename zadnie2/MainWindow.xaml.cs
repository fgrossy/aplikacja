using System;
using System.Collections.Generic;
using System.Windows;

namespace zadnie2
{
    public partial class MainWindow : Window
    {
        private DatabaseHelper dbHelper;

        public MainWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Inicjalizacja helpera bazy danych
            LoadArticles(); // Wczytanie artykułów przy starcie
        }

        // Dodawanie nowego artykułu
        private void AddArticleButton_Click(object sender, RoutedEventArgs e)
        {
            var article = new Article
            {
                Name = ArticleNameTextBox.Text,
                Category = ArticleCategoryTextBox.Text,
                CreatedDate = DateTime.Now,
                Content = ArticleContentTextBox.Text
            };

            dbHelper.AddArticle(article); // Dodanie artykułu do bazy
            MessageBox.Show("Dodano artykuł!");
            LoadArticles(); // Załaduj ponownie listę artykułów
        }

        // Wyświetlenie artykułów
        private void DisplayArticlesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadArticles(); // Wczytaj artykuły, aby odświeżyć ListView
        }

        // Wczytanie artykułów i wyświetlenie ich
        private void LoadArticles()
        {
            var articles = dbHelper.GetArticles();
            ArticlesList.ItemsSource = articles; // Przypisanie listy artykułów do ListView
        }

        // Metody obsługi zdarzeń GotFocus i LostFocus
        private void ArticleNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ArticleNameTextBox.Text == "Nazwa artykułu")
            {
                ArticleNameTextBox.Text = string.Empty;
            }
        }

        private void ArticleNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ArticleNameTextBox.Text))
            {
                ArticleNameTextBox.Text = "Nazwa artykułu";
            }
        }

        private void ArticleCategoryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ArticleCategoryTextBox.Text == "Kategoria")
            {
                ArticleCategoryTextBox.Text = string.Empty;
            }
        }

        private void ArticleCategoryTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ArticleCategoryTextBox.Text))
            {
                ArticleCategoryTextBox.Text = "Kategoria";
            }
        }

        private void ArticleContentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ArticleContentTextBox.Text == "Treść artykułu")
            {
                ArticleContentTextBox.Text = string.Empty;
            }
        }

        private void ArticleContentTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ArticleContentTextBox.Text))
            {
                ArticleContentTextBox.Text = "Treść artykułu";
            }
        }
    }
}
