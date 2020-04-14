using System.IO;
using Newtonsoft.Json;

namespace MountAndBladeArmyVoiceControlle.Code.JsonManager {
	public class JsonGenerator<T> {
		public void GenerateTo(string fullPath, T obj) {
			string serializeObject = JsonConvert.SerializeObject(obj);

			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
			File.Create(fullPath).Close();
			File.WriteAllText(fullPath, serializeObject);
		}
	}
}