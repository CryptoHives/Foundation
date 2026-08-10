| Description                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · OS Native    | 128B         |     269.5 ns |   1.05 ns |   0.88 ns |         - |
| TryComputeHash · MD5 · Managed      | 128B         |     312.0 ns |   2.70 ns |   2.40 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128B         |     372.4 ns |   1.34 ns |   1.19 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 137B         |     267.3 ns |   0.88 ns |   0.83 ns |         - |
| TryComputeHash · MD5 · Managed      | 137B         |     318.0 ns |   3.49 ns |   3.27 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 137B         |     371.4 ns |   1.03 ns |   0.96 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1KB          |   1,369.3 ns |   2.49 ns |   2.33 ns |         - |
| TryComputeHash · MD5 · Managed      | 1KB          |   1,734.5 ns |  12.82 ns |  10.70 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1KB          |   2,017.4 ns |   7.08 ns |   6.62 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1025B        |   1,369.7 ns |   2.19 ns |   1.94 ns |         - |
| TryComputeHash · MD5 · Managed      | 1025B        |   1,751.6 ns |  17.85 ns |  14.91 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1025B        |   2,015.2 ns |   6.54 ns |   6.12 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 8KB          |  10,164.4 ns |  16.59 ns |  15.52 ns |         - |
| TryComputeHash · MD5 · Managed      | 8KB          |  13,035.6 ns | 110.11 ns |  97.61 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 8KB          |  15,182.5 ns |  22.13 ns |  20.70 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 128KB        | 161,025.7 ns | 323.14 ns | 302.26 ns |         - |
| TryComputeHash · MD5 · Managed      | 128KB        | 206,477.1 ns | 830.64 ns | 693.62 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128KB        | 241,051.6 ns | 531.02 ns | 496.72 ns |         - |