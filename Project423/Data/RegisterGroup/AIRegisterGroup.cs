using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSMBT;

namespace Project423
{
    class AIRegisterGroup : RegisterGroup
    {
        public override void readData(WSMBTControl wsmbtControl)
        {

            ushort startAddress = (ushort)RegisterValueList.Select(item => item.Address).Min();
            ushort endAddress = (ushort)RegisterValueList.Select(item => item.Address).Max();            

            List<object> valueList = base.readRegisterRange(startAddress,endAddress,wsmbtControl).ToList();

            for (int i = 0; i < RegisterValueList.Count; i++)
            {
                ((RegisterValue<short>)RegisterValueList[i]).Value = Convert.ToInt16(valueList[i]);
            }
        }

        protected override object[] wsmbtReadMethod(ushort startAdd, ushort count, WSMBTControl wsmbtControl)
        {
            short[] registers = new short[25];
            wsmbtControl.ReadInputRegisters(1, startAdd, count, registers);
            

            return Array.ConvertAll(registers,item => (object)item);

        } 
    }
}
