using arg.data;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;

public abstract class ListData<T> : DataObject<List<T>>, IList<T>, IListData
{
    [OdinSerialize]
    bool notifyOnElementChanged;

    public T this[int a_index] 
    {
        get => _data[a_index];
        set
        {
            if (notifyOnElementChanged && ((_data[a_index] != null && !object.ReferenceEquals(_data[a_index], value)) || (_data[a_index] == null && value != null)))
            {
                _data[a_index] = value;
                NotifyDataChange();
            }
            else
                _data[a_index] = value;
        }
    }

    public int Count => _data.Count;

    public bool IsReadOnly => false;

    public void Add(T a_item)
    {
        _data.Add(a_item);
        NotifyDataChange();
    }

    public void Add(object a_data) => Add((T)a_data);

    public void Clear()
    {
        if (_data.Count == 0)
            return;

        _data.Clear();
        NotifyDataChange();
    }

    public bool Contains(T a_item) => _data.Contains(a_item);

    public void CopyTo(T[] a_array, int a_arrayIndex) => _data.CopyTo(a_array, a_arrayIndex);

    public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();

    public int IndexOf(T a_item) => _data.IndexOf(a_item);

    public void Insert(int a_index, T a_item)
    {
        _data.Insert(a_index, a_item);
        NotifyDataChange();
    }

    public bool Remove(T a_item)
    {
        bool value = _data.Remove(a_item);
        if(value)
            NotifyDataChange();
        return value;
    }

    public bool Remove(object a_data) => Remove((T)a_data);

    public void RemoveAt(int a_index)
    {
        _data.RemoveAt(a_index);
        NotifyDataChange();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override List<T> GetResetData() => new List<T>(base.GetResetData());
}
