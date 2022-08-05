namespace DemoMVC.Web.Models
{
    public class Value
    {
        private HttpClient client = new HttpClient();
        public Value()
        {
            client.BaseAddress = new Uri("http://localhost:5211/api/");
            client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers
                    .MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        public object? GetValue()
        {
            HttpResponseMessage response = client.GetAsync("Values/1").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<object>().Result;

            }
            return new { errorCode = response.StatusCode };
        }

    }
}
