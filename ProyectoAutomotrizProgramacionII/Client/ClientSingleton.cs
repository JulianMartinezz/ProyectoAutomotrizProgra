﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomotrizProgramacionII.Client
{
    internal class ClientSingleton
    {
        private static ClientSingleton instance;
        private HttpClient client;
        public ClientSingleton()
        {
            client = new HttpClient();
        }
        public static ClientSingleton ObtenerCliente() {
            if (instance == null) instance = new ClientSingleton();
            return instance;
        }
        public async Task<string> GetAsync(string url)
        {
            var result = await client.GetAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> PostAsync(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
            "application/json");
            var result = await client.PostAsync(url, content);
            var response = "";
            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            return response;
        }
    }
}
