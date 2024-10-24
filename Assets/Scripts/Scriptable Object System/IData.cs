using System;

namespace arg.data
{
    public interface IData
    {
        object GetData();
        void SetData(object a_data, bool a_notify = true);
        Type GetDataType();
        void ResetData();
    }

    public interface IListData
    {
        void Add(object a_data);
        bool Remove(object a_data);
        void Clear();
        void ResetData();
    }
}