| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     829.5 ns |     0.86 ns |     0.81 ns |   5,456 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128B         |   1,059.9 ns |     1.64 ns |     1.45 ns |   5,231 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |   1,161.3 ns |     0.96 ns |     0.85 ns |   7,966 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     829.0 ns |     1.29 ns |     1.21 ns |   5,458 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 137B         |   1,053.2 ns |     2.49 ns |     2.08 ns |   5,231 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |   1,157.0 ns |     1.23 ns |     1.15 ns |   7,976 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   4,096.3 ns |     6.23 ns |     5.82 ns |   5,464 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1KB          |   5,206.9 ns |     7.86 ns |     7.36 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   5,625.9 ns |     7.74 ns |     7.24 ns |   7,988 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   4,092.1 ns |     5.00 ns |     4.43 ns |   5,464 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1025B        |   5,221.7 ns |     7.63 ns |     7.13 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   5,628.1 ns |     3.19 ns |     2.66 ns |   7,976 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  31,712.3 ns |    38.91 ns |    36.39 ns |   5,462 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 8KB          |  40,920.7 ns |    48.77 ns |    45.62 ns |   5,235 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  44,100.5 ns |    42.13 ns |    39.41 ns |   7,940 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 504,670.3 ns |   511.07 ns |   453.05 ns |   5,469 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128KB        | 653,307.8 ns | 1,500.06 ns | 1,403.15 ns |   5,242 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 703,254.5 ns |   415.12 ns |   368.00 ns |   7,940 B |         - |