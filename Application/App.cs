﻿// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ App.cs
// Last Code Cleanup:... 01/17/2020 @ 8:16 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore
{

	using System.Collections.Generic;
	using System.Reflection;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCompilationCore.Shared.Events;
	using SelectionMonitorCompilationCore.Shared.UI;

	[Transaction(TransactionMode.Manual)]
	internal class App : IExternalApplication
	{

		#region Fields

		public static UIApplication UIApp;

		public static UIControlledApplication UIContApp;

		#endregion

		#region Properties

		public static List<ElementId> SelectedElementIds
		{
			get;
			set;
		}

		#endregion

		#region Methods (SC)

		public Result OnShutdown(UIControlledApplication uiContApp)
		{
			EventFactory.ShutDown();

			return Result.Succeeded;
		}


		public Result OnStartup(UIControlledApplication uiContApp)
		{
			UIContApp = uiContApp;
			UIApp     = GetUiApplication();

			EventFactory.StartUp();

			var ribbonTab = new Ribbon("Selection Monitor", "Monitor");

			return Result.Succeeded;
		}


		private static UIApplication GetUiApplication()
		{
			var versionNumber = UIContApp.ControlledApplication.VersionNumber;

			var fieldName = string.Empty;

			switch(versionNumber)
			{
				case"2017" :

					fieldName = "m_uiapplication";

					break;

				case"2018" :

					fieldName = "m_uiapplication";

					break;

				case"2019" :

					fieldName = "m_uiapplication";

					break;

				case"2020" :

					fieldName = "m_uiapplication";

					break;
			}

			var fieldInfo = UIContApp.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

			var uiApplication = (UIApplication) fieldInfo?.GetValue(UIContApp);

			return uiApplication;
		}

		#endregion

	}

}