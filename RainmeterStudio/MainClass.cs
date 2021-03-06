﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using RainmeterStudio.Business;
using RainmeterStudio.Core.Editor;
using RainmeterStudio.Core.Model;
using RainmeterStudio.Core.Storage;
using RainmeterStudio.Editor.ProjectEditor;
using RainmeterStudio.UI;
using RainmeterStudio.UI.Controller;

namespace RainmeterStudio
{
    static class MainClass
    {
        [STAThread]
        public static void Main()
        {
            // Display splash
            SplashScreen splash = new SplashScreen("Resources/splash.png");
            splash.Show(true);

            // Initialize project, document manager
            ProjectManager projectManager = new ProjectManager();
            DocumentManager documentManager = new DocumentManager();

            // Initialize plugin manager
            PluginManager pluginManager = new PluginManager();
            pluginManager.AddRegisterExportTypeHandler(typeof(IDocumentStorage), obj => documentManager.RegisterStorage((IDocumentStorage)obj));
            pluginManager.AddRegisterExportTypeHandler(typeof(IDocumentTemplate), obj => documentManager.RegisterTemplate((IDocumentTemplate)obj));
            pluginManager.AddRegisterExportTypeHandler(typeof(IDocumentEditorFactory), obj => documentManager.RegisterEditorFactory((IDocumentEditorFactory)obj));
            pluginManager.AddRegisterExportTypeHandler(typeof(IProjectTemplate), obj => projectManager.RegisterProjectTemplate((IProjectTemplate)obj));
            pluginManager.Initialize();

            // Create & run app
            var uiManager = new UIManager(projectManager, documentManager);
            uiManager.Run();

            // Run finished, persist settings
            SettingsProvider.SaveSettings();
        }
    }
}
