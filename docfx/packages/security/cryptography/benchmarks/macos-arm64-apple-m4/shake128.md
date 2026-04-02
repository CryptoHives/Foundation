| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · BouncyCastle | 128B         |     179.4 ns |   0.82 ns |   0.68 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 128B         |     254.2 ns |   3.76 ns |   3.52 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 137B         |     178.6 ns |   0.72 ns |   0.64 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 137B         |     240.5 ns |   2.59 ns |   2.43 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 1KB          |   1,117.8 ns |   6.34 ns |   5.93 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 1KB          |   1,398.0 ns |   6.15 ns |   5.75 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 1025B        |   1,122.5 ns |  12.39 ns |  11.59 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 1025B        |   1,387.5 ns |   4.56 ns |   4.04 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 8KB          |   7,709.6 ns |  70.68 ns |  66.12 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 8KB          |   7,941.5 ns |  14.61 ns |  13.66 ns |         - |
|                                          |              |              |           |           |           |
| TryComputeHash · SHAKE128 · BouncyCastle | 128KB        | 122,470.6 ns | 299.87 ns | 250.40 ns |         - |
| TryComputeHash · SHAKE128 · Managed      | 128KB        | 124,864.3 ns | 179.57 ns | 167.97 ns |         - |