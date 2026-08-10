| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · BouncyCastle | 128B         |     178.1 ns |   0.47 ns |   0.39 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 128B         |     249.6 ns |   4.99 ns |   4.90 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 137B         |     334.4 ns |   0.49 ns |   0.45 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 137B         |     598.6 ns |   7.81 ns |   7.31 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1KB          |   1,260.1 ns |   3.27 ns |   2.90 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 1KB          |   1,457.4 ns |   6.80 ns |   6.36 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 1025B        |   1,260.0 ns |   1.73 ns |   1.53 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 1025B        |   1,455.6 ns |   5.10 ns |   4.52 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 8KB          |   9,476.6 ns |  41.46 ns |  34.62 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 8KB          |   9,955.0 ns |  14.10 ns |  12.50 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle | 128KB        | 149,114.3 ns | 652.89 ns | 610.71 ns |         - |
| TryComputeHash · cSHAKE256 · Managed      | 128KB        | 153,704.6 ns | 208.63 ns | 195.15 ns |         - |