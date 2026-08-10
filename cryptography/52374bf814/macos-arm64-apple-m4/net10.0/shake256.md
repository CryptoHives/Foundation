| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · BouncyCastle | 128B         |     179.3 ns |   1.11 ns |   1.03 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 128B         |     248.2 ns |   4.84 ns |   6.29 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 137B         |     324.9 ns |   0.80 ns |   0.67 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 137B         |     588.0 ns |   5.33 ns |   4.98 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 1KB          |   1,258.7 ns |   6.83 ns |   6.06 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 1KB          |   1,440.3 ns |   4.97 ns |   4.65 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 1025B        |   1,257.5 ns |   2.80 ns |   2.48 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 1025B        |   1,437.1 ns |   3.98 ns |   3.53 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 8KB          |   9,350.1 ns |  25.95 ns |  23.00 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 8KB          |   9,956.9 ns |  15.32 ns |  14.33 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 128KB        | 148,760.9 ns | 607.14 ns | 567.92 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 128KB        | 153,264.9 ns | 163.57 ns | 153.00 ns |         - |