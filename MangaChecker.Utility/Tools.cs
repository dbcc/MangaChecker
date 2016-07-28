using RestSharp;
using System;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace MangaChecker.Utility
{
    public static class Tools
    {
        public static string DownloadData(string url)
        {
            RestClient _client = new RestClient(url);
            var _request = new RestRequest("", Method.GET);
            _request.Timeout = 5000;

            string _content;
            try
            {
                IRestResponse _response = _client.Execute(_request);
                _content = _response.Content;
            }
            catch (Exception)
            {
                Console.WriteLine($"couldn't open a connection to {url}");
                throw;
            }

            return _content;
        }

        public static SyndicationFeed GetFeed(string url, string provider)
        {
            string _content = Tools.DownloadData(url);

            _content = normalizeXML(_content, provider);

            var _xml = XmlReader.Create(new StringReader(_content));
            var _feed = SyndicationFeed.Load(_xml);

            return _feed;
        }

        private static string normalizeXML(string oldXML, string provider)
        {
            string _newXML;

            switch (provider)
            {
                case Settings.Mangastream:
                    _newXML = Regex.Replace(oldXML, @"&.+;", "A")
                        .Replace("pubDate", "pubDateBroke");
                    break;
                case Settings.Webtoons:
                    _newXML = oldXML.Replace("pubDate", "fuck")
                        .Replace("lastBuildDate", "fuck2");
                    _newXML = Regex.Replace(_newXML, "<img src=\".+\"  />", "");
                    break;
                default:
                    _newXML = oldXML;
                    break;
            }

            return _newXML;
        }
    }
}
