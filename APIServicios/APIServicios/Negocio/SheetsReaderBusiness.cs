using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace APIServicios.Negocio
{
    public class SheetsReaderBusiness : ISheetsReaderBusiness
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private const string SpreadsheetId = "1uBHZ3C5vACe_saBXWDIVHox6dZWWNTpflGPvlQ5AdA0";
        private const string GoogleCredentialsFileName = "google-credentials.json";
        private const string ReadRange = "Respuestas de formulario 1!A:R";
        private List<Object> listado = new System.Collections.Generic.List<Object>();

        public byte[] readSheet()
        {
            throw new NotImplementedException();
        }

        private  SheetsService GetSheetsService()
        {
            using (var stream = new FileStream(GoogleCredentialsFileName, FileMode.Open, FileAccess.Read))
            {
                var serviceInitializer = new BaseClientService.Initializer
                {
                    HttpClientInitializer = GoogleCredential.FromStream(stream).CreateScoped(Scopes)
                };
                return new SheetsService(serviceInitializer);
            }
        }
            private  async Task<List<Object>> ReadAsync(SpreadsheetsResource.ValuesResource valuesResource)
            {
                var response = await valuesResource.Get(SpreadsheetId, ReadRange).ExecuteAsync();
                var values = response.Values;
                if (values == null || !values.Any())
                {
                    Console.WriteLine("No data found.");
                    return listado;
                }
                var header = string.Join(" ", values.First().Select(r => r.ToString()));
                Console.WriteLine($"Header: {header}");

                foreach (var row in values.Skip(1))
                {
                    var res = string.Join(" ", row.Select(r => r.ToString()));
                //Console.WriteLine(res);
                listado.Add(res);
                }
            return listado;
            }

        public  async Task<List<Object>> startExec()
        {
            var serviceValues = GetSheetsService().Spreadsheets.Values;
            return await ReadAsync(serviceValues);
        }
        }
}
