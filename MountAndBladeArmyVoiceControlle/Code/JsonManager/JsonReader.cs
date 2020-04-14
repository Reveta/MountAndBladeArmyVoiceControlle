using System.IO;
using Newtonsoft.Json;

namespace MountAndBladeArmyVoiceControlle.Code.JsonManager {
	public class JsonReader<T>  {
		public string PathConfigFile { get; set; }

		public JsonReader(string pathConfigFile) { this.PathConfigFile = pathConfigFile; }

		public T GetNewData() {
			T config = default(T);
			if (this.PathConfigFile != null) {
				using (StreamReader r = new StreamReader(path: this.PathConfigFile)) {
					string json = r.ReadToEnd();
					config = JsonConvert.DeserializeObject<T>(json);
					r.Close();
				}

				return config;
			}

			return config;
		}
	}
}