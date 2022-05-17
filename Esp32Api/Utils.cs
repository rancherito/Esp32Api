namespace Esp32Api
{
    public class Utils
    {
        public static Response<T> CreateResponseErrorServer<T>()
        {
            return CreateResponseError<T>(Message: "SIN RESPUESTA DEL SERVIDOR");
        }
        public static Response<T> CreateResponseErrorData<T>()
        {
            return CreateResponseError<T>(Message: "SIN DATOS RECIBIDOS");
        }
        public static Response<T> CreateResponseError<T>(string Message)
        {
            return new Response<T> { IsSuccess = false, Message = Message };
        }
        public static Response CreateResponseErrorServer()
        {
            return CreateResponseError(Message: "SIN RESPUESTA DEL SERVIDOR");
        }
        public static Response CreateResponseErrorData()
        {
            return CreateResponseError(Message: "SIN DATOS RECIBIDOS");
        }
        public static Response CreateResponseError(string Message)
        {
            return new Response { IsSuccess = false, Message = Message };
        }

        public async static Task<Response<T>> HttpGet<T>(HttpClient httpClient, string url)
        {
            try
            {
                var res = await httpClient.GetFromJsonAsync<Response<T>>(url);
                if (res != null && res.IsSuccess) return res;
                return CreateResponseError<T>(res?.Message ?? "SIN DATOS OBTENIDOS");
            }
            catch (Exception e)
            {
                return CreateResponseError<T>($"Cliente: {e.Message}");
            }
        }
        public async static Task<Response> HttpGet(HttpClient httpClient, string url)
        {
            try
            {
                var res = await httpClient.GetFromJsonAsync<Response>(url);
                if (res != null && res.IsSuccess) return res;
                return CreateResponseError(res?.Message ?? "SIN DATOS OBTENIDOS");
            }
            catch (Exception e)
            {
                return CreateResponseError(e.Message);
            }
        }

        public static Response CreateResponseSuccess(string Message)
        {
            return new Response { IsSuccess = true, Message = Message };
        }
        public static Response<T> CreateResponseSuccess<T>(string Message, T Data)
        {
            return new Response<T> { IsSuccess = true, Message = Message, Data = Data };
        }

        public static Response CreateResponseSuccess()
        {
            return CreateResponseSuccess("OK");
        }
        public static Response<T> CreateResponseSuccess<T>(T Data)
        {
            return CreateResponseSuccess("OK", Data);
        }
        public async static Task<Response<TypeGet>> HttpPost<TypeSend, TypeGet>(HttpClient httpClient, string url, TypeSend Data)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync(url, Data);

                if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var res2 = await res.Content.ReadFromJsonAsync<Response<TypeGet>>();
                    if (res2 != null && res2.IsSuccess && res2.Data != null) return res2;
                    return CreateResponseError<TypeGet>(res2?.Message ?? "SIN DATOS OBTENIDOS");
                }
                return CreateResponseError<TypeGet>(res?.ReasonPhrase ?? "ERROR EN EL SERVIDOR");

            }
            catch (Exception e)
            {
                return CreateResponseError<TypeGet>(e.Message);
            }
        }

        public async static Task<Response> HttpPost<TypeSend>(HttpClient httpClient, string url, TypeSend Data)
        {
            try
            {
                var res = await httpClient.PostAsJsonAsync(url, Data);

                if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var res2 = await res.Content.ReadFromJsonAsync<Response>();
                    if (res2 != null && res2.IsSuccess) return res2;
                    return CreateResponseError(res2?.Message ?? "SIN DATOS OBTENIDOS");
                }
                return CreateResponseError(res?.ReasonPhrase ?? "ERROR EN EL SERVIDOR");

            }
            catch (Exception e)
            {
                return CreateResponseError(e.Message);
            }
        }

    }
}
