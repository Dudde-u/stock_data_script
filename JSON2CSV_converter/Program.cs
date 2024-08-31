
using JsonSerializer = System.Text.Json.JsonSerializer;

//data sets: Core_Metrics, Full_Financial_Statement,
//Label: Stock_Price_Change (part of it)

string StockPriceChangePath = "../../../../data/stock_price_change";

StockPriceChangePath = Path.GetFullPath(StockPriceChangePath);


string CoreMetricsPath = "../../../../data/core_metrics";
CoreMetricsPath = Path.GetFullPath(CoreMetricsPath);
string financialStatementPath = "../../../../data/full_financial_statement";
financialStatementPath = Path.GetFullPath(financialStatementPath);

string[] stockPriceFiles = Directory.GetFiles(StockPriceChangePath);
string[] coreMetricsFiles = Directory.GetFiles(CoreMetricsPath);
string[] financialStatementFiles = Directory.GetFiles(financialStatementPath);

string[] allTickers=File.ReadAllText("../../../../data/AllTickers.txt").Split(",");
List<string> tickersWithData = new List<string>();
for (int i = 0; i < allTickers.Length; i++)
{
    if (stockPriceFiles.Contains(StockPriceChangePath + "\\" + allTickers[i] + ".txt") && coreMetricsFiles.Contains(CoreMetricsPath + "\\" + allTickers[i] + ".txt") && financialStatementFiles.Contains(financialStatementPath + "\\" + allTickers[i] + ".txt"))
    {
        tickersWithData.Add(allTickers[i]);
        Console.WriteLine(allTickers[i]);
    }
}
Console.WriteLine(tickersWithData.Count);
Console.ReadKey();

//List<StockPriceChange> stockPriceChanges = new List<StockPriceChange>();
//for (int i = 0; i < tickersWithData.Count; i++)
//{
//    try
//    {
//        string temp = File.ReadAllText(StockPriceChangePath + "/" + tickersWithData[i] + ".txt");
//        StockPriceChange stockPriceChange = JsonSerializer.Deserialize<StockPriceChange>(temp);
//        Console.WriteLine(stockPriceChange.symbol);
        
//    }
//    catch 
//    {
//        Console.WriteLine("There was an issue, press key to contiue. Issue ticker" + tickersWithData[i]);
//       Console.WriteLine("Type StockPriceChange");
//    }

//}
for (int i = 0; i < tickersWithData.Count; i++)
{
    try
    {
        string path = CoreMetricsPath + "\\" + tickersWithData[i] + ".txt";

        path = Path.Combine(CoreMetricsPath, tickersWithData[i] + ".txt");
        string temp = File.ReadAllText(path);


             CoreMetrics coreMetrics = JsonSerializer.Deserialize<CoreMetrics>(temp);
        Console.WriteLine(coreMetrics.symbol);
    }
    catch
    {
        Console.WriteLine("There was an issue, press key to contiue. Issue ticker" + tickersWithData[i]);
        Console.WriteLine("Type CoreMetrics");
    }
}
for (int i = 0; i < tickersWithData.Count; i++)
{
    try
    {
        string temp = File.ReadAllText(financialStatementPath + "/" + tickersWithData[i] + ".txt");
        FinancialStatement financialStatement = JsonSerializer.Deserialize<FinancialStatement>(temp);
        Console.WriteLine(financialStatement.symbol);
    }
    catch
    {
        Console.WriteLine("There was an issue, press key to contiue. Issue ticker" + tickersWithData[i]);
       Console.WriteLine("Type FinancialStatement");
    }
}
Console.ReadKey();
public class CoreMetrics
{
    public string symbol { get; set; }
    public string date { get; set; }
    public string calendarYear { get; set; }
    public string period { get; set; }
    public double revenuePerShare { get; set; }
    public double netIncomePerShare { get; set; }
    public double operatingCashFlowPerShare { get; set; }
    public double freeCashFlowPerShare { get; set; }
    public double? cashPerShare { get; set; }
    public double? bookValuePerShare { get; set; }
    public double? tangibleBookValuePerShare { get; set; }
    public double? shareholdersEquityPerShare { get; set; }
    public double? interestDebtPerShare { get; set; }
    public double marketCap { get; set; }
    public double? enterpriseValue { get; set; }
    public double peRatio { get; set; }
    public double priceToSalesRatio { get; set; }
    public double pocfratio { get; set; }
    public double pfcfRatio { get; set; }
    public double pbRatio { get; set; }
    public double ptbRatio { get; set; }
    public double? evToSales { get; set; }
    public double? enterpriseValueOverEBITDA { get; set; }
    public double? evToOperatingCashFlow { get; set; }
    public double? evToFreeCashFlow { get; set; }
    public double earningsYield { get; set; }
    public double freeCashFlowYield { get; set; }
    public double debtToEquity { get; set; }
    public double debtToAssets { get; set; }
    public double? netDebtToEBITDA { get; set; }
    public double currentRatio { get; set; }
    public double interestCoverage { get; set; }
    public double incomeQuality { get; set; }
    public double dividendYield { get; set; }
    public double payoutRatio { get; set; }
    public double salesGeneralAndAdministrativeToRevenue { get; set; }
    public double researchAndDdevelopementToRevenue { get; set; }
    public double intangiblesToTotalAssets { get; set; }
    public double capexToOperatingCashFlow { get; set; }
    public double capexToRevenue { get; set; }
    public double capexToDepreciation { get; set; }
    public double stockBasedCompensationToRevenue { get; set; }
    public double? grahamNumber { get; set; }
    public double roic { get; set; }
    public double returnOnTangibleAssets { get; set; }
    public double? grahamNetNet { get; set; }
    public double? workingCapital { get; set; }
    public double? tangibleAssetValue { get; set; }
    public double? netCurrentAssetValue { get; set; }
    public double investedCapital { get; set; }
    public double? averageReceivables { get; set; }
    public double? averagePayables { get; set; }
    public double? averageInventory { get; set; }
    public double? daysSalesOutstanding { get; set; }
    public double? daysPayablesOutstanding { get; set; }
    public double? daysOfInventoryOnHand { get; set; }
    public double receivablesTurnover { get; set; }
    public double payablesTurnover { get; set; }
    public double inventoryTurnover { get; set; }
    public double roe { get; set; }
    public double capexPerShare { get; set; }
}
public class FinancialStatement
{
 
        public string date { get; set; }
    public string symbol { get; set; }
    public string period { get; set; }
    public string documenttype { get; set; }
    public string amendmentflag { get; set; }
    public string documentannualreport { get; set; }
    public string documenttransitionreport { get; set; }
    public string documentperiodenddate { get; set; }
    public string documentfiscalperiodfocus { get; set; }
    public int documentfiscalyearfocus { get; set; }
    public string currentfiscalyearenddate { get; set; }
    public string entityfilenumber { get; set; }
    public string entityregistrantname { get; set; }
    public int entitycentralindexkey { get; set; }
    public string entitytaxidentificationnumber { get; set; }
    public string entityincorporationstatecountrycode { get; set; }
    public string entityaddressaddressline1 { get; set; }
    public string entityaddressaddressline2 { get; set; }
    public string entityaddresscityortown { get; set; }
    public string entityaddressstateorprovince { get; set; }
    public int entityaddresspostalzipcode { get; set; }
    public object cityareacode { get; set; }
    public string localphonenumber { get; set; }
    public string security12btitle { get; set; }
    public string tradingsymbol { get; set; }
    public string securityexchangename { get; set; }
    public string entitywellknownseasonedissuer { get; set; }
    public string entityvoluntaryfilers { get; set; }
    public string entitycurrentreportingstatus { get; set; }
    public string entityinteractivedatacurrent { get; set; }
    public string entityfilercategory { get; set; }
    public string entitysmallbusiness { get; set; }
    public string entityemerginggrowthcompany { get; set; }
    public string entityshellcompany { get; set; }
    public string entityextransitionperiod { get; set; }
    public string icfrauditorattestationflag { get; set; }
    public string documentfinstmterrorcorrectionflag { get; set; }
    public string auditorname { get; set; }
    public int auditorfirmid { get; set; }
    public string auditorlocation { get; set; }
    public double cash { get; set; }
    public double prepaidexpensecurrent { get; set; }
    public double assetscurrent { get; set; }
    public double assetsheldintrust { get; set; }
    public double assets { get; set; }
    public double accountspayablecurrent { get; set; }
    public double accrualfortaxesotherthanincometaxescurrent { get; set; }
    public double accruedincometaxescurrent { get; set; }
    public double notespayablecurrent { get; set; }
    public double salesandexcisetaxpayablecurrent { get; set; }
    public double liabilitiescurrent { get; set; }
    public double temporaryequitycarryingamountattributabletoparent { get; set; }
    public double commonstockvalue { get; set; }
    public double retainedearningsaccumulateddeficit { get; set; }
    public double stockholdersequity { get; set; }
    public double liabilitiesandstockholdersequity { get; set; }
    public double temporaryequitysharesoutstanding { get; set; }
    public double temporaryequityredemptionpricepershare { get; set; }
    public double preferredstockparorstatedvaluepershare { get; set; }
    public double preferredstocksharesauthorized { get; set; }
    public double commonstockparorstatedvaluepershare { get; set; }
    public double commonstocksharesauthorized { get; set; }
    public double commonstocksharesissued { get; set; }
    public double commonstocksharesoutstanding { get; set; }
    public double operatingexpenses { get; set; }
    public double allocatedsharebasedcompensationexpense { get; set; }
    public double operatingincomeloss { get; set; }
    public double trustinterestincome { get; set; }
    public double othernonoperatingincome { get; set; }
    public double incomelossfromcontinuingoperationsbeforeincometaxesextraordinaryitemsnoncontrollinginterest { get; set; }
    public double incometaxexpensebenefit { get; set; }
    public double netincomeloss { get; set; }
    public double weightedaveragenumberofsharesoutstandingbasic { get; set; }
    public double weightedaveragenumberofdilutedsharesoutstanding { get; set; }
    public double earningspersharebasic { get; set; }
    public double earningspersharediluted { get; set; }
    public int adjustmentstoadditionalpaidincapitalsharebasedcompensationrequisiteserviceperiodrecognitionvalue { get; set; }
    public int capitalcontributionreceivedrelatedtoshareholdernonredemptionagreementsvalue { get; set; }
    public int adjustmenttoadditionalpaidincapitalrelatedtoshareholdernonredemptionagreements { get; set; }
    public int excisetaxpayableonredemption { get; set; }
    public int temporaryequityotherchanges { get; set; }
    public int investmentincomeinterest { get; set; }
    public int sharebasedcompensation { get; set; }
    public int increasedecreaseinprepaidexpense { get; set; }
    public int increasedecreaseinaccountspayable { get; set; }
    public int increasedecreaseinpropertyandothertaxespayable { get; set; }
    public int increasedecreaseinaccruedincometaxespayable { get; set; }
    public int netcashprovidedbyusedinoperatingactivities { get; set; }
    public int proceedfromtrustforredemptionsofcommonstock { get; set; }
    public int proceedsfromtrustaccountforthepaymentoftaxes { get; set; }
    public int paymentstoacquireinvestments { get; set; }
    public int netcashprovidedbyusedininvestingactivities { get; set; }
    public int proceedsfromnotespayable { get; set; }
    public int repaymentsofnotespayable { get; set; }
    public int paymentsinrespectofcommonstocksubjecttopossibleredemption { get; set; }
    public int netcashprovidedbyusedinfinancingactivities { get; set; }
    public int cashcashequivalentsrestrictedcashandrestrictedcashequivalentsperiodincreasedecreaseincludingexchangerateeffect { get; set; }
    public int cashcashequivalentsrestrictedcashandrestrictedcashequivalents { get; set; }
    public int remeasurementofcommonstocksubjecttopossibleredemption { get; set; }
    public int excisetaxonredemption { get; set; }
    public string entityincorporationdateofincorporation { get; set; }
    public int operatingaccount { get; set; }
    public int investmentsoldnotyetpurchasedsaleproceeds { get; set; }
    public int sponsorfees { get; set; }
    public int proceedsfromsaleofrestrictedinvestments { get; set; }
    public int temporaryequityaccretiontoredemptionvalue { get; set; }
    public string thresholddateforconsummationofbusinesscombination { get; set; }
    public int networkingcapitalexcludingexcisetaxandfranchisetaxpayable { get; set; }
    public int temporaryequitystockredeemedduringtheperiodvalue { get; set; }
    public int cashandcashequivalentsatcarryingvalue { get; set; }
    public int federaldepositinsurancecorporationpremiumexpense { get; set; }
    public int stockissuedduringperiodsharesconversionofconvertiblesecurities { get; set; }
    public int numberofindependentdirectors { get; set; }
    public int sharebasedcompensationarrangementbysharebasedpaymentawardoptionsvestednumberofshares { get; set; }
    public int sharebasedcompensationarrangementbysharebasedpaymentawardoptionsremainingnumberofsharesvested { get; set; }
    public string periodafterbusinesscombinationfortransferofshares { get; set; }
    public string periodfrominitialpublicofferingclosingtocompleteacquisitionforwaiverofdistributionrights { get; set; }
    public string extendedperiodfrominitialpublicofferingclosingtocompleteacquisitionforwaiverofdistributionrights { get; set; }
    public int paymentforservices { get; set; }
    public int operatingcostsandexpenses { get; set; }
    public int administrativefeesexpense { get; set; }
    public int lineofcreditfacilitymaximumamountoutstandingduringperiod { get; set; }
    public int successfeepayable { get; set; }
    public int otherliabilities { get; set; }
    public int advisoryfeepayableonconsummationofbusinesscombination { get; set; }
    public int longtermpurchasecommitmentamount { get; set; }
    public int tradingsecuritiesdebtamortizedcost { get; set; }
    public int tradingsecuritiesdebt { get; set; }
    public string commonstockvotingrights { get; set; }
    public double classofwarrantorrightexercisepriceofwarrantsorrights1 { get; set; }
    public string warrantexercisableperiodafterbusinesscombination { get; set; }
    public string warrantcashlessexerciseperiodafterbusinesscombination { get; set; }
    public string periodoftradingdaystodeterminefairmarketvalueofcommonstock { get; set; }
    public double warrantsredemptionpricepershare { get; set; }
    public string noticeperiodforwarrantsredemption { get; set; }
    public int commonstocksharepricepershareforwarrantsredemption { get; set; }
    public string periodoftradingdayswithinspecifiedwindowforminimumcommonstockpriceforwarrantsredemption { get; set; }
    public string tradingdaysspecifiedwindowforminimumcommonstockpriceforwarrantsredemption { get; set; }
    public double commonstockissuepricepersharebelowwhichtriggerswarrantadjustment { get; set; }
    public double percentageofavailableequityproceedsbelowspecifiedpricewhichtriggerswarrantadjustment { get; set; }
    public double commonstockmarketvaluepersharebelowwhichtriggerswarrantadjustment { get; set; }
    public double percentageofmarketvalueforwarrantexercisepriceadjustment { get; set; }
    public int deferredtaxassetstaxdeferredexpenseother { get; set; }
    public int deferredtaxassetstaxdeferredexpensecompensationandbenefitssharebasedcompensationcost { get; set; }
    public int deferredtaxassetsgross { get; set; }
    public int deferredtaxassetsvaluationallowance { get; set; }
    public int currentfederaltaxexpensebenefit { get; set; }
    public int deferredfederalincometaxexpensebenefit { get; set; }
    public int incometaxexpensebenefitcontinuingoperationsadjustmentofdeferredtaxassetliability { get; set; }
    public double effectiveincometaxratereconciliationatfederalstatutoryincometaxrate { get; set; }
    public double effectiveincometaxratereconciliationprioryearincometaxes { get; set; }
    public double effectiveincometaxratereconciliationotheradjustments { get; set; }
    public double effectiveincometaxratereconciliationchangeindeferredtaxassetsvaluationallowance { get; set; }
    public double effectiveincometaxratecontinuingoperations { get; set; }
    public int valuationallowancedeferredtaxassetchangeinamount { get; set; }
    public int? notespayablerelatedpartiesclassifiedcurrent { get; set; }
    public int? additionalpaidincapital { get; set; }
    public int? noninterestincomeotheroperatingincome { get; set; }
    public int? stockissuedduringperiodsharesnewissues { get; set; }
    public int? forfeitureoffoundershares { get; set; }
    public int? forfeiturefoundershares { get; set; }
    public int? interestearnedoncashandmarketablesecuritiesheldinvestmentsheldintrustaccount { get; set; }
    public int? proceedsfromissuanceofprivateplacement { get; set; }
    public int? subsequentmeasurementofcommonstocksubjecttopossibleredemption { get; set; }
    public int? sharesissuedpricepershare { get; set; }
    public string maturityperiodofgovernmentsecurities { get; set; }
    public int? debtsecuritiesheldtomaturityexcludingaccruedinterestafterallowanceforcreditlossnoncurrent { get; set; }
    public int? heldtomaturitysecuritiesaccumulatedunrecognizedholdinggain { get; set; }
    public int? debtsecuritiesheldtomaturityfairvaluenoncurrent { get; set; }
    public int? temporaryequitysubsequentaccretiontoredemptionvalue { get; set; }
    public int? sharebasedcompensationrecognizedforsharesvested { get; set; }
    public int? numberofsharesforfeited { get; set; }
    public string debtinstrumentmaturitydate { get; set; }
    public int? debtconversionoriginaldebtamount1 { get; set; }
    public int? debtinstrumentconvertibleconversionprice1 { get; set; }
    public int? relatedpartytransactionexpensesfromtransactionswithrelatedparty { get; set; }
    public int? prepaidexpensenoncurrent { get; set; }
    public int? accountspayableandaccruedliabilitiescurrent { get; set; }
    public int? taxespayablecurrent { get; set; }
    public int? accruedliabilitiescurrent { get; set; }
    public int? commonstockothersharesoutstanding { get; set; }
    public int? nonoperatingincomeexpense { get; set; }
    public int? weightedaveragenumberofshareoutstandingbasicanddiluted { get; set; }
    public double? earningspersharebasicanddiluted { get; set; }
    public int? weightedaveragenumberofsharescommonstocksubjecttorepurchaseorcancellation { get; set; }
    public int? stockissuedduringperiodvalueissuedforservices { get; set; }
    public int? stockissuedduringperiodsharesissuedforservices { get; set; }
    public int? stockissuedduringperiodvalueother { get; set; }
    public int? stockissuedduringperiodsharesother { get; set; }
    public int? stockrepurchasedandretiredduringperiodvalue { get; set; }
    public int? stockrepurchasedandretiredduringperiodshares { get; set; }
    public int? stockissuedduringperiodvaluenewissues { get; set; }
    public int? adjustmentstoadditionalpaidincapitalwarrantissued { get; set; }
    public int? adjustmentforamortization { get; set; }
    public int? increasedecreaseinaccruedliabilities { get; set; }
    public int? proceedsfromissuanceinitialpublicoffering { get; set; }
    public int? proceedsfromissuanceofcommonstock { get; set; }
    public int? proceedsfromrelatedpartydebt { get; set; }
    public int? paymentsofstockissuancecosts { get; set; }
    public int? repaymentsofrelatedpartydebt { get; set; }
    public int? othersignificantnoncashtransactionvalueofconsiderationgiven1 { get; set; }
    public int? stockissued1 { get; set; }
    public int? workingcapital { get; set; }
    public int? temporaryequitystockissuedduringperiodvaluenewissues { get; set; }
    public int? proceedsfromissuanceofwarrants { get; set; }
    public int? temporaryequityissuancecosts { get; set; }
    public int? otheraccruedliabilitiescurrent { get; set; }
    public int? deferredtaxassetsoperatinglosscarryforwardsdomestic { get; set; }
    public int? operatinglosscarryforwards { get; set; }
}

public class Historical
{
    public string? date { get; set; }
    public double? open { get; set; }
    public double? high { get; set; }
    public double? low { get; set; }
    public double? close { get; set; }
    public double? adjClose { get; set; }
    public double? volume { get; set; }
    public double? unadjustedVolume { get; set; }
    public double? change { get; set; }
    public double? changePercent { get; set; }
    public double? vwap { get; set; }
    public string? label { get; set; }
    public double? changeOverTime { get; set; }
}

public class StockPriceChange
{
    public string? symbol { get; set; }
    public List<Historical>? historical { get; set; }
}
