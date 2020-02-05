//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SentinelsAutoTrackerEngine;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerWPFFrontend
{
	/// <summary>
	/// Interaction logic for AddNewNonHeroTarget.xaml
	/// </summary>
	public partial class AddNewNonHeroTarget : Window
	{
		private List<string> _targetTypes = new List<string>() { "Environment", "Villain" };
		private MainWindow MainWindow;
		public AddNewNonHeroTarget(MainWindow mainWindow)
		{
			InitializeComponent();
			cbTargetType.ItemsSource = _targetTypes;
			cbTargetType.SelectedIndex = 0;
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
			}
			else
			{
				string name = tbNameField.Text;
				DamageType type = (DamageType)cbTypeList_window.SelectedItem;
				int targetId;
				CharacterAccount target;
				if (cbTargetType.SelectedIndex == 0)
				{
					targetId = GameContainer.AddEnvironmentTarget(name, health, type);
					target = GameContainer.ActiveGame.AllTargets[targetId];
					MainWindow.EnvironmentTargets.Add(target);
				}
				else
				{
					targetId = GameContainer.AddVillainTarget(name, health, type);
					target = GameContainer.ActiveGame.AllTargets[targetId];
					MainWindow.VillainTargets.Add(target);
				}
				
				MainWindow.AllTargets.Add(target);
				MainWindow.NonHeroTargets.Add(target);
				if(MainWindow.NonHeroTargets.Count == 1)
				{
					MainWindow.lbNonHeroTargets.SelectedIndex = 0;
				}
				this.Close();
			}

		}
	}
}
