| Description                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · OS Native    | 128B         |     268.8 ns |   0.51 ns |   0.48 ns |         - |
| TryComputeHash · MD5 · Managed      | 128B         |     326.0 ns |   1.94 ns |   1.81 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128B         |     368.9 ns |   0.49 ns |   0.41 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 137B         |     268.0 ns |   0.66 ns |   0.62 ns |         - |
| TryComputeHash · MD5 · Managed      | 137B         |     328.9 ns |   1.11 ns |   0.92 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 137B         |     368.7 ns |   0.85 ns |   0.79 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1KB          |   1,371.9 ns |   2.61 ns |   2.44 ns |         - |
| TryComputeHash · MD5 · Managed      | 1KB          |   1,792.5 ns |   6.46 ns |   6.04 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1KB          |   2,010.4 ns |   3.58 ns |   3.35 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1025B        |   1,367.8 ns |   1.75 ns |   1.55 ns |         - |
| TryComputeHash · MD5 · Managed      | 1025B        |   1,797.9 ns |   4.34 ns |   3.62 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1025B        |   2,008.4 ns |   4.30 ns |   3.82 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 8KB          |  10,158.8 ns |   9.82 ns |   9.19 ns |         - |
| TryComputeHash · MD5 · Managed      | 8KB          |  13,507.9 ns |  39.10 ns |  32.65 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 8KB          |  15,114.1 ns |  19.00 ns |  16.84 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 128KB        | 160,881.9 ns | 129.41 ns | 114.72 ns |         - |
| TryComputeHash · MD5 · Managed      | 128KB        | 214,550.2 ns | 588.02 ns | 521.26 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128KB        | 240,087.5 ns | 311.72 ns | 291.58 ns |         - |