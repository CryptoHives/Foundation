| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · Managed      | 128B         |     555.1 ns |   0.77 ns |   0.68 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 128B         |   1,058.3 ns |   2.60 ns |   2.43 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 137B         |     546.6 ns |   0.66 ns |   0.58 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 137B         |   1,057.2 ns |   4.91 ns |   4.59 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 1KB          |   1,597.7 ns |   1.50 ns |   1.40 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 1KB          |   2,212.6 ns |   3.59 ns |   2.99 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 1025B        |   1,594.2 ns |   2.26 ns |   2.11 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 1025B        |   1,990.9 ns |   2.93 ns |   2.60 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 8KB          |   8,200.8 ns |  11.84 ns |  11.07 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 8KB          |   9,855.3 ns |  36.28 ns |  33.94 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · BouncyCastle | 128KB        | 122,715.2 ns | 398.03 ns | 332.38 ns |     256 B |
| TryComputeHash · KMAC-128 · Managed      | 128KB        | 124,887.9 ns | 226.64 ns | 189.25 ns |         - |