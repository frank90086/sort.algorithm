## Toolkit
```c#
dotnet add package BenchmarkDotNet --version 0.13.1
```

## Quickly Start
```cmd
dotnet run -c Release
```

## Result

| Method       | input         |                 Mean |              Error |             StdDev |               Median |
| ------------ | ------------- | -------------------: | -----------------: | -----------------: | -------------------: |
| Selection    | Int32[100000] | 4,710,255,500.067 ns | 12,617,328.4662 ns | 11,802,256.8757 ns | 4,708,876,084.000 ns |
| Insertion    | Int32[100000] |       107,821.641 ns |      1,978.8520 ns |      3,465.7996 ns |       106,250.000 ns |
| MergeByArray | Int32[100000] | 3,952,391,408.333 ns | 12,350,219.8778 ns | 11,552,403.3363 ns | 3,950,248,041.000 ns |
| Selection    | Int32[10000]  |    47,249,951.515 ns |    193,630.5129 ns |    181,122.1019 ns |    47,283,450.727 ns |
| Insertion    | Int32[10000]  |        10,480.771 ns |         41.6033 ns |         38.9158 ns |        10,469.788 ns |
| MergeByArray | Int32[10000]  |    41,259,173.503 ns |    278,025.4344 ns |    260,065.1638 ns |    41,262,743.615 ns |
| Selection    | Int32[1000]   |       475,695.432 ns |      3,866.2817 ns |      3,616.5223 ns |       475,188.131 ns |
| Insertion    | Int32[1000]   |         1,049.039 ns |          2.4611 ns |          2.1817 ns |         1,049.553 ns |
| MergeByArray | Int32[1000]   |       515,702.936 ns |      2,919.5112 ns |      2,588.0706 ns |       516,216.573 ns |
| Selection    | Int32[100]    |         5,150.714 ns |         20.0473 ns |         18.7523 ns |         5,158.292 ns |
| Insertion    | Int32[100]    |           107.610 ns |          0.0843 ns |          0.0658 ns |           107.602 ns |
| MergeByArray | Int32[100]    |        10,776.936 ns |         53.8667 ns |         50.3869 ns |        10,751.770 ns |
| Selection    | Int32[10]     |            53.624 ns |          0.0672 ns |          0.0629 ns |            53.617 ns |
| Insertion    | Int32[10]     |             8.946 ns |          0.0432 ns |          0.0404 ns |             8.957 ns |
| MergeByArray | Int32[10]     |           493.891 ns |          1.9544 ns |          1.8281 ns |           493.320 ns |

## Warning
__Don't open *MergeByList* attribute unless you have enough time to wait for all day__