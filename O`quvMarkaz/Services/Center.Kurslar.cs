using Models;
using System.Text.Json;
namespace O_quvMarkaz.Services;

public partial class Center
{
    private List<Kurslar> kurslar = new List<Kurslar>();

    string jsonPathKurs = "D:\\OquvMarkaz\\kurslar.json";
    public void AddKurs(string name)
    {
        string path = Directory.GetCurrentDirectory();
        string coursepath = path + "D:\\OquvMarkaz\\kurslar.json";
        string applicationpath = path + "D:\\OquvMarkaz\\arizalar.json";
        string mentorpath=path+"D:\\OquvMarkaz\\mentorlar.json";

         int id = kurslar.Count > 0 ? kurslar.Max(k => k.Id) + 1 : 1;
        kurslar.Add(new Kurslar() { Id = id, Name = name });
        string serialized = JsonSerializer.Serialize(kurslar);
        using (StreamWriter writer = new StreamWriter(jsonPathKurs))
        {
            writer.WriteLine(serialized);
        }
    }
    public void UpdateKurs(int id, string name)
    {
        var kurs = kurslar.FirstOrDefault(k => k.Id == id);
        if (kurs != null)
        {
            kurs.Name = name;
            Console.WriteLine("Muvaffaqqiyatli o`zgardi");

        }
        else
        {
            Console.WriteLine("Kurs not found");
        }

        string serialized = JsonSerializer.Serialize<List<Kurslar>>(kurslar);
        using (StreamWriter sw = new StreamWriter(jsonPathKurs))
        {
            sw.WriteLine(serialized);
        }
    }
    public void DeleteKurs(int id)
    {
        var kurs = kurslar.FirstOrDefault(x => x.Id == id);
        if (kurs != null)
        {
            kurslar.Remove(kurs);
            Console.WriteLine("Muvaffaqqiyatli o`chdi");
        }
        else
            Console.WriteLine("Kurs not found");
        string serialized = JsonSerializer.Serialize<List<Kurslar>>(kurslar);
        using (StreamWriter sw = new StreamWriter(jsonPathKurs))
        {
            sw.WriteLine(serialized);
        }
    }
    public void ListKurslar()
    {
        kurslar = JsonReadKurs();
        foreach (var kurs in kurslar)
        {
            Console.WriteLine($"Kurs: {kurs.Id}  , Name: {kurs.Name}");
        }
    }
    public List<Kurslar> JsonReadKurs()
    {
        using (StreamReader reader = new StreamReader(jsonPathKurs))
        {
            string json = reader.ReadToEnd();
            kurslar = JsonSerializer.Deserialize<List<Kurslar>>(json);
        }
        return kurslar;
    }
}
