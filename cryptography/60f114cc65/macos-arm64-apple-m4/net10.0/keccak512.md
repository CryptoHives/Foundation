| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-512 · BouncyCastle | 128B         |     324.5 ns |   0.18 ns |   0.15 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 128B         |     336.7 ns |   1.90 ns |   1.78 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 137B         |     325.1 ns |   1.04 ns |   0.92 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 137B         |     325.7 ns |   0.40 ns |   0.36 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 1KB          |   2,299.2 ns |   4.92 ns |   4.11 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 1KB          |   2,465.6 ns |   8.56 ns |   8.01 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 1025B        |   2,299.3 ns |   5.80 ns |   4.84 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 1025B        |   2,475.8 ns |   3.91 ns |   3.66 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 8KB          |  17,672.4 ns |  40.97 ns |  36.32 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 8KB          |  17,915.4 ns |  13.57 ns |  12.03 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-512 · BouncyCastle | 128KB        | 276,491.4 ns | 586.85 ns | 458.18 ns |         - |
| TryComputeHash · Keccak-512 · Managed      | 128KB        | 286,182.6 ns | 267.44 ns | 223.32 ns |         - |