using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace zadnie2
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "your_connection_string_here"; // Zastąp prawidłowym ciągiem połączeniowym do MySQL

        public void AddArticle(Article article)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO articles (Name, Category, CreatedDate, Content) VALUES (@Name, @Category, @CreatedDate, @Content)", connection);
                command.Parameters.AddWithValue("@Name", article.Name);
                command.Parameters.AddWithValue("@Category", article.Category);
                command.Parameters.AddWithValue("@CreatedDate", article.CreatedDate);
                command.Parameters.AddWithValue("@Content", article.Content);
                command.ExecuteNonQuery();
            }
        }

        public List<Article> GetArticles()
        {
            var articles = new List<Article>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM articles", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Category = reader.GetString("Category"),
                            CreatedDate = reader.GetDateTime("CreatedDate"),
                            Content = reader.GetString("Content")
                        });
                    }
                }
            }

            return articles;
        }

        public void UpdateArticle(Article article)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE articles SET Name = @Name, Category = @Category, Content = @Content WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", article.Id);
                command.Parameters.AddWithValue("@Name", article.Name);
                command.Parameters.AddWithValue("@Category", article.Category);
                command.Parameters.AddWithValue("@Content", article.Content);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteArticle(int articleId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM articles WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", articleId);
                command.ExecuteNonQuery();
            }
        }
    }
}
