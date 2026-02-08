| Description                         | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · OS Native    | 128B         |     268.7 ns |     0.69 ns |     0.64 ns |         - |
| TryComputeHash · MD5 · Managed      | 128B         |     339.0 ns |     2.40 ns |     2.25 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128B         |     368.9 ns |     0.69 ns |     0.61 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native    | 137B         |     267.0 ns |     0.63 ns |     0.59 ns |         - |
| TryComputeHash · MD5 · Managed      | 137B         |     329.8 ns |     1.83 ns |     1.63 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 137B         |     369.2 ns |     1.04 ns |     0.97 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native    | 1KB          |   1,365.7 ns |     0.98 ns |     0.87 ns |         - |
| TryComputeHash · MD5 · Managed      | 1KB          |   1,804.2 ns |     9.07 ns |     8.49 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1KB          |   2,008.5 ns |     4.73 ns |     4.42 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native    | 1025B        |   1,367.6 ns |     1.17 ns |     1.03 ns |         - |
| TryComputeHash · MD5 · Managed      | 1025B        |   1,796.2 ns |     7.84 ns |     6.95 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1025B        |   2,007.7 ns |     5.39 ns |     4.78 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native    | 8KB          |  10,170.8 ns |    15.62 ns |    14.61 ns |         - |
| TryComputeHash · MD5 · Managed      | 8KB          |  13,605.4 ns |    90.85 ns |    84.99 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 8KB          |  15,139.4 ns |    32.68 ns |    30.57 ns |         - |
|                                     |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native    | 128KB        | 160,854.7 ns |   250.41 ns |   234.24 ns |         - |
| TryComputeHash · MD5 · Managed      | 128KB        | 215,004.8 ns | 1,739.32 ns | 1,626.96 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128KB        | 240,146.1 ns |   341.42 ns |   319.36 ns |         - |