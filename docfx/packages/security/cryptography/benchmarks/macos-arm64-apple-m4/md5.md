| Description                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · BouncyCastle | 128B         |     351.5 ns |   0.77 ns |   0.64 ns |         - |
| TryComputeHash · MD5 · OS Native    | 128B         |     443.3 ns |   7.37 ns |   7.24 ns |         - |
| TryComputeHash · MD5 · Managed      | 128B         |     534.8 ns |  10.69 ns |  16.64 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · BouncyCastle | 137B         |     358.2 ns |   3.81 ns |   3.56 ns |         - |
| TryComputeHash · MD5 · OS Native    | 137B         |     427.5 ns |   4.67 ns |   4.14 ns |         - |
| TryComputeHash · MD5 · Managed      | 137B         |     559.8 ns |  11.07 ns |  14.78 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1KB          |   1,513.5 ns |   1.59 ns |   1.41 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1KB          |   2,040.9 ns |  39.59 ns |  35.10 ns |         - |
| TryComputeHash · MD5 · Managed      | 1KB          |   3,207.8 ns |  63.14 ns |  98.31 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1025B        |   1,513.2 ns |   2.26 ns |   2.00 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1025B        |   2,057.6 ns |  38.52 ns |  37.84 ns |         - |
| TryComputeHash · MD5 · Managed      | 1025B        |   3,172.9 ns |  63.10 ns |  96.37 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 8KB          |  10,150.6 ns |  66.04 ns |  58.54 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 8KB          |  15,183.2 ns | 108.20 ns |  90.35 ns |         - |
| TryComputeHash · MD5 · Managed      | 8KB          |  24,432.0 ns | 482.30 ns | 792.43 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 128KB        | 157,259.8 ns | 172.20 ns | 143.79 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128KB        | 239,630.8 ns | 338.56 ns | 282.72 ns |         - |
| TryComputeHash · MD5 · Managed      | 128KB        | 331,676.5 ns | 477.01 ns | 398.33 ns |         - |