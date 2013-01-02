using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423.Data
{
    abstract class TreeBank<T>
    {
        private List<T> _nodeList;

        public void initNodeList()
        {
            _nodeList = new List<T>();
        }

        public void addNode(T node)
        {
            _nodeList.Add(node);
        }

        // deletes a node from the node list
        public bool deleteDevice(int nodeId)
        {
            T node = getNodeFromId(nodeId);
            
            if( node != null )
            {
                _nodeList.Remove(node);
                return true;
            }
            return false;
        }


        // get the device object from a device list
        abstract public T getNodeFromId(int nodeId)
        {
            return (T)new object();
        }


        // this method will be called for editing the device Object in the list.
        public void editDevice(T editedNode)
        {
            // deletes the existing device with obsolete data
            _nodeList.Remove(getNodeFromId(editedNode));

            // add the edited device with the new data
            _nodeList.Add(editedNode);
        }

        // this method will be called for deleting the device Object in the list and subtrees.
        public static void deleteDeviceSubtree(int deviceId)
        {
            // delete all the subtree device
            foreach (Device devObj in _nodeList)
            {
                if (devObj.ParentID == deviceId)
                    _nodeList.Remove(getNodeFromId(devObj.DeviceId));
            }

            // deletes the requested device
            _nodeList.Remove(getNodeFromId(deviceId));



        }

        // returns the device list 
        public List<T> getDeviceList()
        {
            // sort the list before returning
            _nodeList.Sort(Device .CompareDeviceId );
            return _nodeList;
        }
    }
    }
}
