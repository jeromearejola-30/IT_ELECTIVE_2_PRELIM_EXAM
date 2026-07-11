namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetRandomMeal
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/random.php";

        // Send GET request
        var response = await client.GetAsync(url);

        // Read response body
        string body = await response.Content.ReadAsStringAsync();

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }

        // Assert response body is not null or empty
        if (string.IsNullOrWhiteSpace(body))
        {
            throw new Exception("Response body is empty.");
        }

        Console.WriteLine("GET Random Meal test passed!");
        Console.WriteLine(body);
    }
}