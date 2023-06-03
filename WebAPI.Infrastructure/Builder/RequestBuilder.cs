using Newtonsoft.Json;
using RestSharp;

namespace WebAPI.Infrastructure.Builder;

public class RequestBuilder
{
    private RestRequest _restRequest;

    public RequestBuilder SetUrl(string url)
    {
        _restRequest = new RestRequest(url);
        return this;
    }
    
    public RequestBuilder SetPostUrl(string url)
    {
        _restRequest = new RestRequest(url, Method.Post);
        return this;
    }
    public RequestBuilder SetDeleteUrl(string url)
    {
        _restRequest = new RestRequest(url, Method.Delete);
        return this;
    }

    public RequestBuilder SetUpdateUrl(string url)
    {
        _restRequest = new RestRequest(url, Method.Put);
        return this;
    }
    
    public RequestBuilder SetHeader(string key, string value)
    {
        _restRequest.AddHeader(key, value);
        return this;
    }


    public RequestBuilder SetBody<T>(T body) where T : class
    {
        _restRequest.AddJsonBody(body);
        return this;
    }
    
    public RestRequest Build()
    {
        return _restRequest;
    }
}