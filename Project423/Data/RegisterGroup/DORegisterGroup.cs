using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSMBT;

namespace Project423
{
    class DORegisterGroup : RegisterGroup
    {
        public override void readData(WSMBTControl wsmbtControl)
        {
            ushort startAddress = (ushort)RegisterValueList.Select(item => item.Address).Min();
            ushort endAddress = (ushort)RegisterValueList.Select(item => item.Address).Max();

            List<object> valueList = base.readRegisterRange(startAddress, endAddress,wsmbtControl).ToList();

            for (int i = 0; i < RegisterValueList.Count; i++)
            {
                ((RegisterValue<bool>)RegisterValueList[i]).Value = Convert.ToBoolean(valueList[i]);
            }
        }

        protected override object[] wsmbtReadMethod(ushort startAdd, ushort count, WSMBTControl wsmbtControl)
        {
            bool[] coils = new bool[25];
            wsmbtControl.ReadCoils(1, startAdd, count, coils);

            return Array.ConvertAll(coils,item => (object)item);

        } 
    }
}
