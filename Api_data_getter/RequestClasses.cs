

namespace Api_data_getter
{
    public class FinancialModelingRequestProvider
    {
        HttpClient client = HttpClientProvider.GetHttpClient();
        private string apikey { get; set; }
        public string ticker { get; set; }
         public bool IsValid { get; set; }
        public string requestType { get; set; }


        private string url { get; set; }
        public void Set(IRequestProvider RequestProvider)
        {
            this.apikey = RequestProvider.apikey;
            this.url = RequestProvider.url;
            this.ticker = RequestProvider.ticker;
            this.requestType = RequestProvider.requestType;
      
        }
        public bool RequestSuccess()
        {
            return IsValid;
        }
        public async Task GetAndWrite()
        {
            
            var response =  await client.GetStringAsync(url);
            

            string json = response.ToString();



            if (json.Contains("Error") || json.Length < 50)
            {

                IsValid = false;
                File.AppendAllText("../../../../data/meta_data/"+requestType+"/no_data_tickers.txt", ticker+",");
            }
            else
            {
                IsValid = true;

                await File.WriteAllTextAsync($"../../../../data/" + requestType + "/" + ticker + ".txt", json);

                
            }
        }
    }
  
    public static class HttpClientProvider
    {
        // HttpClient instance
        private static readonly HttpClient httpClient = new HttpClient();
       

        // Global HttpClient Instance
        public static HttpClient GetHttpClient()
        {
            return httpClient;
        }
    }
    public class Stock_price_change : IRequestProvider
    {
        public string url { get { return "https://financialmodelingprep.com/api/v3/historical-price-full/" + ticker + "?apikey=" + apikey; } }
        public string ticker { get; set; }
        public string apikey { get; set; }
        public string requestType { get; set; }
        public Stock_price_change(string apikey, string ticker)
        {
            this.apikey = apikey;
            this.ticker = ticker;
            this.requestType = "stock_price_change";
        }
    
    }
    public class Core_metrics : IRequestProvider    
    {
        public string url { get { return "https://financialmodelingprep.com/api/v3/key-metrics-ttm/" + ticker + "?apikey=" + apikey; } }
        public string ticker { get; set; }
        public string apikey { get; set; }
        public string requestType { get; set; }
      
        public Core_metrics(string apikey, string ticker)
        {
            this.apikey = apikey;
            this.ticker = ticker;
            this.requestType = "core_metrics";
        }
    }
  public class Full_financial_statement: IRequestProvider
            {
        public string url { get{ return "https://financialmodelingprep.com/api/v3/financial-statement-full-as-reported/"+ticker+"?period=annual&limit=100000&apikey="+apikey; } }
        public string ticker { get; set; }
        public string apikey { get; set; }
        public string requestType { get; set; }
        
        public Full_financial_statement(string apikey, string ticker)
        {
            this.apikey = apikey;
            this.ticker = ticker;
            this.requestType = "full_financial_statement";
       
        }
    }
    public interface IRequestProvider
    {
        public string url { get; }
        public string ticker { get; set; }
        public string apikey { get; set; }
        public string requestType { get; }
    }
}