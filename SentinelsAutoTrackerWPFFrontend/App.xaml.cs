//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SentinelsAutoTrackerWPFFrontend
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.Message + ", " + e.Exception.StackTrace, "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);
			e.Handled = true;
			MainWindow mw = new MainWindow();
			mw.Show();
		}
	}
}
