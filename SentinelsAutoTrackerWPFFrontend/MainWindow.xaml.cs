//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using SentinelsAutoTrackerEngine;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerWPFFrontend
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private CharacterAccount selectedCharacter;
		public ObservableCollection<CharacterAccount> HeroTargets { get; set; }
		public ObservableCollection<CharacterAccount> NonHeroTargets { get; set; }
		public ObservableCollection<CharacterAccount> AllTargets { get; set; }
		public ObservableCollection<CharacterAccount> EnvironmentTargets { get; set; }
		public ObservableCollection<CharacterAccount> VillainTargets { get; set; }
		

		private const int AllTargetsIndex = 0;
		private const int HeroTargetsIndex = 1;
		private const int NonHeroTargetsIndex = 2;
		private const int EnvironmentTargetsIndex = 3;
		private const int VillainTargetsIndex = 4;
		private bool reloading = false;

		public MainWindow()
		{
			InitializeComponent();

			

			NewGame();

		}

		private void NewGame()
		{
			HeroTargets = new ObservableCollection<CharacterAccount>();
			NonHeroTargets = new ObservableCollection<CharacterAccount>();
			AllTargets = new ObservableCollection<CharacterAccount>();
			VillainTargets = new ObservableCollection<CharacterAccount>();
			EnvironmentTargets = new ObservableCollection<CharacterAccount>();


			AddBaseIndicesToAllTargets();

			GameContainer.SetupGame();
			SelectCharacters sc = new SelectCharacters(this);
			sc.ShowDialog();
			lbHeroTargets.ItemsSource = HeroTargets;
			lbNonHeroTargets.ItemsSource = NonHeroTargets;
			cbDamageAllTargetList.ItemsSource = AllTargets;
			cbDamageTypeList.ItemsSource = Enum.GetValues(typeof(DamageType));
			cbDamageAllTargetList.SelectedIndex = 0;
			cbHealAllTargetList.ItemsSource = AllTargets;
			cbHealAllTargetList.SelectedIndex = 0;
			cbDamageTypeList.SelectedIndex = 1;
			tbDmgAmount.Text = "0";
			tbHealAmount.Text = "0";
			lbGlobalModList.ItemsSource = GameContainer.ActiveGame.GlobalAllModifiers;

			if (HeroTargets.Count > 0)
			{
				lbHeroTargets.SelectedIndex = 0;
				selectedCharacter = (CharacterAccount)lbHeroTargets.SelectedItem;
				UpdateSelection();

			}

		}

		private void AddBaseIndicesToAllTargets()
		{
			AllTargets.Add(new CharacterAccount("All Targets", 1, DamageType.None));
			AllTargets.Add(new CharacterAccount("Hero Targets", 1, DamageType.None));
			AllTargets.Add(new CharacterAccount("NonHero Targets", 1, DamageType.None));
			AllTargets.Add(new CharacterAccount("Environment Targets", 1, DamageType.None));
			AllTargets.Add(new CharacterAccount("Villain Targets", 1, DamageType.None));
		}

		private void LbHeroAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!reloading)
			{
				selectedCharacter = (CharacterAccount)lbHeroTargets.SelectedItem;
				UpdateSelection();
			}


		}

		private void UpdateSelection()
		{
			tbDamagingAccountName.Text = selectedCharacter.Name;
			cbDamageTypeList.SelectedItem = selectedCharacter.LastDamageType;
			lbModList.ItemsSource = selectedCharacter.AllModifiers;
		}

		private void LbHeroAccounts_OnFocus(object sender, RoutedEventArgs e)
		{
			if (!reloading)
			{
				if(lbHeroTargets.SelectedIndex == -1)
				{
					lbHeroTargets.SelectedIndex = 0;
				}
				selectedCharacter = (CharacterAccount)lbHeroTargets.SelectedItem;
				UpdateSelection();
			}


		}

		private void LbNonHeroAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!reloading)
			{
				selectedCharacter = (CharacterAccount)lbNonHeroTargets.SelectedItem;
				UpdateSelection();
			}

		}

		private void LbNonHeroAccounts_OnFocus(object sender, RoutedEventArgs e)
		{
			if (!reloading)
			{
				if (lbNonHeroTargets.SelectedIndex == -1)
				{
					lbNonHeroTargets.SelectedIndex = 0;
				}

				selectedCharacter = (CharacterAccount)lbNonHeroTargets.SelectedItem;
				UpdateSelection();
			}

		}

		private void AddNewHero_ButtonClick(object sender, RoutedEventArgs e)
		{
			AddNewHeroTarget addNewHeroTarget = new AddNewHeroTarget(this);
			addNewHeroTarget.Show();
		}

		private void AddNewNonHero_ButtonClick(object sender, RoutedEventArgs e)
		{
			AddNewNonHeroTarget addNewNonHeroTarget = new AddNewNonHeroTarget(this);
			addNewNonHeroTarget.Show();
		}

		private void NewGame_ButtonClick(object sender, RoutedEventArgs e)
		{
			reloading = true;
			NewGame();
			reloading = false;

		}

		private void DamageSubmit_ButtonClick(object sender, RoutedEventArgs e)
		{
			if (selectedCharacter.Incapped == false)
			{
				bool isNumeric = int.TryParse(tbDmgAmount.Text, out int amount);
				if (String.IsNullOrWhiteSpace(tbDmgAmount.Text) || !isNumeric)
				{
					tb_SubmitErrorMessageDamage.Text = "Please make sure that all entered values are valid";
				}
				else
				{
					tb_SubmitErrorMessageDamage.Text = "";
					switch (cbDamageAllTargetList.SelectedIndex)
					{
						case AllTargetsIndex:
							foreach (CharacterAccount target in NonHeroTargets)
							{
								DealDamage(amount, target);
							}
							foreach (CharacterAccount target in HeroTargets)
							{
								DealDamage(amount, target);
							}
							break;
						case HeroTargetsIndex:
							foreach (CharacterAccount target in HeroTargets)
							{
								DealDamage(amount, target);
							}
							break;
						case NonHeroTargetsIndex:
							foreach (CharacterAccount target in NonHeroTargets)
							{
								DealDamage(amount, target);
							}
							break;
						case EnvironmentTargetsIndex:
							foreach (CharacterAccount target in EnvironmentTargets)
							{
								DealDamage(amount, target);
							}
							break;
						case VillainTargetsIndex:
							foreach (CharacterAccount target in VillainTargets)
							{
								DealDamage(amount, target);
							}
							break;
						default:
							CharacterAccount to = (CharacterAccount)cbDamageAllTargetList.SelectedItem;
							DealDamage(amount, to);
							break;
					}

					reloading = true;
					AllTargets.Clear();
					AddBaseIndicesToAllTargets();
					cbDamageAllTargetList.SelectedIndex = 0;
					cbHealAllTargetList.SelectedIndex = 0;
					NonHeroTargets.Clear();
					HeroTargets.Clear();
					VillainTargets.Clear();
					EnvironmentTargets.Clear();

					foreach (CharacterAccount characterAccount in GameContainer.ActiveGame.HeroPlayers)
					{
						HeroTargets.Add(characterAccount);
					}

					foreach (CharacterAccount characterAccount in GameContainer.ActiveGame.HeroTargets)
					{
						if (!HeroTargets.Contains(characterAccount))
						{
							HeroTargets.Add(characterAccount);
						}
						AllTargets.Add(characterAccount);
					}

					foreach (CharacterAccount characterAccount in GameContainer.ActiveGame.VillainTargets)
					{
						AllTargets.Add(characterAccount);
						NonHeroTargets.Add(characterAccount);
						VillainTargets.Add(characterAccount);
					}

					foreach (CharacterAccount characterAccount in GameContainer.ActiveGame.EnvCharacters)
					{
						AllTargets.Add(characterAccount);
						NonHeroTargets.Add(characterAccount);
						EnvironmentTargets.Add(characterAccount);
					}

					reloading = false;

				}
			}
			}

		private void HealSubmit_ButtonClick(object sender, RoutedEventArgs e)
		{
			if (selectedCharacter.Incapped == false)
			{
				bool isNumeric = int.TryParse(tbHealAmount.Text, out int amount);
				if (String.IsNullOrWhiteSpace(tbHealAmount.Text) || !isNumeric)
				{
					tb_SubmitErrorMessageHeal.Text = "Please make sure that all entered values are valid";
				}
				else
				{
					tb_SubmitErrorMessageHeal.Text = "";
					switch (cbHealAllTargetList.SelectedIndex)
					{
						case AllTargetsIndex:
							foreach (CharacterAccount target in NonHeroTargets)
							{
								Heal(amount, target);
							}
							foreach (CharacterAccount target in HeroTargets)
							{
								Heal(amount, target);
							}
							break;
						case HeroTargetsIndex:
							foreach (CharacterAccount target in HeroTargets)
							{
								Heal(amount, target);
							}
							break;
						case NonHeroTargetsIndex:
							foreach (CharacterAccount target in NonHeroTargets)
							{
								Heal(amount, target);
							}
							break;
						case EnvironmentTargetsIndex:
							foreach (CharacterAccount target in EnvironmentTargets)
							{
								Heal(amount, target);
							}
							break;
						case VillainTargetsIndex:
							foreach (CharacterAccount target in VillainTargets)
							{
								Heal(amount, target);
							}
							break;
						default:
							CharacterAccount to = (CharacterAccount)cbHealAllTargetList.SelectedItem;
							Heal(amount, to);
							break;
					}

				}
			}
		}

		private void DealDamage(int amount, CharacterAccount to)
		{
			CharacterAccount from = selectedCharacter;
			DamageType dmgType = (DamageType)cbDamageTypeList.SelectedItem;

			GameContainer.DealDamage(from, to, amount, dmgType);
		}

		private void Heal(int amount, CharacterAccount to)
		{
			CharacterAccount from = selectedCharacter;

			GameContainer.HealCharacter(from, to, amount);
		}

		private void NewMod_ButtonClick(object sender, RoutedEventArgs e)
		{
			AddNewMod addMod = new AddNewMod(selectedCharacter, this);
			addMod.Show();
		}

		private void RemoveMod_ButtonClick(object sender, RoutedEventArgs e)
		{
			if (lbModList.Items.Count > 0)
			{
				Modifier modifier = (Modifier)lbModList.SelectedItem;

				if (modifier.GetType() == typeof(AmountModifier))
				{
					selectedCharacter.RemoveAmountModifier((AmountModifier)modifier);
				}
				else if (modifier.GetType() == typeof(DamageTypeModifier))
				{
					selectedCharacter.RemoveDamageTypeMod((DamageTypeModifier)modifier);
				}
				else if (modifier.GetType() == typeof(ImmunityModifier))
				{
					selectedCharacter.RemoveImmunityMod((ImmunityModifier)modifier);
				}
			}

			
		}

		private void RemoveGlobalMod_ButtonClick(object sender, RoutedEventArgs e)
		{
			if(lbGlobalModList.Items.Count > 0)
			{
				Modifier modifier = (Modifier)lbGlobalModList.SelectedItem;

				GameContainer.RemoveGlobalModifier(modifier);

			}


		}

	}
}