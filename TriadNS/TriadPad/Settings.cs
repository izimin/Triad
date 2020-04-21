using System.Configuration;

namespace TriadPad.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings 
        {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Settings()
            {
            }


        //Обработчик изменений в настройках
        private void SettingChangingEventHandler( object sender, System.Configuration.SettingChangingEventArgs e )
            {
            }


        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }
    }
}
