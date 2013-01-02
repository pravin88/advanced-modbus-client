using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    class ConfigurationStore
    {
        #region /******************************* Configuration List *************************************/
      
        static List<Configuration> _configurationList = new List<Configuration>();
        public List<Configuration> ConfigurationList
        {
            get
            {
                return _configurationList;
            }
        }

        #endregion

        #region /************************************* Instance *****************/

        static ConfigurationStore _instance = null;
        
        /// <summary>
        /// Private constructor
        /// </summary>
        private ConfigurationStore()
        {
            _configurationList = new List<Configuration>();
        }

        /// <summary>
        /// Public methods to access singleton instance
        /// </summary>
        public static ConfigurationStore getInstance()
        {
            if(_instance == null)
                _instance = new ConfigurationStore();

            return _instance;
        }
        
        #endregion 

        #region /************************** CRUD configuration ********************/

        /// <summary>
        /// deletes a Configuration from the Configuration list
        /// </summary>
        public void deleteConfiguration(int ConfigurationID)
        {
            Configuration config = getConfiguration(ConfigurationID);
            if(config != null)
                _configurationList.Remove(config);
        }

        /// <summary>
        /// Add configuration to the store
        /// </summary>
        public void addConfiguration(Configuration config)
        {
            _configurationList.Add(config);
        }

        /// <summary>
        ///  this method will be called for editing the Configuration Object in the list.
        /// </summary>
        public void editConfiguration(Configuration editedConfiguration)
        {
            // deletes the existing Configuration with obsolete data
            _configurationList.Remove(getConfiguration(editedConfiguration.DeviceId));

            // add the edited Configuration with the new data
            _configurationList.Add(editedConfiguration);
        }

        /// <summary>
        ///  get the Configuration object from a Configuration list
        /// </summary>
        public Configuration getConfiguration(int ConfigurationID)
        {
            foreach (Configuration devObj in _configurationList)
            {
                if (devObj.DeviceId == ConfigurationID)
                    return devObj;
            }
            return null;
        }

        /// <summary>
        ///  this method will be called for deleting the Configuration Object in the list and subtrees.
        /// </summary>
        public void deleteConfigurationSubtree(int ConfigurationId)
        {
            // delete all the subtree Configuration
            foreach (Configuration devObj in _configurationList)
            {
                if (devObj.ParentID == ConfigurationId)
                {
                    deleteConfigurationSubtree(devObj.DeviceId);
                }
            }

            // deletes the requested Configuration
            _configurationList.Remove(getConfiguration(ConfigurationId));

        }

        #endregion

        #region /********************* ID Sequence *************************/

        /// <summary>
        /// Returns the next device id to use
        /// </summary>
        public int nextAvailableDeviceId()
        {
            int nextAvailableId = 0;

            nextAvailableId = _configurationList.Max(config => config.DeviceId);

            return nextAvailableId + 1;
        }

        #endregion
    }
}
