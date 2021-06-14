using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace BooksAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var Object = Console.ReadLine();
            var ApiKey = "AIzaSyA8oEfF1lkN5NqwThgGVAB_2vJLVBxxZDM";
            var url = $"https://www.googleapis.com/books/v1/volumes?q={Object}&filter=free-ebooks&key={ApiKey}";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var books = JsonConvert.DeserializeObject<Root>(result);
                Console.WriteLine(books.items[2].volumeInfo.title + Environment.NewLine + books.items[2].volumeInfo.authors[0]
                    + Environment.NewLine + books.items[2].volumeInfo.publishedDate);
            }
            Console.ReadLine();

        }
    }

    public class IndustryIdentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public class ReadingModes
    {
        public bool text { get; set; }
        public bool image { get; set; }
    }

    public class PanelizationSummary
    {
        public bool containsEpubBubbles { get; set; }
        public bool containsImageBubbles { get; set; }
    }

    public class ImageLinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string publishedDate { get; set; }
        public List<IndustryIdentifier> industryIdentifiers { get; set; }
        public ReadingModes readingModes { get; set; }
        public int pageCount { get; set; }
        public string printType { get; set; }
        public string maturityRating { get; set; }
        public bool allowAnonLogging { get; set; }
        public string contentVersion { get; set; }
        public PanelizationSummary panelizationSummary { get; set; }
        public ImageLinks imageLinks { get; set; }
        public string language { get; set; }
        public string previewLink { get; set; }
        public string infoLink { get; set; }
        public string canonicalVolumeLink { get; set; }
        public List<string> categories { get; set; }
        public string subtitle { get; set; }
    }

    public class SaleInfo
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
        public string buyLink { get; set; }
    }

    public class Epub
    {
        public bool isAvailable { get; set; }
        public string downloadLink { get; set; }
    }

    public class Pdf
    {
        public bool isAvailable { get; set; }
        public string downloadLink { get; set; }
    }

    public class AccessInfo
    {
        public string country { get; set; }
        public string viewability { get; set; }
        public bool embeddable { get; set; }
        public bool publicDomain { get; set; }
        public string textToSpeechPermission { get; set; }
        public Epub epub { get; set; }
        public Pdf pdf { get; set; }
        public string webReaderLink { get; set; }
        public string accessViewStatus { get; set; }
        public bool quoteSharingAllowed { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public string selfLink { get; set; }
        public VolumeInfo volumeInfo { get; set; }
        public SaleInfo saleInfo { get; set; }
        public AccessInfo accessInfo { get; set; }
    }

    public class Root
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public List<Item> items { get; set; }
    }



}
