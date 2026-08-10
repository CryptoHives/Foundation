| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · BouncyCastle | 128B         |     179.5 ns |   0.52 ns |   0.44 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 128B         |     259.9 ns |   3.64 ns |   3.41 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 137B         |     179.7 ns |   0.50 ns |   0.42 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 137B         |     242.7 ns |   3.49 ns |   3.27 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 1KB          |   1,119.4 ns |   5.06 ns |   4.49 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 1KB          |   1,410.0 ns |  10.44 ns |   9.76 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 1025B        |   1,120.1 ns |   8.66 ns |   8.10 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 1025B        |   1,401.5 ns |   3.09 ns |   2.89 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 8KB          |   7,711.0 ns |  35.86 ns |  29.94 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 8KB          |   7,961.1 ns |   9.78 ns |   8.17 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 128KB        | 122,421.0 ns | 409.67 ns | 363.16 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 128KB        | 124,832.8 ns | 164.17 ns | 153.57 ns |         - |