using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TriadCore;
using System.Collections;
using System.Reflection;

namespace TriadNSim
{
    public class NSDesign : Design
    {
        public SimulationInfo SimInfo { get; private set; }

        public NSDesign(SimulationInfo simInfo)
        {
            this.SimInfo = simInfo;
        }

        public override Graph Build()
        {
            Graph model = new NSModel(SimInfo).Build();
            NSSimCondition simCondition = new NSSimCondition(SimInfo);
            AddIProcedure(simCondition, 0);

            foreach (NetworkObject spyObject in SimInfo.SpyNodes)
            {
                if (spyObject.ConnectedIPs.Count > 0)
                {
                    Node node = model[new CoreName(spyObject.Name)];
                    foreach(ConnectedIP ip in spyObject.ConnectedIPs)
                    {
                        for (int i = 0, nCount = ip.IP.Params.Count; i < nCount; i++)
                        {
                            IPParam param = ip.IP.Params[i];
                            string paramName = ip.Params[i];
                            SpyObjectType type = param.IsEvent ? SpyObjectType.Event : (param.IsPolus ? SpyObjectType.Polus : SpyObjectType.Var);
                            simCondition.RegisterSpyObjects(node.CreateSpyObject(new CoreName(paramName), type), spyObject.Name + "_" + ip.IP.Name + "_" + paramName + i.ToString());
                        }
                    }
                }
            }


            ICondition[] iConditions = new ICondition[SimInfo.SimContitons.Count + 1];
            iConditions[0] = simCondition;

            int nIndex = 1;
            foreach (ICondition iCondition in SimInfo.SimContitons)
            {
                AddIProcedure(iCondition, nIndex);
                iConditions[nIndex] = iCondition;
                nIndex++;
            }

            //model.DoSimulate(simCondition);
            model.DoSimulate(iConditions);

            return model;
        }
    }
}
