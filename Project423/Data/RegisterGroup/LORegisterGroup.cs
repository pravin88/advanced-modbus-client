using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSMBT;

namespace Project423
{
    class LORegisterGroup : RegisterGroup
    {
        public override void readData(WSMBTControl wsmbtControl)
        {

            ushort startAddress = (ushort)RegisterValueList.Select(item => item.Address).Min();
            ushort endAddress = (ushort) (startAddress + RegisterValueList.Count * 2);
            List<object> valueList = base.readRegisterRange(startAddress, endAddress,wsmbtControl).ToList();

            for (int i = 0; i < RegisterValueList.Count * 2 - 2; i = i+2)
            {
                int val = wsmbtControl.RegistersToInt32(Convert.ToInt16(valueList[i+1]),Convert.ToInt16(valueList[i]));

                ((RegisterValue<int>)RegisterValueList[i/2]).Value = val;
            }
        }

        protected override object[] wsmbtReadMethod(ushort startAdd, ushort count, WSMBTControl wsmbtControl)
        {
            short[] registers = new short[26];
            wsmbtControl.ReadHoldingRegisters(1, startAdd, count, registers);
        
            return Array.ConvertAll(registers,item => (object)item);

        } 
    }
}
