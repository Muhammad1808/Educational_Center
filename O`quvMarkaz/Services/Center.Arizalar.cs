using Models;
using System.Text.Json;

namespace O_quvMarkaz.Services;

public partial class Center
{
    private List<Arizalar> arizalar = new List<Arizalar>();
    string jsonPathAriza = "D:\\OquvMarkaz\\arizalar.json";
    public void AddAriza(string name,string surname,string phoneNumber)
    {
        int id = arizalar.Count > 0 ? arizalar.Max(a => a.Id) + 1 : 1;
        arizalar.Add(new Arizalar() { Id = id, Name = name,SurName=surname,PhoneNumber=phoneNumber });
        string serialized = JsonSerializer.Serialize(arizalar);
        using (StreamWriter writer = new StreamWriter(jsonPathAriza))
        {
            writer.WriteLine(serialized);
        }
    }
    public void UpdateAriza(int id, string name)
    {
        var ariza = arizalar.FirstOrDefault(a => a.Id == id);
        if (ariza != null)
        {
            ariza.Name = name;
        }
        else
        {
            Console.WriteLine("Ariza not found");
        }
        string serialized = JsonSerializer.Serialize<List<Arizalar>>(arizalar);
        using (StreamWriter sw = new StreamWriter(jsonPathAriza))
        {
            sw.WriteLine(serialized);
        }
    }
    public void DeleteAriza(int id)
    {
        var ariza = arizalar.FirstOrDefault(x => x.Id == id);
        if (ariza != null)
        {
            arizalar.Remove(ariza);
            Console.WriteLine("Muvaffaqqiyatli o`chdi");
        }
        else
            Console.WriteLine("Ariza not found");
        string serialized = JsonSerializer.Serialize<List<Arizalar>>(arizalar);
        using (StreamWriter sw = new StreamWriter(jsonPathAriza))
        {
            sw.WriteLine(serialized);
        }
    }
    public void ListArizalar()
    {
        arizalar = JsonReadAriza();
        foreach (var ariza in arizalar)
        {
            Console.WriteLine($"Ariza: {ariza.Id}  , Name: {ariza.Name}, Surname:{ariza.SurName}, PhoneNumber:{ariza.PhoneNumber}");
        }
    }
    public List<Arizalar> JsonReadAriza()
    {
        using (StreamReader reader = new StreamReader(jsonPathAriza))
        {
            string json = reader.ReadToEnd();
            arizalar = JsonSerializer.Deserialize<List<Arizalar>>(json);
        }
        return arizalar;
    }
}
