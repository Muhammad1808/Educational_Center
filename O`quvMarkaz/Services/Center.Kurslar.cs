using Models;
using System.Text.Json;
namespace O_quvMarkaz.Services;

public partial class Center
{
    private List<Kurslar> kurslar = new List<Kurslar>();

    string jsonPathKurs = "D:\\OquvMarkaz\\kurslar.json";
    string path = Directory.GetCurrentDirectory();
    string coursepath = path + "kurslar.json";
    public void AddKurs(string name)
    {
         int id = kurslar.Count > 0 ? kurslar.Max(k => k.Id) + 1 : 1;
        kurslar.Add(new Kurslar() { Id = id, Name = name });
        string serialized = JsonSerializer.Serialize(kurslar);
        using (StreamWriter writer = new StreamWriter(coursepath))
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
        using (StreamWriter sw = new StreamWriter(coursepath))
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
        using (StreamWriter sw = new StreamWriter(coursepath))
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
        using (StreamReader reader = new StreamReader(coursepath))
        {
            string json = reader.ReadToEnd();
            kurslar = JsonSerializer.Deserialize<List<Kurslar>>(json);
        }
        return kurslar;
    }
}
