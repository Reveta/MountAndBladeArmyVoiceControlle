using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;

namespace MountAndBladeArmyVoiceControlle.Code {
	public class CommandManager {
		private Dictionary<string, Action> commandDictionary;

		public CommandManager(Dictionary<string, Action> commandDictionary) {
			this.commandDictionary = commandDictionary;
		}

		public EventHandler<SpeechHypothesizedEventArgs> GetEventHandler() {
			var commandHandler = new EventHandler<SpeechHypothesizedEventArgs>((sender, args) => {
				string recognitionText = args.Result.Text;

				Action action = this.commandDictionary[recognitionText];
				action.Invoke();
			});

			return commandHandler;
		}
	}
}