namespace day7;

public interface IAocFileSystemItem
{
    public long Size { get; }
    public string Name { get; set; }
    public AocDirectory Parent { get; set; }
}

public class AocDirectory : IAocFileSystemItem
{
    private long _size;
    private readonly List<IAocFileSystemItem> _items = new();

    public string Name { get; set; }
    public AocDirectory Parent { get; set; }

    public AocDirectory(string name, AocDirectory parent)
    {
        Name = name;
        Parent = parent;
    }

    public long Size
    {
        get
        {
            _size = 0;
            foreach (var item in _items)
            {
                if (item is AocDirectory temp)
                {
                    _size += temp.Size;
                }
                else
                {
                    _size += item.Size;
                }
            }

            return _size;
        }
        set => _size = value;
    }

    public void Add(IAocFileSystemItem item)
    {
        _items.Add(item);
    }

    public AocDirectory GoToSubDirectory(string name)
    {
        return _items.OfType<AocDirectory>().Single(a => a.Name == name);
    }

    public long GetSize() => _items.Sum(item => item.Size);

    public IEnumerable<AocDirectory>? GetAllSubDirectories()
    {
        List<AocDirectory> subDirs = new List<AocDirectory>();
        subDirs.AddRange(_items.OfType<AocDirectory>());
        foreach (var dir in _items.OfType<AocDirectory>())
        {
            var subs = dir.GetAllSubDirectories();
            if(subs is not null)
                subDirs.AddRange(subs);
        }
        
        return subDirs;
    }
}

public class AocFile : IAocFileSystemItem
{
    public AocFile(long size, string name, AocDirectory parent)
    {
        Size = size;
        Name = name;
        Parent = parent;
    }

    public long Size { get; }
    public string Name { get; set; }
    public AocDirectory Parent { get; set; }
}