using arg.data;
using Sirenix.Serialization;
using System.Collections.Generic;

namespace arg
{
    public class DataAssigner : DataAssignerBase 
    {
        [OdinSerialize]
        public List<DataAssignmentPair> assignmentPairs;

        void Awake()
        {
            if (assignmentPairs == null)
                return;

            foreach (DataAssignmentPair pair in assignmentPairs)
            {
                if (pair == null || pair.dataObject == null)
                    continue;

                pair.dataObject.SetData(pair.target);
            }
        }
    }

    public class DataAssignmentPair
    {
        public IData dataObject;
        public UnityEngine.Object target;
    }
}
