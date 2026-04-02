| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · Managed      | 128B         |     557.4 ns |   1.25 ns |   1.11 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 128B         |   1,074.6 ns |   3.61 ns |   3.20 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 137B         |     546.3 ns |   0.87 ns |   0.77 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 137B         |   1,075.0 ns |   4.42 ns |   3.92 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 1KB          |   1,594.5 ns |   2.98 ns |   2.49 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 1KB          |   2,212.7 ns |   8.83 ns |   7.83 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 1025B        |   1,594.4 ns |   4.10 ns |   3.43 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 1025B        |   2,027.5 ns |   5.90 ns |   5.23 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · Managed      | 8KB          |   8,228.1 ns |  23.48 ns |  19.61 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle | 8KB          |   9,826.3 ns |  22.68 ns |  20.11 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-128 · BouncyCastle | 128KB        | 122,909.7 ns | 205.37 ns | 182.05 ns |     256 B |
| TryComputeHash · KMAC-128 · Managed      | 128KB        | 125,100.2 ns | 154.87 ns | 129.32 ns |         - |