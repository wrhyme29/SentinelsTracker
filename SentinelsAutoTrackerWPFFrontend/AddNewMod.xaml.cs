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
using static SentinelsAutoTrackerEngine.AmountModifier;
using static SentinelsAutoTrackerEngine.CustomDataTypes;
using static SentinelsAutoTrackerEngine.Modifier;

namespace SentinelsAutoTrackerWPFFrontend
{
	/// <summary>
	/// Interaction logic for AddNewMod.xaml
	/// </summary>
	public partial class AddNewMod : Window
	{

		private MainWindow _mainWindow;
		private CharacterAccount _characterAccount;
		private List<string> _modTypes = new List<string>() { "Damage Given", "Damage Taken", "Heal Modifier", "Change Damage Type", "Damage Immunity" };
		private List<string> _applyToList = new List<string>() { "Just Me", "All Targets", "Hero Targets", "NonHero Targets", "Environment Targets", "Villain Targets" } ;


		public AddNewMod(CharacterAccount charAccount, MainWindow mainWindow)
		{
			InitializeComponent();

			_mainWindow = mainWindow;
			_characterAccount = charAccount;

			cbDamageTypeList.ItemsSource = Enum.GetValues(typeof(DamageType));
			cbModTypes.ItemsSource = _modTypes;
			tbAmountField.Text = "0";

			cbDamageTypeList.SelectedItem = DamageType.None;

			cbApplyChoices.ItemsSource = Enum.GetValues(typeof(ModifierTargets));
			cbApplyChoices.SelectedIndex = 0;
		}

		private void Submit_ButtonClick(object sender, RoutedEventArgs e)
		{
			bool isNumeric = int.TryParse(tbAmountField.Text, out int amount);

			if (String.IsNullOrWhiteSpace(tbNameField.Text) || String.IsNullOrWhiteSpace(tbAmountField.Text) || !isNumeric)
			{
				tb_SubmitErrorMessage.Text = "Please make sure that all entered values are valid";
			}
			else
			{
				string name = tbNameField.Text;
				string desc = tbDescriptionField.Text;
				string modType = (string)cbModTypes.SelectedItem;
				DamageType dmgType = (DamageType)cbDamageTypeList.SelectedItem;
				bool oneTime = Convert.ToBoolean((string)((ComboBoxItem)cbOneTime.SelectedItem).Content);
				ModifierTargets targets = (ModifierTargets)cbApplyChoices.SelectedItem;

				switch (modType)
				{
					case "Damage Given":
						GameContainer.AddDamageGivenModifier(new AmountModifier(name, desc, targets, AmountModifierType.DamageGiven, amount, oneTime), _characterAccount);
						break;
					case "Damage Taken":
						GameContainer.AddDamageTakenModifier(new AmountModifier(name, desc, targets, AmountModifierType.DamageTaken, amount, oneTime), _characterAccount);
						break;
					case "Heal Modifier":
						GameContainer.AddHealthModifier(new AmountModifier(name, desc, targets, AmountModifierType.Health, amount, oneTime), _characterAccount);
						break;
					case "Change Damage Type":
						if(dmgType == DamageType.All)
						{
							dmgType = DamageType.None;
						}
						GameContainer.AddDamageTypeModifier(new DamageTypeModifier(name, desc, targets, dmgType), _characterAccount);
						break;
					case "Damage Immunity":
						GameContainer.AddDamageImmunityModifier(new ImmunityModifier(name, desc, targets, dmgType), _characterAccount);
						break;
					default:
						break;
				}
				this.Close();
			}	
		}
		

	}
}
