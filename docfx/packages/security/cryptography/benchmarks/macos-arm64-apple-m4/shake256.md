| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · BouncyCastle | 128B         |     179.0 ns |   1.14 ns |   1.07 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 128B         |     245.9 ns |   4.82 ns |   5.16 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 137B         |     327.3 ns |   1.00 ns |   0.88 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 137B         |     602.7 ns |   4.50 ns |   3.99 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 1KB          |   1,260.8 ns |   0.49 ns |   0.41 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 1KB          |   1,444.2 ns |   5.08 ns |   4.75 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 1025B        |   1,265.9 ns |   8.05 ns |   7.14 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 1025B        |   1,442.7 ns |   4.34 ns |   4.06 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 8KB          |   9,508.9 ns |  25.86 ns |  21.59 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 8KB          |   9,975.6 ns |  17.78 ns |  16.63 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE256 · BouncyCastle | 128KB        | 150,767.6 ns | 701.22 ns | 621.62 ns |         - |
| TryComputeHash · SHAKE256 · Managed      | 128KB        | 153,520.5 ns | 291.06 ns | 258.02 ns |         - |