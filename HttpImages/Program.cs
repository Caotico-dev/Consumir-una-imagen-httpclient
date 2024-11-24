
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string imageUrl = "https://picsum.photos/200/300";

        string savepath = "C:\\Temp\\ima.jpg";

        if (!Directory.Exists(@"C:\Temp"))
        {
            Directory.CreateDirectory(@"C:\Temp");
        }

        await DownloadImageAsync(imageUrl, savepath);

        Console.ReadKey();

    }
    static async Task DownloadImageAsync(string url, string savepath)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                var status = response.EnsureSuccessStatusCode();

                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

                await File.WriteAllBytesAsync(savepath, imageBytes);

                Console.WriteLine("Imagen guardada con exito!");

                Console.WriteLine($"imagen en bytes: Longitud:{imageBytes.Length} cadena de bytes:{imageBytes.ToString()}");





            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }

}

