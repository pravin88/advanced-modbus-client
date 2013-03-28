using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSMBT;
namespace Project423
{
    // Assigned to a node and represents the functional aspects
    abstract public class RegisterGroup
    {
        // IP address to communicate with the device
        public string IpAddress
        {
            get;
            set;
        }

        // Port to communicate with the device
        public int Port
        {
            get;
            set;
        }

        // RegisterType of all the registers in the RegisterValueList
        public EnumRegisterType RegisterType
        {
            get;
            set;
        }

        // List of register and values. One for each register
        public List<_RegisterValue> RegisterValueList
        {
            get;
            set;
        }

        public abstract void readData(WSMBTControl wsmbtControl);

        protected abstract object[] wsmbtReadMethod(ushort startAdd, ushort count, WSMBTControl wsmbtControl);

        protected List<object> readRegisterRange(ushort startAddress, ushort endAddress, WSMBTControl wsmbtControl)
        {
            ushort maxRegToRead = 26;

            ushort tempStartAddress = startAddress;

            List<object> resultList = new List<object>();

            while ((endAddress - tempStartAddress) > 0)
            {
                resultList.AddRange(wsmbtReadMethod(tempStartAddress, maxRegToRead,wsmbtControl));
                
                tempStartAddress = (ushort)(tempStartAddress + maxRegToRead);

            }

            return resultList;
        }

        public static RegisterGroup getRegisterGroupFactory(CrudDeviceModel model, List<_RegisterValue> registerValueList)
        {
            RegisterGroup registerGroup = null;

            switch ((EnumRegisterType)model.RegisterType)
            {
                case EnumRegisterType.DiscreteInput:
                    registerGroup = new DIRegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;
                case EnumRegisterType.DiscreteOutput:
                    registerGroup = new DORegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;

                case EnumRegisterType.AnalogInput:
                    registerGroup = new AIRegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;

                case EnumRegisterType.AnalogOutput:
                    registerGroup = new AORegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;

                case EnumRegisterType.FloatInput:
                    registerGroup = new FIRegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;

                case EnumRegisterType.FloatOutput:
                    registerGroup = new FORegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;
                case EnumRegisterType.LongInput:
                    registerGroup = new LIRegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;

                case EnumRegisterType.LongOutput:
                    registerGroup = new LORegisterGroup()
                    {
                        RegisterValueList = registerValueList
                    };
                    break;
            }

            registerGroup.IpAddress = model.DeviceAddress;
            registerGroup.Port = model.DevicePort;
            registerGroup.RegisterType = (EnumRegisterType)model.RegisterType;

            return registerGroup;
        }

    }
}
