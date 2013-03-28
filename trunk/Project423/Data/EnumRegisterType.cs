using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project423
{
    // Difference types of Modbus registers
    public enum EnumRegisterType
    {
        DiscreteInput,
        DiscreteOutput,
        AnalogInput,
        AnalogOutput,
        LongInput,
        LongOutput,
        FloatInput,
        FloatOutput
    }
}
