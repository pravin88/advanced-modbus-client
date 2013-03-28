using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    // Represents a single register. Stores Address, name and last read value
    abstract public class _RegisterValue
    {
        // Register Address
        public int Address
        {
            get;
            set;
        }

        // A text name to the register
        public string Name
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public static _RegisterValue getRegisterValueFactory(EnumRegisterType registerType, int address, string name)
        {
            _RegisterValue registerValue = null;
                switch (registerType)
                {
                    case EnumRegisterType.DiscreteInput:
                    case EnumRegisterType.DiscreteOutput:
                        registerValue = new RegisterValue<bool>()
                        {
                            Address = address,
                            Name = name,
                            Value = false
                        };
                        break;
                    case EnumRegisterType.AnalogInput:
                    case EnumRegisterType.AnalogOutput:
                        registerValue = new RegisterValue<short>()
                        {
                            Address = address,
                            Name = name,
                            Value = 0
                        };
                        break;
                    case EnumRegisterType.FloatInput:
                    case EnumRegisterType.FloatOutput:
                        registerValue = new RegisterValue<float>()
                        {
                            Address = address,
                            Name = name,
                            Value = 0f
                        };
                        break;
                    case EnumRegisterType.LongInput:
                    case EnumRegisterType.LongOutput:
                        registerValue = new RegisterValue<int>()
                        {
                            Address = address,
                            Name = name,
                            Value = 0
                        };
                        break;
                }

                return registerValue;
        }
    }
}
