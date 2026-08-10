| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · Managed      | 128B         |     554.4 ns |   0.35 ns |   0.31 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 128B         |   1,034.9 ns |   2.43 ns |   2.28 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 137B         |     822.3 ns |   1.07 ns |   1.00 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 137B         |   1,184.8 ns |   2.05 ns |   1.82 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 1KB          |   1,702.9 ns |   1.34 ns |   1.19 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 1KB          |   2,364.8 ns |   6.55 ns |   6.13 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 1025B        |   1,698.0 ns |   2.54 ns |   2.38 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 1025B        |   2,118.2 ns |   3.97 ns |   3.72 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 8KB          |  10,133.1 ns |   7.20 ns |   5.62 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 8KB          |  11,787.5 ns |  36.68 ns |  34.31 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · BouncyCastle | 128KB        | 150,489.1 ns | 561.36 ns | 468.76 ns |     256 B |
| TryComputeHash · KMAC-256 · Managed      | 128KB        | 153,730.1 ns | 375.10 ns | 350.87 ns |         - |