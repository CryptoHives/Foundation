| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · BouncyCastle | 128B         |     179.7 ns |   0.47 ns |   0.44 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 128B         |     257.8 ns |   3.90 ns |   3.65 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 137B         |     179.6 ns |   0.34 ns |   0.26 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 137B         |     244.1 ns |   2.45 ns |   2.29 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1KB          |   1,122.5 ns |   3.05 ns |   2.85 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 1KB          |   1,438.8 ns |   8.04 ns |   7.52 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 1025B        |   1,118.7 ns |   4.02 ns |   3.57 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 1025B        |   1,399.7 ns |   6.28 ns |   5.88 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 8KB          |   7,749.0 ns |  25.77 ns |  24.10 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 8KB          |   7,931.3 ns |  14.68 ns |  13.73 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · BouncyCastle | 128KB        | 122,967.8 ns | 963.52 ns | 854.13 ns |         - |
| TryComputeHash · cSHAKE128 · Managed      | 128KB        | 124,838.3 ns | 200.26 ns | 187.32 ns |         - |