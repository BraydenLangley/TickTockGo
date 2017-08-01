using System;

using UIKit;

namespace TickTockGo
{
    public partial class GameSetupVC : UIViewController
    {
        public int NumberOfPlayers { get; set; }
        public string Variation { get; set; }
        string _opponentSkillLevel;

        UIButton selectedLevel;

        protected GameSetupVC(IntPtr handle) : base(handle)
        {
			// Note: this .ctor should not contain any initialization logic.
		}


        /// <summary>
        /// When the view loads.
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			EnableKeyboardHiding(playerName1);

			if (playerName2 != null)
                EnableKeyboardHiding(playerName2);
        }

        /// <summary>
        /// Enables the keyboard hiding feature.
        /// </summary>
        /// <param name="inputField">Input field.</param>
        void EnableKeyboardHiding(UITextField inputField)
        {
			inputField.ShouldReturn += (textField) =>
			{
				textField.ResignFirstResponder();
				return true;
			};
        }

        /// <summary>
        /// When some one begins making a touch this code
        /// will hide the keyboard.
        /// </summary>
        /// <param name="touches">Touches.</param>
        /// <param name="evt">Evt.</param>
        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            this.View.EndEditing(true);
        }

        partial void Easy(Foundation.NSObject sender)
        {
            _opponentSkillLevel = "Easy";
            SelectTheButton(sender as UIButton);
        }
		partial void Medium(Foundation.NSObject sender)
		{
            _opponentSkillLevel = "Medium";
            SelectTheButton(sender as UIButton);
		}
		partial void Hard(Foundation.NSObject sender)
		{
            _opponentSkillLevel = "Hard";
            SelectTheButton(sender as UIButton);
		}

        void SelectTheButton(UIButton selectedLevel)
        {
            selectedLevel.Alpha = 1;

            if (easyButton != selectedLevel)
            {
                easyButton.Alpha = 0.1f;
            }
            if (mediumButton != selectedLevel)
            {
                mediumButton.Alpha = 0.1f;
            }
            if (hardButton != selectedLevel)
            {
                hardButton.Alpha = 0.1f;
			}
        }

        /// <summary>
        /// Prepares for segue.
        /// </summary>
        /// <param name="segue">Segue.</param>
        /// <param name="sender">Sender.</param>
        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var dv = segue.DestinationViewController as GamePlayVC;

			if (dv != null)
			{
                dv.OpponentSkillLevel = _opponentSkillLevel;
                dv.Variation = Variation; // Should this be refactored to use a member variable?

                if (NumberOfPlayers == 1)
                {
					dv.Players = new string[] { playerName1.Text};
				}
                else
                {
					dv.Players = new string[] { playerName1.Text, playerName2.Text }; // Refactor this code. 
				}

			}
        }
    }
}

