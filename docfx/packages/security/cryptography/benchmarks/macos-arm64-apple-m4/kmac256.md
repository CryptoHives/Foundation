| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · Managed      | 128B         |     555.8 ns |   0.79 ns |   0.66 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 128B         |   1,034.9 ns |   2.73 ns |   2.55 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 137B         |     821.6 ns |   1.45 ns |   1.28 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 137B         |   1,214.1 ns |  11.47 ns |   9.58 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 1KB          |   1,704.5 ns |   2.53 ns |   2.37 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 1KB          |   2,372.1 ns |  10.14 ns |   9.49 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 1025B        |   1,698.4 ns |   3.19 ns |   2.66 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 1025B        |   2,176.1 ns |   6.17 ns |   5.15 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · Managed      | 8KB          |  10,157.1 ns |  21.27 ns |  19.89 ns |         - |
| TryComputeHash · KMAC-256 · BouncyCastle | 8KB          |  11,812.2 ns |  34.62 ns |  30.69 ns |     256 B |
|                                          |              |              |           |           |           |
| TryComputeHash · KMAC-256 · BouncyCastle | 128KB        | 150,143.5 ns | 255.04 ns | 212.97 ns |     256 B |
| TryComputeHash · KMAC-256 · Managed      | 128KB        | 153,656.7 ns | 223.87 ns | 209.41 ns |         - |