using Essa.Framework.Util.Extensions;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Flurl.Http.Content;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Essa.Framework.Util.Util
{
    public class UntrustedCertClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_a, _b, _c, _d) => true
            };
        }
    }


    public class GenericRest
    {
        protected bool IsSuccessStatusCode { get; private set; } = true;


        public string Servidor { get; protected set; }

        private readonly string _controllerUrl;




        public GenericRest()
        {
            FlurlHttp.ConfigureClient(Servidor, cli =>
            cli.Settings.HttpClientFactory = new UntrustedCertClientFactory());
        }

        public GenericRest(string servidor, string controllerUrl)
        {
            Servidor = servidor;

            _controllerUrl = controllerUrl;


            FlurlHttp.ConfigureClient(Servidor, cli =>
            cli.Settings.HttpClientFactory = new UntrustedCertClientFactory());
        }





        string _token = null;
        public virtual void SetToken(string token)
        {
            _token = token;
        }


        protected Url MontarUrl(string path, object parametros = null)
        {
            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                url.SetQueryParams(parametros);

            return url;
        }
        protected void MontarUrlV2(string servidor, string path, object parametros = null)
        {
            Servidor = servidor;

            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                url.SetQueryParams(parametros);

            _url = new FlurlRequest(url);
        }

        protected void MontarUrlV2(string path, object parametros = null)
        {
            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                url.SetQueryParams(parametros);

            _url = new FlurlRequest(url);
        }

        protected async Task<string> GetStringAsync(string path, object parametros = null)
        {
            Url url = MontarUrl(path, parametros);
            string ret;

            if (!string.IsNullOrEmpty(_token))
                ret = await url.WithOAuthBearerToken(_token).GetStringAsync();
            else
                ret = await url.GetStringAsync();

            return ret;
        }

        protected async Task<T> GetOneAsync<T>(string path, object parametros = null)
        {
            Url url = MontarUrl(path, parametros);
            T ret;

            if (!string.IsNullOrEmpty(_token))
                ret = await url.WithOAuthBearerToken(_token).GetJsonAsync<T>();
            else
                ret = await url.GetJsonAsync<T>();

            return ret;
        }


        protected async Task<IList<dynamic>> GetListAsync(string path, object parametros = null)
        {
            Url url = MontarUrl(path, parametros);

            if (!string.IsNullOrEmpty(_token))
                return await url.WithOAuthBearerToken(_token).GetJsonListAsync();
            else
                return await url.GetJsonListAsync();
        }






        protected FlurlRequest _url;
        public async Task<List<T>> GetListAsync<T>(string path, object parametros = null) where T : class
        {
            Url url = MontarUrl(path, parametros);

            if (!string.IsNullOrEmpty(_token))
                return (await url.WithOAuthBearerToken(_token).GetStringAsync()).ToOjectFromJson<List<T>>();
            else
                return (await url.GetStringAsync()).ToOjectFromJson<List<T>>();
        }
        protected async Task<List<T>> GetListAsync<T>() where T : class
        {
            if (!string.IsNullOrEmpty(_token))
                return (await _url.WithOAuthBearerToken(_token).GetStringAsync()).ToOjectFromJson<List<T>>();
            else
                return (await _url.GetStringAsync()).ToOjectFromJson<List<T>>();
        }







        protected async Task<T> Put<T>(string path, object obj)
        {
            Url url = MontarUrl(path);

            Task<IFlurlResponse> ret;

            if (!string.IsNullOrEmpty(_token))
                ret = url.WithOAuthBearerToken(_token).PutJsonAsync(obj);
            else
                ret = url.PutJsonAsync(obj);

            IsSuccessStatusCode = ret.IsCompleted;

            return await ret.ReceiveJson<T>();
        }






        [Obsolete]
        public async Task<T> Post<T>(string path, object obj)
        {
            try
            {
#if DEBUG
                string json = obj.ToJson();
#endif

                Url url = MontarUrl(path);

                Task<IFlurlResponse> ret;

                if (!string.IsNullOrEmpty(_token))
                    ret = url.WithOAuthBearerToken(_token).PostJsonAsync(obj);
                else
                    ret = url.PostJsonAsync(obj);

                IsSuccessStatusCode = ret.IsCompleted;

                return await ret.ReceiveJson<T>();
            }
            catch (FlurlHttpException ex2)
            {
                throw ex2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Post<T>(object obj)
        {
            try
            {
#if DEBUG
                string json = obj.ToJson();
#endif

                Task<IFlurlResponse> ret;

                if (!string.IsNullOrEmpty(_token))
                    ret = _url.WithOAuthBearerToken(_token).PostJsonAsync(obj);
                else
                    ret = _url.PostJsonAsync(obj);

                IsSuccessStatusCode = ret.IsCompleted;

                return await ret.ReceiveJson<T>();
            }
            catch (FlurlHttpException ex2)
            {
                throw ex2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        protected async Task Post(string path, object obj)
        {
#if DEBUG
            string json = obj.ToJson();
#endif

            Url url = MontarUrl(path);

            Task<IFlurlResponse> ret;

            IFlurlResponse ret2;
            if (!string.IsNullOrEmpty(_token))
                ret2 = await url.WithOAuthBearerToken(_token).PostJsonAsync(obj);
            else
                ret2 = await url.PostJsonAsync(obj);

            IsSuccessStatusCode = ret2.StatusCode >= 200 && ret2.StatusCode <= 299;
        }




        protected async Task<T> Post<T>(string path, string filepath, string nomeparametro, string nomearquivo, object obj)
            where T : class
        {
            try
            {
#if DEBUG
                string json = obj.ToJson();
#endif
                Url url = Servidor;
                url.AppendPathSegments(_controllerUrl, path)
                        .WithHeader("Content-Type", "application/json; charset=utf8")
                        .WithHeader("Accept", "application/json")
                //.OnError(c =>
                //{
                //    int x = 0;
                //})
                ;

                IFlurlResponse ret;

                if (!string.IsNullOrEmpty(_token))
                    ret = await url
                        .WithOAuthBearerToken(_token)
                        .PostMultipartAsync(mp => mp.AddFile(nomeparametro, filepath, fileName: nomearquivo)
                        .AddStringParts(obj)
                        );
                else
                    ret = await url
                         .PostMultipartAsync(mp => mp
                         .AddFile(nomeparametro, filepath, fileName: nomearquivo)
                         .AddStringParts(obj)
                         );


                return await ret.GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                //var error = await ex.GetResponseJsonAsync<TError>();
                //logger.Write($"Error returned from {ex.Call.Request.Url}: {error.SomeDetails}");
            }
            catch (Exception)
            {

            }

            return null;
        }

        protected async Task<T> Post<T>(string path, Action<CapturedMultipartContent> buildContent)
            where T : class
        {
            Url url = MontarUrl(path);

            IFlurlResponse ret;

            if (!string.IsNullOrEmpty(_token))
                ret = await url.WithOAuthBearerToken(_token).PostMultipartAsync(mp => buildContent(mp));
            else
                ret = await url.PostMultipartAsync(mp => buildContent(mp));

            return await ret.GetJsonAsync<T>();
        }



    }
}
