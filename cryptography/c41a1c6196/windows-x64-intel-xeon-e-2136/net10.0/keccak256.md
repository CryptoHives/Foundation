| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     427.5 ns |     0.49 ns |     0.41 ns |   5,476 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128B         |     537.0 ns |     2.50 ns |     2.34 ns |   5,249 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     610.7 ns |     2.22 ns |     1.97 ns |   6,284 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     830.4 ns |     1.27 ns |     1.19 ns |   5,454 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 137B         |   1,128.2 ns |     2.69 ns |     2.51 ns |   5,233 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |   1,138.1 ns |     1.59 ns |     1.41 ns |   7,709 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   3,323.9 ns |    17.01 ns |    15.91 ns |   5,464 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1KB          |   4,161.0 ns |    19.00 ns |    17.77 ns |   5,237 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   4,466.2 ns |     6.71 ns |     5.95 ns |   7,674 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   3,310.1 ns |     6.15 ns |     5.13 ns |   5,464 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1025B        |   4,151.9 ns |    23.99 ns |    22.44 ns |   5,237 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   4,462.4 ns |     9.16 ns |     8.57 ns |   7,674 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |  24,654.7 ns |    83.04 ns |    77.67 ns |   5,460 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 8KB          |  32,736.8 ns |   148.87 ns |   139.25 ns |   5,231 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |  33,579.8 ns |    43.73 ns |    40.90 ns |   7,670 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 389,881.5 ns | 1,650.22 ns | 1,543.62 ns |   5,462 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128KB        | 498,516.0 ns | 2,350.47 ns | 2,198.63 ns |   5,235 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 531,893.8 ns | 1,086.93 ns |   963.54 ns |   7,689 B |         - |