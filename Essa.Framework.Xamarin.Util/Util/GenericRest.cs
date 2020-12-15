namespace Essa.Framework.Util.Util
{
    using Essa.Framework.Util.Extensions;
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Content;
    using System;
    using System.Threading.Tasks;


    public class GenericRest
    {
        protected bool IsSuccessStatusCode { get; private set; } = true;


        Url _url;
        private readonly string _servidor;
        private readonly string _controllerUrl;

        public GenericRest(string servidor, string controllerUrl)
        {
            _url = servidor;
            _servidor = servidor;
            _controllerUrl = controllerUrl;
        }

        protected async Task<T> GetOneAsync<T>(string path, object parametros = null)
        {
            _url = _servidor;
            _url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                _url.SetQueryParams(parametros);

            var ret = await _url.GetJsonAsync<T>();

            return ret;
            //      catch (FlurlHttpException ex)
            //{
            //    var status = ex.Call.HttpResponseMessage.StatusCode;
            //    var message = await ex.GetResponseStringAsync();

            //    IsSuccessStatusCode = false;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }


        protected async Task<T> Post<T>(string path, object obj)
        {
            _url = _servidor;
            _url.AppendPathSegments(_controllerUrl, path);

            var ret = _url.PostJsonAsync(obj);
            IsSuccessStatusCode = ret.IsCompleted;

            return await ret.ReceiveJson<T>();
        }




        protected async Task<T> Post<T>(string path, byte[] upfilebytes, string nomeparametro, string nomearquivo, object obj)
            where T : class
        {
            _url = _servidor;
            _url.AppendPathSegments(_controllerUrl, path);

            var ret = await _url.PostMultipartAsync(mp => mp
                   .AddFile(nomeparametro, upfilebytes.ToStream(), fileName: nomearquivo)
                   .AddStringParts(obj)
                   );

            return await ret.GetJsonAsync<T>();
        }

        protected async Task<T> Post<T>(string path, Action<CapturedMultipartContent> buildContent)
            where T : class
        {
            _url = _servidor;
            _url.AppendPathSegments(_controllerUrl, path);

            var ret = await _url.PostMultipartAsync(mp => buildContent(mp));

            return await ret.GetJsonAsync<T>();
        }


    }
}
