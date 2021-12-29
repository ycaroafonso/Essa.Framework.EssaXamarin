namespace Essa.Framework.Util.Util
{
    using Essa.Framework.Util.Extensions;
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Content;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class GenericRest
    {
        protected bool IsSuccessStatusCode { get; private set; } = true;


        public string Servidor { get; protected set; }

        private readonly string _controllerUrl;

        public GenericRest(string servidor, string controllerUrl)
        {
            Servidor = servidor;

            _controllerUrl = controllerUrl;
        }

        string _token = null;
        public virtual void SetToken(string token)
        {
            _token = token;
        }



        protected async Task<T> GetOneAsync<T>(string path, object parametros = null)
        {
            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                url.SetQueryParams(parametros);

            T ret;

            if (!string.IsNullOrEmpty(_token))
                ret = await url.WithOAuthBearerToken(_token).GetJsonAsync<T>();
            else
                ret = await url.GetJsonAsync<T>();

            return ret;
        }


        protected async Task<IList<dynamic>> GetListAsync(string path, object parametros = null)
        {
            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);


            if (parametros != null)
                url.SetQueryParams(parametros);

            if (!string.IsNullOrEmpty(_token))
                return await url.WithOAuthBearerToken(_token).GetJsonListAsync();
            else
                return await url.GetJsonListAsync();
        }


        protected async Task<T> Put<T>(string path, object obj)
        {
            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);

            Task<IFlurlResponse> ret;

            if (!string.IsNullOrEmpty(_token))
                ret = url.WithOAuthBearerToken(_token).PutJsonAsync(obj);
            else
                ret = url.PutJsonAsync(obj);

            IsSuccessStatusCode = ret.IsCompleted;

            return await ret.ReceiveJson<T>();
        }




        protected async Task<T> Post<T>(string path, object obj)
        {
#if DEBUG
            string json = obj.ToJson();
#endif

            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);

            Task<IFlurlResponse> ret;

            if (!string.IsNullOrEmpty(_token))
                ret = url.WithOAuthBearerToken(_token).PostJsonAsync(obj);
            else
                ret = url.PostJsonAsync(obj);

            IsSuccessStatusCode = ret.IsCompleted;

            return await ret.ReceiveJson<T>();
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
            Url url = Servidor;
            url.AppendPathSegments(_controllerUrl, path);

            IFlurlResponse ret;

            if (!string.IsNullOrEmpty(_token))
                ret = await url.WithOAuthBearerToken(_token).PostMultipartAsync(mp => buildContent(mp));
            else
                ret = await url.PostMultipartAsync(mp => buildContent(mp));

            return await ret.GetJsonAsync<T>();
        }


    }
}
