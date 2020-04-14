using System.Collections.Generic;
using MountAndBladeArmyVoiceControlle.Code.JsonManager;
using MountAndBladeArmyVoiceControlle.Code.JsonManager.Structures;

namespace MountAndBladeArmyVoiceControlle {
	public class ConfigJsonGenerator {
		public void Generate() {
			JsonGenerator<KeyboardConfig> generator = new JsonGenerator<KeyboardConfig>();
			Dictionary<string,List<string>> dictionary = new Dictionary<string, List<string>>(){};
			dictionary.Add("Infantry", new List<string>{"1"});
			dictionary.Add("Archers", new List<string>{"2"});
			dictionary.Add("Cavalry", new List<string>{"3"});
			dictionary.Add("HorseBowman", new List<string>{"4"});
			dictionary.Add("Band", new List<string>{"5"});
			dictionary.Add("Everybody", new List<string>{"0"});

			dictionary.Add("ToPosition", new List<string> {"f1", "f1"});
			dictionary.Add("FollowMe", new List<string> {"f1", "f2"});
			dictionary.Add("Attack", new List<string> {"f1", "f3"});
			dictionary.Add("Charge", new List<string> {"f1", "f3"});
			dictionary.Add("Advance", new List<string> {"f1", "f4"});
			dictionary.Add("Fallback", new List<string> {"f1", "f5"});
			dictionary.Add("Stop", new List<string> {"f1", "f6"});
			dictionary.Add("Retreat", new List<string> {"f1", "f7"});
			
			dictionary.Add("FaceDirection", new List<string> {"f2", "f1"});
			dictionary.Add("FaceEnemy", new List<string> {"f2", "f2"});
			
			dictionary.Add("ToLine", new List<string> {"f3", "f1"});
			dictionary.Add("WallOfShields", new List<string> {"f3", "f2"});
			dictionary.Add("Loose", new List<string> {"f3", "f3"});
			dictionary.Add("ToCircle", new List<string> {"f3", "f4"});
			dictionary.Add("ToSquare", new List<string> {"f3", "f5"});
			dictionary.Add("ToSkein", new List<string> {"f3", "f6"});
			dictionary.Add("toColumn", new List<string> {"f3", "f7"});
			dictionary.Add("Scatter", new List<string> {"f3", "f8"});
			
			dictionary.Add("HoldFire", new List<string> {"f4"});
			dictionary.Add("FireAtWill", new List<string> {"f4"});
			
			dictionary.Add("Dismount", new List<string> {"f5"});
			dictionary.Add("Mount", new List<string> {"f5"});
			
			dictionary.Add("CommandOn", new List<string> {"f6"});
			dictionary.Add("CommandOff", new List<string> {"f6"});
			
			dictionary.Add("Transfer", new List<string> {"f7"});
			
			dictionary.Add("Here", new List<string> {"lb"});
			
			
			generator.GenerateTo(@"config\config.json", new KeyboardConfig() {
				Config = dictionary
			});
		}
	}
}