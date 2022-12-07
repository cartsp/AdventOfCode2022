namespace day7;

public interface IAocFileSystemItem
{
    public long Size { get; }
    public string Name { get; set; }
}

public class AocDirectory : IAocFileSystemItem
{
    private long _size;

    public AocDirectory(string name)
    {
        Name = name;
    }

    public long Size
    {
        get
        {
            foreach (var item in _items)
            {
                _size += item.Size;
            }

            return _size;
        }
        set => _size = value;
    }

    public string Name { get; set; }

    private readonly List<IAocFileSystemItem> _items = new();

    public void Add(IAocFileSystemItem item)
    {
        _items.Add(item);
    }
}

public class AocFile : IAocFileSystemItem
{
    public AocFile(long size, string name)
    {
        Size = size;
        Name = name;
    }

    public long Size { get; }
    public string Name { get; set; }
}