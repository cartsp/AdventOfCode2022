namespace day7.tests;

public class UnitTest1
{
    public AocDirectory _testRootDirectory;
    
    public UnitTest1()
    {
        _testRootDirectory = new AocDirectory("/", null);
    }
    
    [Fact]
    public void DirectoryReturnsCorrectSizeForSingleFile()
    {
        var testFileA = new AocFile(123, "FileA", _testRootDirectory);
        _testRootDirectory.Add(testFileA);
        
        var dirSize = _testRootDirectory.GetSize();
        
        Assert.Equal(123, dirSize);
    }
    
    [Fact]
    public void DirectoryReturnsCorrectSizeForMultipleFiles()
    {
        var testFileA = new AocFile(123, "FileA", _testRootDirectory);
        _testRootDirectory.Add(testFileA);
        var testFileB = new AocFile(234, "FileB", _testRootDirectory);
        _testRootDirectory.Add(testFileB);
        
        var dirSize = _testRootDirectory.GetSize();
        
        Assert.Equal(357, dirSize);
    }
    
    [Fact]
    public void DirectoryReturnsCorrectSizeForDirectoriesWithFiles()
    {
        var testDirA =  new AocDirectory("DirA", _testRootDirectory);
        var testFileB = new AocFile(234, "FileB", testDirA);
        testDirA.Add(testFileB);
        _testRootDirectory.Add(testDirA);
        
        var testFileA = new AocFile(123, "FileA", _testRootDirectory);
        _testRootDirectory.Add(testFileA);
        
        var dirSize = _testRootDirectory.GetSize();
        
        Assert.Equal(357, dirSize);
    }
    
    [Fact]
    public void AllSubDirectoriesReturnedWithCorrectSizes()
    {
        var testDirA =  new AocDirectory("DirA", _testRootDirectory);
        var testFileB = new AocFile(234, "FileB", testDirA);
        testDirA.Add(testFileB);
        _testRootDirectory.Add(testDirA);
        
        var testDirB =  new AocDirectory("DirB", _testRootDirectory);
        var testFileC = new AocFile(345, "FileC", testDirB);
        testDirB.Add(testFileC);
        _testRootDirectory.Add(testDirB);

        var testFileA = new AocFile(123, "FileA", _testRootDirectory);
        _testRootDirectory.Add(testFileA);
        
        var subDirs = _testRootDirectory.GetAllSubDirectories();
        var total = subDirs?.Sum(a => a.Size);
        
        Assert.Equal(2, subDirs?.Count());
        Assert.Equal(579, total);
    }
}