using System;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;

namespace BigQueryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = "filePath";
            string projectId = "projectId";
            BigQueryClient client = BigQueryClient.Create(projectId, CreateCredential(jsonPath));
            string query = @"SELECT
                CONCAT(
                    'https://stackoverflow.com/questions/',
                    CAST(id as STRING)) as url, view_count
                FROM `bigquery-public-data.stackoverflow.posts_questions`
                WHERE tags like '%google-bigquery%'
                ORDER BY view_count DESC
                LIMIT 10";
            var result = client.ExecuteQuery(query, parameters: null);
            Console.Write("\nQuery Results:\n------------\n");
            foreach (var row in result)
            {
                Console.WriteLine($"{row["url"]}: {row["view_count"]} views");
            }
        }

        #region Create Credential
        // Explicitly use service account credentials by specifying the private key file.
        private static GoogleCredential CreateCredential(string jsonPath)
        {
            return GoogleCredential.FromFile(jsonPath);
        }
        #endregion
    }
}