using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GameSystem.Utils.Save;

public static class SaveFileHandling
{
	public const string FolderPath = "%appdata%\\";

	public static void Save(Dictionary<string, Dictionary<string, dynamic>> saveData)
	{
		File.WriteAllText(FolderPath, JsonConvert.SerializeObject(saveData));
	}

	public static Dictionary<string, Dictionary<string, dynamic>> Load()
	{
		return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, dynamic>>>(
			File.ReadAllText(FolderPath));
	}
}