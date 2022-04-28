using System.Net;

Console.WriteLine("Enter service URL:");
string url = Console.ReadLine();

try
{
    var myRequest = (HttpWebRequest)WebRequest.Create(url);

    var response = (HttpWebResponse)myRequest.GetResponse();

    if (response.StatusCode == HttpStatusCode.OK)
    {
        //  it's at least in some way responsive
        //  but may be internally broken
        //  as you could find out if you called one of the methods for real
        Console.WriteLine(string.Format("{0} Available", url));
    }
    else
    {
        //  well, at least it returned...
        Console.WriteLine(string.Format("{0} Returned, but with status: {1}", 
            url, response.StatusDescription));
    }
}
catch (Exception ex)
{
    //  not available at all, for some reason
    Console.WriteLine(string.Format("{0} unavailable: {1}", url, ex.Message));
}
