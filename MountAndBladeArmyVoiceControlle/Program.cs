using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using InputManager;
using MountAndBladeArmyVoiceControlle.Code;
using MountAndBladeArmyVoiceControlle.Code.JsonManager;
using MountAndBladeArmyVoiceControlle.Code.JsonManager.Structures;
using CommandManager = MountAndBladeArmyVoiceControlle.Code.CommandManager;
using Keyboard = InputManager.Keyboard;

namespace MountAndBladeArmyVoiceControlle {
	internal class Program {
		public static void Main(string[] args) {
			// new ConfigJsonGenerator().Generate();

			JsonReader<KeyboardConfig> jsonReader = new JsonReader<KeyboardConfig>(@"config\config.json");
			Dictionary<string, List<string>> config = jsonReader.GetNewData().Config;
			Dictionary<string, Action> commandDictionary = new Dictionary<string, Action>();

			SimulatePcControl control = new SimulatePcControl();
			config.Keys.ToList().ForEach(key => {
				commandDictionary.Add(
					key: key,
					value: () => config[key]
						.Select(s => new Action(() => control.Press(s)))
						.ToList()
						.ForEach(action => action.Invoke()));
			});

			CommandManager commandManager = new CommandManager(commandDictionary);

			new VoiceRecognitionManager(
				commandHandler: commandManager.GetEventHandler(),
				phrases: commandDictionary.Keys.ToArray()
			).Run();

			Console.ReadLine();
		}
	}
}