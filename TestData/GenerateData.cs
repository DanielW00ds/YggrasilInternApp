using ModelLiberary;
using System;

namespace TestData
{
    public class GenerateData
    {
        public List<Counterpart> counterparts;

        private List<Counterpart> MakeCounterparts()
        {
            counterparts = new List<Counterpart>();

            // counterpart 1
            Counterpart counterpart1 = new Counterpart();
            counterpart1.Name = "Total Energy";
            counterparts.Add(counterpart1);

            //counterpart 2
            Counterpart counterpart2 = new Counterpart();
            counterpart2.Name = "Sunshine Solar";
            counterparts.Add(counterpart2);

            //counterpart 3
            Counterpart counterpart3 = new Counterpart();
            counterpart3.Name = "Mega Winds";
            counterparts.Add(counterpart3);

            return counterparts;
        }


        public List<Counterpart> generateExtra(List<Asset> assets)
        {
            List<Counterpart> counterparts = MakeCounterparts();
            return counterparts;
        }

    }
}