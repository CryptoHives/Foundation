| Description                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · OS Native    | 128B         |     268.5 ns |   0.41 ns |   0.36 ns |         - |
| TryComputeHash · MD5 · Managed      | 128B         |     306.6 ns |   1.40 ns |   1.24 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128B         |     369.2 ns |   0.55 ns |   0.46 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 137B         |     266.5 ns |   0.53 ns |   0.47 ns |         - |
| TryComputeHash · MD5 · Managed      | 137B         |     312.9 ns |   1.37 ns |   1.29 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 137B         |     368.4 ns |   0.91 ns |   0.85 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1KB          |   1,369.3 ns |   2.21 ns |   2.07 ns |         - |
| TryComputeHash · MD5 · Managed      | 1KB          |   1,700.0 ns |   9.62 ns |   9.00 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1KB          |   2,011.0 ns |   3.28 ns |   2.56 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1025B        |   1,369.3 ns |   1.73 ns |   1.62 ns |         - |
| TryComputeHash · MD5 · Managed      | 1025B        |   1,707.1 ns |   5.34 ns |   5.00 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1025B        |   2,008.3 ns |   3.85 ns |   3.41 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 8KB          |  10,153.5 ns |  10.22 ns |   9.56 ns |         - |
| TryComputeHash · MD5 · Managed      | 8KB          |  12,810.9 ns |  75.89 ns |  67.27 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 8KB          |  15,129.1 ns |  20.69 ns |  17.27 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 128KB        | 160,797.5 ns | 172.63 ns | 153.03 ns |         - |
| TryComputeHash · MD5 · Managed      | 128KB        | 202,861.9 ns | 884.49 ns | 827.35 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128KB        | 240,458.7 ns | 440.91 ns | 412.42 ns |         - |