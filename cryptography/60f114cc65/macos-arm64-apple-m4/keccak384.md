| Description                                | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · BouncyCastle | 128B         |     332.3 ns |   0.64 ns |   0.54 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 128B         |     445.6 ns |   4.66 ns |   4.36 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 137B         |     324.2 ns |   1.20 ns |   1.00 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 137B         |     404.8 ns |   5.54 ns |   4.91 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 1KB          |   1,564.2 ns |   7.18 ns |   6.71 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 1KB          |   1,621.4 ns |   1.41 ns |   1.18 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 1025B        |   1,559.8 ns |   4.86 ns |   4.06 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 1025B        |   1,622.8 ns |   1.27 ns |   1.19 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 8KB          |  12,152.1 ns | 117.84 ns | 110.22 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 8KB          |  12,499.4 ns |  11.61 ns |   9.69 ns |         - |
|                                            |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle | 128KB        | 198,191.6 ns | 655.53 ns | 547.40 ns |         - |
| TryComputeHash · Keccak-384 · Managed      | 128KB        | 199,361.5 ns | 129.90 ns | 115.15 ns |         - |