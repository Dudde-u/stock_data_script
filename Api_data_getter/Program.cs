using Api_data_getter;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;




string[] TickersCompleted = Directory.GetFiles("../../../../data/" + "full_financial_statement");

List<string> TickersCompletedList = new List<string>();


for (int i = 0; i < TickersCompleted.Length; i++)
{
    TickersCompletedList.Add(Path.GetFileName(TickersCompleted[i]).Split('.')[0]);
}



string alltickers = File.ReadAllText("../../../../data/AllTickers.txt");

string[] AllTickers = alltickers.Split(",");


//Hashtable hashtable1 = new Hashtable();
//for (int i = 0; i < TickersCompletedList.Count; i++)
//{
//    try
//    {
//        hashtable1.Add(TickersCompletedList[i], "");
//    }
//    catch (Exception) { }
//}



List<string> FullTickerList = new List<string>(AllTickers);


for (int i = 0; i < AllTickers.Length; i++)
{
    if (TickersCompletedList.Contains(AllTickers[i]))
    {
        FullTickerList.Remove(AllTickers[i]);
    }
}

List<string> tickerList = new List<string>(FullTickerList);


if (tickerList.Count == 0)
{
    Console.WriteLine("No more tickers to request data for");
    Console.WriteLine("Press key to exit enviroment");
    Console.ReadKey();
    Environment.Exit(0);
}

Console.WriteLine("Amount of tickers left: " + tickerList.Count);
Console.WriteLine("Length of document containing tickers: " + alltickers.Length);
Console.WriteLine("Do you want to continue? [Y/N]");
if (Console.ReadLine() == "n")
{
    Environment.Exit(0);
}


Console.WriteLine("Syncing with DateTime for API rate limit purposes");
Stopwatch stopwatch = new Stopwatch();

DateTime start = DateTime.Now; //Rate limits resets at DateTime.Now ( syncing request start with API ) 
int sleeptime = (60 - start.Second);

Console.WriteLine("Sleeping for: " + sleeptime + " seconds");

Thread.Sleep(sleeptime * 1000);
FinancialModelingRequestProvider financialModelingRequestProvider = new FinancialModelingRequestProvider();

Console.WriteLine("Starting operations");
stopwatch.Start();

string apikey = ""; //apikey here

for (int i = 0; i < tickerList.Count; i++)
{

    try
    {
        Stock_price_change stock_price_change = new Stock_price_change(apikey, tickerList[i]);

        Full_financial_statement full_Financial_Statement = new Full_financial_statement(apikey, tickerList[i]);





        if (i % 150 == 0)
        {
            Console.WriteLine("Waiting.. (rate limit)");
            Console.WriteLine("Time elapsed: " + stopwatch.Elapsed.TotalSeconds);
            Console.WriteLine("Time left: " + (60 - stopwatch.Elapsed.TotalSeconds));

            DateTime start2 = DateTime.Now;
            int sleeptime2 = (60 - start2.Second);
            sleeptime2 = sleeptime2 % 60;
            if (sleeptime2 < 0||sleeptime2<5)
            {
                sleeptime2 = 1;
            }
            else
            {
                sleeptime2 = sleeptime2 * 1000 + 500;
            }
            
            Thread.Sleep(sleeptime2);
            stopwatch.Restart();
        }


        financialModelingRequestProvider.Set(stock_price_change);

        financialModelingRequestProvider.GetAndWrite().Wait();

        if (financialModelingRequestProvider.IsValid == true)
        {

            Console.WriteLine("Stock price change Done: " + financialModelingRequestProvider.ticker);

        }
        else
        {
            Console.WriteLine("Stock price change Failure: " + financialModelingRequestProvider.ticker);


        }
        financialModelingRequestProvider.IsValid = false;

        financialModelingRequestProvider.Set(full_Financial_Statement);

        financialModelingRequestProvider.GetAndWrite().Wait();

        if (financialModelingRequestProvider.IsValid == true)
        {

            Console.WriteLine("Full financial statement Done: " + financialModelingRequestProvider.ticker);

        }
        else
        {
            Console.WriteLine("Full financial statement Failure: " + financialModelingRequestProvider.ticker);


        }

        //if(i%50==0)
        //{
        //    Console.WriteLine("do you want to continue?");
        //if(Console.ReadLine()=="n")
        //{
        //        Console.WriteLine("Quitting enviroment");
        //    break;
        //}

        // }

    }
    catch (Exception e)
    {
        stopwatch.Reset();
        Console.WriteLine(e.Message);
        Console.WriteLine("Error occured, [x] to quit any other key to continue");
        string error = Console.ReadLine();
        
        if (error == "x")
        {
            break;
        }

    }
}

Console.WriteLine("shutdown procedure... do not quit");
string no_data_tickers = File.ReadAllText("../../../../data/meta_data/" + financialModelingRequestProvider.requestType + "/no_data_tickers.txt");
if (no_data_tickers[no_data_tickers.Length].Equals(','))
{
    no_data_tickers = no_data_tickers.Remove(no_data_tickers.Length - 1);
}

string[] strings = no_data_tickers.Split(",");
Hashtable hashtable = new Hashtable();

for (int i = 0; i < strings.Length; i++)
{
    try
    {
        hashtable.Add(strings[i], "");
    }
    catch (Exception) { }
}







