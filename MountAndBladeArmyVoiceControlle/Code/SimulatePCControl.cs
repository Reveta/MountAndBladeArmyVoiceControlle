using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Keyboard = InputManager.Keyboard;

namespace MountAndBladeArmyVoiceControlle.Code {
	public class SimulatePcControl {
		private static object _syncObject = new object();

		public void Press(string key) {
			lock (_syncObject) {
				key = key.ToLower();

				Console.WriteLine($"Input => {key}");
			
				switch (key) {
					case "1": Press(Keys.D1);break;
					case "2": Press(Keys.D2);break;
					case "3": Press(Keys.D3);break;
					case "4": Press(Keys.D4);break;
					case "5": Press(Keys.D5);break;
					case "0": Press(Keys.D0);break;
				
					case "f1":Press(Keys.F1);break;
					case "f2":Press(Keys.F2);break;
					case "f3":Press(Keys.F3);break;
					case "f4":Press(Keys.F4);break;
					case "f5":Press(Keys.F5);break;
					case "f6":Press(Keys.F6);break;
					case "f7":Press(Keys.F7);break;
					case "f8":Press(Keys.F8);break;
					case "f9":Press(Keys.F9);break;
				
					case "lb":Press(Keys.LButton);break;
					case "rb":Press(Keys.RButton);break;
				
					// case "=": Press(Ke); break;
					default: Console.WriteLine("default case"); break;
				}
			}
		}

		private void Press(params Keys[] keys) {
			keys.ToList().ForEach(key => {
				Thread.Sleep(1000);
				Keyboard.KeyPress(key, 10);
			});
		}
	}
}