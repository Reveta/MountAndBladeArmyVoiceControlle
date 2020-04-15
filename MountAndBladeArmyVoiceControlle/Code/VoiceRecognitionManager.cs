using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace MountAndBladeArmyVoiceControlle.Code {
	public class VoiceRecognitionManager {
		private SpeechRecognitionEngine _speechRecognition;
		private DictationGrammar _dictationGrammar;
		private string[] _phrases;
		private EventHandler<SpeechHypothesizedEventArgs> commandHandler;

		public VoiceRecognitionManager(EventHandler<SpeechHypothesizedEventArgs> commandHandler, params string[] phrases) {
			this.commandHandler = commandHandler;
			this._phrases = phrases;
		}

		public void Run() {
			GrammarBuilder grammarBuilder = new GrammarBuilder();
			grammarBuilder.Append(new Choices(this._phrases));

			this._speechRecognition = new SpeechRecognitionEngine();
			// this._dictationGrammar = new DictationGrammar();
			// this._speechRecognition.LoadGrammar(this._dictationGrammar);
			this._speechRecognition.SetInputToDefaultAudioDevice();
			this._speechRecognition.UnloadAllGrammars();
			this._speechRecognition.LoadGrammar(new Grammar(grammarBuilder)); //загружаем "грамматику"
			this._speechRecognition.RecognizeAsync(RecognizeMode.Multiple); //начинаем распознование
			this._speechRecognition.SpeechHypothesized += AddLog;
		}

		private void AddLog(object sender, SpeechHypothesizedEventArgs args) {
			bool turn = true;
			
			if (!turn) {
				return;
			}
			Console.WriteLine($"RecognationResult => {args.Result.Text}");
			this.commandHandler.Invoke(sender, args);
		}
	}
}