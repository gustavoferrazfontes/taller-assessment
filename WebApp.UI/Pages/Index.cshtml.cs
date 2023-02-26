using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.UI.Models;

namespace WebApp.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private string baseUrl = "https://localhost:7163/api/v1/cars";
        public bool ShowMessage { get; private set; }
        public IEnumerable<CarViewModel> Cars { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Cars = new List<CarViewModel>();
        }

        public async void OnGet()
        {
            await GetAllCars();

        }

        public async void OnPost()
        {
            var price = decimal.Parse(Request.Form["price"]);

            var guess = decimal.Parse(Request.Form["guessInput"]);

            if (Math.Abs(price - guess) <= 5000)
            {
                ShowMessage = true;
            }

            await GetAllCars();

        }

        private async Task GetAllCars()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(baseUrl);
                var response = httpClient.Send(request);
                Cars = await response.Content.ReadFromJsonAsync<IEnumerable<CarViewModel>>();
            }
        }

    }
}