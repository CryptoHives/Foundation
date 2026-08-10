| Description                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · BouncyCastle | 128B         |     331.1 ns |   1.37 ns |   1.28 ns |         - |
| TryComputeHash · MD5 · OS Native    | 128B         |     407.8 ns |   3.33 ns |   3.11 ns |         - |
| TryComputeHash · MD5 · Managed      | 128B         |     468.6 ns |   0.15 ns |   0.14 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · BouncyCastle | 137B         |     331.7 ns |   1.58 ns |   1.48 ns |         - |
| TryComputeHash · MD5 · OS Native    | 137B         |     396.2 ns |   0.99 ns |   0.83 ns |         - |
| TryComputeHash · MD5 · Managed      | 137B         |     469.2 ns |   0.10 ns |   0.09 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1KB          |   1,392.6 ns |   9.14 ns |   8.55 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1KB          |   1,853.3 ns |   5.64 ns |   5.28 ns |         - |
| TryComputeHash · MD5 · Managed      | 1KB          |   2,727.0 ns |   1.62 ns |   1.44 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 1025B        |   1,385.7 ns |   8.59 ns |   8.03 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 1025B        |   1,848.7 ns |   6.83 ns |   6.38 ns |         - |
| TryComputeHash · MD5 · Managed      | 1025B        |   2,727.5 ns |   1.84 ns |   1.72 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 8KB          |   9,183.1 ns |  48.70 ns |  45.56 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 8KB          |  14,027.1 ns |  64.28 ns |  60.13 ns |         - |
| TryComputeHash · MD5 · Managed      | 8KB          |  20,782.3 ns |   8.70 ns |   7.71 ns |         - |
|                                     |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native    | 128KB        | 142,894.1 ns | 569.58 ns | 532.79 ns |         - |
| TryComputeHash · MD5 · BouncyCastle | 128KB        | 222,544.6 ns | 594.38 ns | 526.90 ns |         - |
| TryComputeHash · MD5 · Managed      | 128KB        | 330,074.3 ns | 470.97 ns | 440.54 ns |         - |