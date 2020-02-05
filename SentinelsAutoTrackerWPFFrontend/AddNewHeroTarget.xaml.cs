//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using System.Text.RegularExpressions;
using System.Windows;
using SentinelsAutoTrackerEngine;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerWPFFrontend
{
	/// <summary>
	/// Interaction logic for AddNewHeroTarget.xaml
	/// </summary>
	public partial class AddNewHeroTarget : Window
	{
		private MainWindow MainWindow;
		public AddNewHeroTarget(MainWindow mainWindow)
		{
			InitializeComponent();
			cbTypeList_window.ItemsSource = Enum.GetValues(typeof(DamageType));
			cbTypeList_window.SelectedIndex = 1;
			MainWindow = mainWindow;

		}

		
		private void Submit_ButtonClick(object sender, RoutedEventArgs e)
		{
			bool isNumeric = int.TryParse(tbHealthField.Text, out int health);

			if (String.IsNullOrWhiteSpace(tbNameField.Text) || String.IsNullOrWhiteSpace(tbHealthField.Text) || !isNumeric)
			{
				tb_SubmitErrorMessage.Text = "Please make sure that all entered values are valid";
			} else
			{
				string name = tbNameField.Text;
				DamageType type = (DamageType)cbTypeList_window.SelectedItem;
				int heroId = GameContainer.AddHeroTarget(name, health, type);
				CharacterAccount heroTarget = GameContainer.ActiveGame.AllTargets[heroId];
				MainWindow.AllTargets.Add(heroTarget);
				MainWindow.HeroTargets.Add(heroTarget);
				this.Close();
			}
			
		}

	
	}
}
